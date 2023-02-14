using System.Collections.Generic;
using System.Linq;
using Google.Protobuf.Collections;
using PgQuery;
using Qsi.Data;
using Qsi.PostgreSql.NewTree.Nodes;
using Qsi.Tree;
using Qsi.Utilities;
using static PgQuery.Node;

namespace Qsi.PostgreSql.NewTree;

internal static partial class PgNodeVisitor
{
    public static QsiTableNode Visit(SelectStmt node)
    {
        if (node.IntoClause is not null)
            throw TreeHelper.NotSupportedFeature("Into clause");

        QsiTableNode table = node.Op switch
        {
            SetOperation.SetopNone when node.ValuesLists.Count > 0 => VisitSelectNoneSetValues(node),
            SetOperation.SetopNone => VisitSelectNoneSet(node),
            SetOperation.SetopUnion => VisitSelectComposite(node),
            SetOperation.SetopIntersect => VisitSelectComposite(node),
            SetOperation.SetopExcept => VisitSelectComposite(node),
            _ => throw TreeHelper.NotSupportedFeature($"SetOperation.{node.Op}")
        };

        return table;
    }

    // VALUES (1,2), (3,4)
    private static QsiInlineDerivedTableNode VisitSelectNoneSetValues(SelectStmt node)
    {
        return new QsiInlineDerivedTableNode
        {
            Rows = { node.ValuesLists.Select(Visit<QsiRowValueExpressionNode>) }
        };
    }

    // WITH <with>
    // SELECT <target> FROM <sources> WHERE <filter> 
    // GROUP BY [ ALL | DISTINCT ] <group_by>
    // HAVING <having_condition>
    private static QsiDerivedTableNode VisitSelectNoneSet(SelectStmt node)
    {
        var table = new QsiDerivedTableNode();

        // WITH <with>
        if (node.WithClause is { } with)
        {
            table.Directives.Value = Visit(with);
        }

        // <target>
        if (node.TargetList is { Count: > 0 } target)
        {
            var columns = new QsiColumnsDeclarationNode();
            columns.Columns.AddRange(target.Select(Visit<QsiColumnNode>));

            table.Columns.Value = columns;
        }

        // <sources>
        if (node.FromClause is { Count: > 0 } sources)
        {
            QsiTableNode? from = null;

            foreach (var source in sources.Select(Visit<QsiTableNode>))
            {
                if (from is null)
                {
                    from = source;
                }
                else
                {
                    from = new QsiJoinedTableNode
                    {
                        IsComma = true,
                        Left = { Value = from },
                        Right = { Value = source }
                    };
                }
            }

            table.Source.Value = from;
        }

        // <filter>
        if (node.WhereClause is { } filter)
        {
            table.Where.Value = new QsiWhereExpressionNode
            {
                Expression = { Value = VisitExpression(filter) }
            };
        }

        // <group_by>
        if (node.GroupClause is { Count: > 0 } groupClause)
        {
            table.Grouping.Value = new QsiGroupingExpressionNode
            {
                Items = { groupClause.Select(VisitExpression) }
            };

            // node.GroupDistinct
        }

        // <having_condition>
        if (node.HavingClause is { } havingClause)
        {
            var grouping = table.Grouping.Value ??= new QsiGroupingExpressionNode();
            grouping.Having.Value = VisitExpression(havingClause);
        }

        // LIMIT <limit_count> OFFSET <limit_offset>
        if (node.LimitCount is { } || node.LimitOffset is { })
        {
            var limit = new PgLimitExpressionNode
            {
                Option = node.LimitOption,
                Limit = { Value = VisitExpression(node.LimitCount) },
                Offset = { Value = VisitExpression(node.LimitOffset) }
            };

            table.Limit.Value = limit;
        }

        // ORDER BY sort_clause1, sort_clause2..
        if (node.SortClause is { Count: > 0 })
        {
            var multipleOrder = new QsiMultipleOrderExpressionNode();
            multipleOrder.Orders.AddRange(node.SortClause.Select(Visit<QsiOrderExpressionNode>));

            table.Order.Value = multipleOrder;
        }

        // GROUP, HAVING
        // node.GroupClause, node.HavingClause

        return table;
    }

    public static QsiOrderExpressionNode Visit(SortBy node)
    {
        return new PgOrderExpressionNode
        {
            Order = node.SortbyDir switch
            {
                SortByDir.SortbyAsc => QsiSortOrder.Ascending,
                SortByDir.SortbyDesc => QsiSortOrder.Descending,
                SortByDir.SortbyDefault => QsiSortOrder.Ascending,
                SortByDir.SortbyUsing => QsiSortOrder.Ascending,
                _ => throw CreateInternalException($"Not supported Sort order '{node.SortbyDir}'")
            },
            Expression = { Value = VisitExpression(node.Node) },
            SortByNulls = node.SortbyNulls,
            UsingOperator = { node.UseOp.Select(VisitExpression) },
            SoryByUsing = node.SortbyDir is SortByDir.SortbyUsing,
            IsDefault = node.SortbyDir is SortByDir.SortbyDefault
        };
    }

    private static PgCompositeTableNode VisitSelectComposite(SelectStmt node)
    {
        if (node.Op is not (SetOperation.SetopUnion or SetOperation.SetopIntersect or SetOperation.SetopExcept))
            throw CreateInternalException($"VisitSelectComposite cannot handle '{node.Op}' SetOperation");

        return new PgCompositeTableNode
        {
            Sources = { Visit(node.Larg), Visit(node.Rarg) },
            CompositeType = node.Op.ToString()[5..].ToUpper(), // SetopExcept -> EXCEPT
            IsAll = node.All
        };
    }

    public static QsiTableNode Visit(RangeSubselect node)
    {
        if (node.Subquery is not { } subquery)
            throw CreateInternalException("RangeSubselect.Subquery is null");

        var table = Visit<QsiTableNode>(subquery);

        return table.WithAlias(node.Alias);
    }

    public static QsiTableNode Visit(RangeVar node)
    {
        var tableReference = new PgTableReferenceNode
        {
            Identifier = CreateQualifiedIdentifier(node.Catalogname, node.Schemaname, node.Relname),
            Relpersistence = node.Relpersistence.ToRelpersistence(),
            IsInherit = node.Inh
        };

        if (node.Alias is not { } alias)
            return tableReference;

        var aliasedTable = Visit(alias);
        aliasedTable.Source.Value = tableReference;

        if (alias.Colnames.Count == 0 &&
            aliasedTable.Columns.Value.Columns[0] is QsiAllColumnNode allColumns)
        {
            allColumns.IncludeInvisibleColumns = true;
        }

        return aliasedTable;
    }

    public static QsiTableNode Visit(JoinExpr node)
    {
        var table = new PgJoinedTableNode
        {
            Left = { Value = Visit<QsiTableNode>(node.Larg) },
            Right = { Value = Visit<QsiTableNode>(node.Rarg) },
            JoinType = node.Jointype switch
            {
                JoinType.JoinInner => "CROSS JOIN", // or INNER JOIN
                JoinType.JoinFull => "FULL JOIN", // or FULL OUTER JOIN
                JoinType.JoinLeft => "LEFT JOIN", // or LEFT OUTER JOIN
                JoinType.JoinRight => "RIGHT JOIN", // or RIGHT OUTER JOIN
                _ => throw new QsiException(QsiError.Syntax)
            },
            IsNatural = node.IsNatural
        };

        if (node.UsingClause is { Count: > 0 })
        {
            table.PivotColumns.Value = new QsiColumnsDeclarationNode
            {
                Columns =
                {
                    node.UsingClause.Select(n => new QsiColumnReferenceNode
                    {
                        Name = CreateQualifiedIdentifier(n)
                    })
                }
            };

            if (node.JoinUsingAlias is { } joinAlias)
                table.JoinUsingAlias = CreateIdentifier(joinAlias.Aliasname);
        }

        if (node.Quals is { } onExpr)
            table.PivotExpression.Value = VisitExpression(onExpr);

        return table.WithAlias(node.Alias);
    }

    public static PgAliasedTableNode Visit(Alias node)
    {
        return new PgAliasedTableNode
        {
            Alias = { Value = CreateAliasNode(node.Aliasname) },
            Columns =
            {
                Value = node.Colnames.Count > 0
                    ? CreateSequentialColumnsDeclaration(node.Colnames)
                    : TreeHelper.CreateAllColumnsDeclaration()
            }
        };
    }

    public static QsiTableDirectivesNode Visit(WithClause node)
    {
        var tableDirectives = new QsiTableDirectivesNode
        {
            IsRecursive = node.Recursive
        };

        tableDirectives.Tables.AddRange(node.Ctes.Select(Visit<PgCommonTableNode>));

        return tableDirectives;
    }

    public static PgCommonTableNode Visit(CommonTableExpr node)
    {
        // TODO: Impl CTE search clause (feature/pg-official-parser)
        if (node.SearchClause is { })
            throw TreeHelper.NotSupportedFeature("CTE Search Clause");

        // TODO: Impl CTE cycle clause (feature/pg-official-parser)
        if (node.CycleClause is { })
            throw TreeHelper.NotSupportedFeature("CTE Cycle Clause");

        // NOTE: In CteQuery, allows SELECT, INSERT, UPDATE, DELETE, MERGE statements. but now only support SELECT.
        if (Visit(node.Ctequery) is not QsiTableNode table)
            throw TreeHelper.NotSupportedFeature("CTE Query not select statement");

        return new PgCommonTableNode
        {
            Columns =
            {
                Value = node.Aliascolnames is { Count: > 0 }
                    ? CreateSequentialColumnsDeclaration(node.Aliascolnames)
                    : TreeHelper.CreateAllColumnsDeclaration()
            },
            Source = { Value = table },
            Alias = { Value = CreateAliasNode(node.Ctename) },
            Materialized = node.Ctematerialized
        };
    }

    // UPDATE table SET (c1, c2) = (SELECT c1, c2 FROM table2 WHERE table2.c1 = table.c1)
    //                             ------------------------------------------------------
    public static PgSubLinkExpressionNode Visit(MultiAssignRef node)
    {
        // colno, ncolumns ignored.
        return Visit<PgSubLinkExpressionNode>(node.Source);
    }

    public static QsiSetColumnExpressionNode VisitSetColumn(ResTarget node)
    {
        return new QsiSetColumnExpressionNode
        {
            Target = CreateQualifiedIdentifier(node.Name),
            Value = { Value = VisitExpression(node.Val) }
        };
    }

    public static QsiColumnNode Visit(ResTarget node)
    {
        if (node.Val is not { })
        {
            if (node.Name is { Length: 0 })
                throw CreateInternalException("ResTarget.Val is null and ResTarget.Name is empty");

            return new QsiColumnReferenceNode
            {
                Name = CreateQualifiedIdentifier(node.Name)
            };
        }

        var value = Visit(node.Val);

        var aliased = node.Name.Length != 0;

        // NOTE: https://www.postgresql.org/docs/current/sql-insert.html
        //       Parameters > Inserting > column_name
        if (node.Indirection.Count > 0)
            throw TreeHelper.NotSupportedFeature("Insert column with indirection");

        var column = value switch
        {
            QsiColumnNode col => col,
            QsiExpressionNode expr => new QsiDerivedColumnNode { Expression = { Value = expr } },
            _ => throw CreateInternalException($"ResTarget.Val is not supported node: {value.GetType().Name}")
        };

        if (aliased)
        {
            var aliasedColumn = column switch
            {
                QsiDerivedColumnNode { Alias.IsEmpty: true } derivedColumn => derivedColumn,
                _ => new QsiDerivedColumnNode { Column = { Value = column } },
            };

            aliasedColumn.Alias.Value = CreateAliasNode(node.Name);

            column = aliasedColumn;
        }

        return column;
    }

    public static QsiColumnNode Visit(ColumnRef node)
    {
        RepeatedField<Node> fields = node.Fields;

        if (fields[^1] is { NodeCase: NodeOneofCase.AStar })
        {
            return new QsiAllColumnNode
            {
                Path = fields.Count == 1 ? null : CreateQualifiedIdentifier(fields.SkipLast(1))
            };
        }

        if (node.Fields.Any(f => f.NodeCase is not NodeOneofCase.String))
            throw TreeHelper.NotSupportedTree(node);

        return new QsiColumnReferenceNode
        {
            Name = CreateQualifiedIdentifier(node.Fields)
        };
    }

    private static QsiTableNode WithAlias(this QsiTableNode source, Alias? alias)
    {
        if (alias is null)
            return source;

        var aliasedTable = Visit(alias);
        aliasedTable.Source.Value = source;

        return aliasedTable;
    }

    private static QsiColumnsDeclarationNode CreateSequentialColumnsDeclaration(IEnumerable<Node> colNames)
    {
        var columnsDeclaration = new QsiColumnsDeclarationNode();

        columnsDeclaration.Columns.AddRange(colNames.Select(n =>
        {
            if (n.String is not { } name)
                throw CreateInternalException($"ColNames contains not String node. ({n.NodeCase})");

            return new QsiSequentialColumnNode
            {
                ColumnType = QsiSequentialColumnType.Overwrite,
                Alias = { Value = CreateAliasNode(name.Sval) }
            };
        }));

        return columnsDeclaration;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PrimarSql.Data.Models.Columns;
using Qsi.Analyzers;
using Qsi.Analyzers.Action;
using Qsi.Analyzers.Action.Context;
using Qsi.Analyzers.Action.Models;
using Qsi.Analyzers.Context;
using Qsi.Analyzers.Table;
using Qsi.Analyzers.Table.Context;
using Qsi.Data;
using Qsi.PrimarSql.Tree;
using Qsi.PrimarSql.Utilities;
using Qsi.Shared.Extensions;
using Qsi.Tree;
using Qsi.Utilities;

namespace Qsi.PrimarSql.Analyzers
{
    public class PrimarSqlActionAnalyzer : QsiActionAnalyzer
    {
        public PrimarSqlActionAnalyzer(QsiEngine engine) : base(engine)
        {
        }

        #region Delete
        protected override async ValueTask<IQsiAnalysisResult> ExecuteDataDeleteAction(IAnalyzerContext context, IQsiDataDeleteActionNode action)
        {
            var tableAnalyzer = context.Engine.GetAnalyzer<QsiTableAnalyzer>();

            using var tableContext = new TableCompileContext(context);
            var table = (await tableAnalyzer.BuildTableStructure(tableContext, action.Target)).References[0];

            var commonTableNode = ReassembleCommonTableNode(action.Target);
            var dataTable = await GetDataTableByCommonTableNode(context, commonTableNode);

            var documentColumn = table.NewColumn();
            documentColumn.Name = new QsiIdentifier("Document", false);

            var documentColumnPivot = new DataManipulationTargetColumnPivot(0, documentColumn, -1, null);
            var target = new DataManipulationTarget(table, new[] { documentColumnPivot });

            foreach (var row in dataTable.Rows)
            {
                var targetRow = target.DeleteRows.NewRow();
                targetRow.Items[0] = row.Items[0];
            }

            var dataAction = new QsiDataAction
            {
                Table = target.Table,
                DeleteRows = target.DeleteRows.ToNullIfEmpty()
            };

            return (new[] { dataAction }).ToResult();
        }
        #endregion

        #region Update
        protected override async ValueTask<IQsiAnalysisResult> ExecuteDataUpdateAction(IAnalyzerContext context, IQsiDataUpdateActionNode action)
        {
            var tableAnalyzer = context.Engine.GetAnalyzer<QsiTableAnalyzer>();

            using var tableContext = new TableCompileContext(context);
            var table = (await tableAnalyzer.BuildTableStructure(tableContext, action.Target)).References[0];

#if DEBUG
            var tempTable = new QsiTableStructure
            {
                Type = QsiTableType.Table,
                Identifier = new QsiQualifiedIdentifier(new QsiIdentifier("actor", false))
            };

            var c = tempTable.NewColumn();
            c.Name = new QsiIdentifier("Document", false);
            var dataTable = new QsiDataTable(tempTable);

            var tRow = dataTable.Rows.NewRow();
            tRow.Items[0] = new QsiDataValue("{\"a\": 1, \"actor_id\": 123}", QsiDataType.Object);
#else
            var commonTableNode = ReassembleCommonTableNode(action.Target);
            var dataTable = await GetDataTableByCommonTableNode(context, commonTableNode);
#endif

            var documentColumn = table.NewColumn();
            documentColumn.Name = new QsiIdentifier("Document", false);

            var documentColumnPivot = new DataManipulationTargetColumnPivot(0, documentColumn, -1, null);
            var target = new DataManipulationTarget(table, new[] { documentColumnPivot });

            var setValues = action.SetValues
                .OfType<PrimarSqlSetColumnExpressionNode>()
                .Select(x =>
                {
                    IPart[] part;

                    if (x.TargetExpression.IsEmpty)
                        part = PartUtility.Parse(x.Target.ToString());
                    else
                        part = PartUtility.Parse(context.Engine.TreeDeparser.Deparse(x.TargetExpression.Value, context.Script));

                    return (part, x.Value.Value);
                })
                .ToArray();

            if (setValues.Select(x => x.Item1).Distinct(new PartArrayComparer()).Count() != setValues.Length)
            {
                throw new InvalidOperationException("one or more document path overlapped.");
            }

            foreach (var row in dataTable.Rows)
            {
                var oldRow = target.UpdateBeforeRows.NewRow();
                var newRow = target.UpdateAfterRows.NewRow();

                var beforeValue = row.Items[0];
                var afterValue = JObject.Parse(beforeValue.Value.ToString());

                foreach ((IPart[] part, var value) in setValues)
                {
                    if (!SetValueToToken(afterValue, part, ConvertToToken(value, context)))
                    {
                        throw new InvalidOperationException("Invalid path for update value.");
                    }
                }

                oldRow.Items[0] = beforeValue;
                newRow.Items[0] = new QsiDataValue(afterValue.ToString(Formatting.None), QsiDataType.Object);
            }

            var dataAction = new QsiDataAction
            {
                Table = target.Table,
                UpdateBeforeRows = target.UpdateBeforeRows.ToNullIfEmpty(),
                UpdateAfterRows = target.UpdateAfterRows.ToNullIfEmpty()
            };

            return (new[] { dataAction }).ToResult();
        }
        #endregion

        #region Insert
        protected override async ValueTask<IQsiAnalysisResult> ExecuteDataInsertAction(IAnalyzerContext context, IQsiDataInsertActionNode action)
        {
            var tableAnalyzer = context.Engine.GetAnalyzer<QsiTableAnalyzer>();

            using var tableContext = new TableCompileContext(context);
            var table = await tableAnalyzer.BuildTableStructure(tableContext, action.Target);

            // TODO: Impl when column not provided (Get primary key)

            var documentColumn = table.NewColumn();
            documentColumn.Name = new QsiIdentifier("Document", false);

            var documentColumnPivot = new DataManipulationTargetColumnPivot(0, documentColumn, -1, null);
            var target = new DataManipulationTarget(table, new[] { documentColumnPivot });

            foreach (var value in action.Values)
            {
                var obj = new JObject();
                
                for (int i = 0; i < action.Columns.Length; i++)
                {
                    var column = action.Columns[i][^1];
                    var columnValue = value.ColumnValues[i];

                    obj[column.Value] = ConvertToToken(columnValue, context);
                }

                var row = target.InsertRows.NewRow();
                row.Items[0] = new QsiDataValue(obj.ToString(Formatting.None), QsiDataType.Object);
            }

            var dataAction = new QsiDataAction
            {
                Table = target.Table,
                InsertRows = target.InsertRows.ToNullIfEmpty(),
            };

            return (new[] { dataAction }).ToResult();
        }
        #endregion

        protected override IQsiTableNode ReassembleCommonTableNode(IQsiTableNode node)
        {
            if (node is PrimarSqlDerivedTableNode primarSqlNode)
            {
                var ctn = new PrimarSqlDerivedTableNode
                {
                    Parent = primarSqlNode.Parent,
                    SelectSpec = primarSqlNode.SelectSpec
                };

                if (!primarSqlNode.Columns.IsEmpty)
                    ctn.Columns.SetValue(primarSqlNode.Columns.Value);

                if (!primarSqlNode.Source.IsEmpty)
                    ctn.Source.SetValue(primarSqlNode.Source.Value);

                if (!primarSqlNode.Where.IsEmpty)
                    ctn.Where.SetValue(primarSqlNode.Where.Value);

                if (!primarSqlNode.Order.IsEmpty)
                    ctn.Order.SetValue(primarSqlNode.Order.Value);

                if (!primarSqlNode.Limit.IsEmpty)
                    ctn.Limit.SetValue(primarSqlNode.Limit.Value);

                if (!primarSqlNode.StartKey.IsEmpty)
                    ctn.StartKey.SetValue(primarSqlNode.StartKey.Value);

                return ctn;
            }

            return base.ReassembleCommonTableNode(node);
        }

        private bool SetValueToToken(JToken token, IPart[] parts, JToken value)
        {
            var currentToken = token;

            for (int i = 0; i < parts.Length; i++)
            {
                var part = parts[i];
                bool isLastPart = i == parts.Length - 1;

                switch (part)
                {
                    case IdentifierPart identifierPart when currentToken is JObject jObject:
                        currentToken = jObject[identifierPart.Identifier];

                        if (currentToken == null && isLastPart)
                        {
                            jObject[identifierPart.Identifier] = value;
                            return true;
                        }

                        break;

                    case IndexPart indexPart when currentToken is JArray jArray:
                        currentToken = jArray[indexPart.Index];
                        break;

                    default:
                        return false;
                }

                if (currentToken == null)
                    return false;
            }

            currentToken.Replace(value);
            return true;
        }

        private JToken ConvertToToken(IQsiExpressionNode node, IAnalyzerContext context)
        {
            if (node is QsiLiteralExpressionNode literalNode)
            {
                return literalNode.Type switch
                {
                    QsiDataType.Binary => new JValue((byte[])literalNode.Value),
                    QsiDataType.Boolean => new JValue((bool)literalNode.Value),
                    QsiDataType.Json => JObject.Parse(literalNode.Value.ToString()),
                    QsiDataType.Numeric => new JValue(double.Parse(literalNode.Value.ToString())),
                    QsiDataType.Decimal => new JValue(double.Parse(literalNode.Value.ToString())),
                    QsiDataType.Null => null,
                    _ => literalNode.Value.ToString()
                };
            }

            return context.Engine.TreeDeparser.Deparse(node, context.Script);
        }

        private class PartArrayComparer : IEqualityComparer<IPart[]>
        {
            public bool Equals(IPart[] x, IPart[] y)
            {
                if (x == null && y == null)
                    return true;

                if (x == null || y == null)
                    return false;

                if (x.Length != y.Length)
                    return false;

                for (int i = 0; i < x.Length; i++)
                {
                    var left = x[i];
                    var right = y[i];

                    if (!left.Equals(right))
                        return false;
                }

                return true;
            }

            public int GetHashCode(IPart[] obj)
            {
                return 0;
            }
        }
    }
}

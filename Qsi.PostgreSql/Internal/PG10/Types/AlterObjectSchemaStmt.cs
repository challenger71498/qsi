/* Generated by QSI

 Date: 2020-08-12
 Span: 2830:1 - 2838:24
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("AlterObjectSchemaStmt")]
    internal class AlterObjectSchemaStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_AlterObjectSchemaStmt;

        public ObjectType? objectType { get; set; }

        public RangeVar relation { get; set; }

        public IPg10Node @object { get; set; }

        public string newschema { get; set; }

        public bool? missing_ok { get; set; }
    }
}

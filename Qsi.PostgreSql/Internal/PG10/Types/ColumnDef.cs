/* Generated by QSI

 Date: 2020-08-12
 Span: 636:1 - 657:12
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ColumnDef")]
    internal class ColumnDef : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ColumnDef;

        public string colname { get; set; }

        public TypeName typeName { get; set; }

        public int? inhcount { get; set; }

        public bool? is_local { get; set; }

        public bool? is_not_null { get; set; }

        public bool? is_from_type { get; set; }

        public bool? is_from_parent { get; set; }

        public char? storage { get; set; }

        public IPg10Node raw_default { get; set; }

        public IPg10Node cooked_default { get; set; }

        public char? identity { get; set; }

        public RangeVar identitySequence { get; set; }

        public CollateClause collClause { get; set; }

        public uint? collOid { get; set; }

        public IPg10Node[] constraints { get; set; }

        public IPg10Node[] fdwoptions { get; set; }
    }
}

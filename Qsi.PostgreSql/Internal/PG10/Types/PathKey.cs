/* Generated by QSI

 Date: 2020-08-12
 Span: 847:1 - 855:10
 File: src/postgres/include/nodes/relation.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("PathKey")]
    internal class PathKey : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_PathKey;

        public EquivalenceClass pk_eclass { get; set; }

        public uint? pk_opfamily { get; set; }

        public int? pk_strategy { get; set; }

        public bool? pk_nulls_first { get; set; }
    }
}

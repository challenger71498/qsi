/* Generated by QSI

 Date: 2020-08-12
 Span: 881:1 - 888:13
 File: src/postgres/include/nodes/relation.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("PathTarget")]
    internal class PathTarget : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_PathTarget;

        public IPg10Node[] exprs { get; set; }

        public uint? sortgrouprefs { get; set; }

        public QualCost cost { get; set; }

        public int? width { get; set; }
    }
}

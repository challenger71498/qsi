/* Generated by QSI

 Date: 2020-08-12
 Span: 1615:1 - 1621:16
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("NestLoopState")]
    internal class NestLoopState : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_NestLoopState;

        public JoinState js { get; set; }

        public bool? nl_NeedNewOuter { get; set; }

        public bool? nl_MatchedOuter { get; set; }

        public TupleTableSlot nl_NullInnerTupleSlot { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 1648:1 - 1668:17
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("MergeJoinState")]
    internal class MergeJoinState : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_MergeJoinState;

        public JoinState js { get; set; }

        public int? mj_NumClauses { get; set; }

        public MergeJoinClauseData[] mj_Clauses { get; set; }

        public int? mj_JoinState { get; set; }

        public bool? mj_SkipMarkRestore { get; set; }

        public bool? mj_ExtraMarks { get; set; }

        public bool? mj_ConstFalseJoin { get; set; }

        public bool? mj_FillOuter { get; set; }

        public bool? mj_FillInner { get; set; }

        public bool? mj_MatchedOuter { get; set; }

        public bool? mj_MatchedInner { get; set; }

        public TupleTableSlot[] mj_OuterTupleSlot { get; set; }

        public TupleTableSlot[] mj_InnerTupleSlot { get; set; }

        public TupleTableSlot[] mj_MarkedTupleSlot { get; set; }

        public TupleTableSlot[] mj_NullOuterTupleSlot { get; set; }

        public TupleTableSlot[] mj_NullInnerTupleSlot { get; set; }

        public ExprContext[] mj_OuterEContext { get; set; }

        public ExprContext[] mj_InnerEContext { get; set; }
    }
}

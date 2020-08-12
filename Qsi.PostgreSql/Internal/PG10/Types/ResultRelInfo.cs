/* Generated by QSI

 Date: 2020-08-12
 Span: 346:1 - 415:16
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ResultRelInfo")]
    internal class ResultRelInfo : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ResultRelInfo;

        public uint? ri_RangeTableIndex { get; set; }

        public RelationData ri_RelationDesc { get; set; }

        public int? ri_NumIndices { get; set; }

        public RelationData ri_IndexRelationDescs { get; set; }

        public IndexInfo[] ri_IndexRelationInfo { get; set; }

        public TriggerDesc ri_TrigDesc { get; set; }

        public FmgrInfo ri_TrigFunctions { get; set; }

        public ExprState[] ri_TrigWhenExprs { get; set; }

        public Instrumentation ri_TrigInstrument { get; set; }

        public FdwRoutine ri_FdwRoutine { get; set; }

        public object?[] ri_FdwState { get; set; }

        public bool? ri_usesFdwDirectModify { get; set; }

        public IPg10Node[] ri_WithCheckOptions { get; set; }

        public IPg10Node[] ri_WithCheckOptionExprs { get; set; }

        public ExprState[] ri_ConstraintExprs { get; set; }

        public JunkFilter ri_junkFilter { get; set; }

        public ProjectionInfo ri_projectReturning { get; set; }

        public ProjectionInfo ri_onConflictSetProj { get; set; }

        public ExprState ri_onConflictSetWhere { get; set; }

        public IPg10Node[] ri_PartitionCheck { get; set; }

        public ExprState ri_PartitionCheckExpr { get; set; }

        public RelationData ri_PartitionRoot { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 1923:1 - 1936:14
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("GatherState")]
    internal class GatherState : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_GatherState;

        public PlanState ps { get; set; }

        public bool? initialized { get; set; }

        public bool? need_to_scan_locally { get; set; }

        public TupleTableSlot[] funnel_slot { get; set; }

        public ParallelExecutorInfo[] pei { get; set; }

        public int? nworkers_launched { get; set; }

        public int? nreaders { get; set; }

        public int? nextreader { get; set; }

        public TupleQueueReader[][] reader { get; set; }
    }
}

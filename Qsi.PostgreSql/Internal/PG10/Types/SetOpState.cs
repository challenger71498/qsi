/* Generated by QSI

 Date: 2020-08-12
 Span: 1993:1 - 2009:13
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("SetOpState")]
    internal class SetOpState : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_SetOpState;

        public PlanState ps { get; set; }

        public FmgrInfo eqfunctions { get; set; }

        public FmgrInfo hashfunctions { get; set; }

        public bool? setop_done { get; set; }

        public int? numOutput { get; set; }

        public MemoryContext tempContext { get; set; }

        public SetOpStatePerGroupData pergroup { get; set; }

        public HeapTupleData grp_firstTuple { get; set; }

        public TupleHashTableData hashtable { get; set; }

        public MemoryContext tableContext { get; set; }

        public bool? table_filled { get; set; }

        public tuplehash_iterator hashiter { get; set; }
    }
}

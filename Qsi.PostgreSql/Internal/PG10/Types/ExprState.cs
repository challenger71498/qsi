/* Generated by QSI

 Date: 2020-08-12
 Span: 53:1 - 97:12
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ExprState")]
    internal class ExprState : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ExprState;

        public IPg10Node tag { get; set; }

        public byte? flags { get; set; }

        public bool? resnull { get; set; }

        public uint? resvalue { get; set; }

        public TupleTableSlot resultslot { get; set; }

        public ExprEvalStep steps { get; set; }

        public string evalfunc { get; set; }

        public IPg10ExpressionNode expr { get; set; }

        public int? steps_len { get; set; }

        public int? steps_alloc { get; set; }

        public uint? innermost_caseval { get; set; }

        public bool?[] innermost_casenull { get; set; }

        public uint? innermost_domainval { get; set; }

        public bool?[] innermost_domainnull { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 2309:1 - 2319:19
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreatePolicyStmt")]
    internal class CreatePolicyStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CreatePolicyStmt;

        public string policy_name { get; set; }

        public RangeVar table { get; set; }

        public string cmd_name { get; set; }

        public bool? permissive { get; set; }

        public IPg10Node[] roles { get; set; }

        public IPg10Node qual { get; set; }

        public IPg10Node with_check { get; set; }
    }
}

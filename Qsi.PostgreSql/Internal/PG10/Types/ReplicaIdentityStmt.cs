/* Generated by QSI

 Date: 2020-08-12
 Span: 1770:1 - 1775:22
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ReplicaIdentityStmt")]
    internal class ReplicaIdentityStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ReplicaIdentityStmt;

        public char? identity_type { get; set; }

        public string name { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 1909:1 - 1918:16
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("GrantRoleStmt")]
    internal class GrantRoleStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_GrantRoleStmt;

        public IPg10Node[] granted_roles { get; set; }

        public IPg10Node[] grantee_roles { get; set; }

        public bool? is_grant { get; set; }

        public bool? admin_opt { get; set; }

        public RoleSpec[] grantor { get; set; }

        public DropBehavior? behavior { get; set; }
    }
}

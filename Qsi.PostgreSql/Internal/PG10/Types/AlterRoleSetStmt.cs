/* Generated by QSI

 Date: 2020-08-12
 Span: 2447:1 - 2453:19
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("AlterRoleSetStmt")]
    internal class AlterRoleSetStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_AlterRoleSetStmt;

        public RoleSpec role { get; set; }

        public string database { get; set; }

        public VariableSetStmt setstmt { get; set; }
    }
}

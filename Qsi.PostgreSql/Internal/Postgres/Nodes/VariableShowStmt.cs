// Generate from postgres/src/include/nodes/parsenodes.h

namespace Qsi.PostgreSql.Internal.Postgres.Nodes
{
    [PgNodeAttribute("VariableShowStmt")]
    internal class VariableShowStmt : Node
    {
        public string name { get; set; }
    }
}

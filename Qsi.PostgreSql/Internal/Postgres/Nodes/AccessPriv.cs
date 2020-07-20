// Generate from postgres/src/include/nodes/parsenodes.h

namespace Qsi.PostgreSql.Internal.Postgres.Nodes
{
    [PgNodeAttribute("AccessPriv")]
    internal class AccessPriv : Node
    {
        public string priv_name { get; set; }

        public IPgTree[] cols { get; set; }
    }
}

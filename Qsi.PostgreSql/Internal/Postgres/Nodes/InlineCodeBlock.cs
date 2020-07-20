// Generate from postgres/src/include/nodes/parsenodes.h

namespace Qsi.PostgreSql.Internal.Postgres.Nodes
{
    [PgNodeAttribute("InlineCodeBlock")]
    internal class InlineCodeBlock : Node
    {
        public string source_text { get; set; }

        public int /* oid */ langOid { get; set; }

        public bool langIsTrusted { get; set; }

        public bool atomic { get; set; }
    }
}

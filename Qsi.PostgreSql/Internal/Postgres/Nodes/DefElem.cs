// Generate from postgres/src/include/nodes/parsenodes.h

namespace Qsi.PostgreSql.Internal.Postgres.Nodes
{
    [PgNodeAttribute("DefElem")]
    internal class DefElem : Node
    {
        public string defnamespace { get; set; }

        public string defname { get; set; }

        public Node arg { get; set; }

        public DefElemAction defaction { get; set; }

        public int location { get; set; }
    }
}

// Generate from postgres/src/include/nodes/parsenodes.h

namespace Qsi.PostgreSql.Internal.Postgres.Nodes
{
    [PgNodeAttribute("CreateTransformStmt")]
    internal class CreateTransformStmt : Node
    {
        public bool replace { get; set; }

        public TypeName type_name { get; set; }

        public string lang { get; set; }

        public ObjectWithArgs fromsql { get; set; }

        public ObjectWithArgs tosql { get; set; }
    }
}

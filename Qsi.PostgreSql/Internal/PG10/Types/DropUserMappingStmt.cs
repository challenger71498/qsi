/* Generated by QSI

 Date: 2020-08-12
 Span: 2274:1 - 2280:22
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("DropUserMappingStmt")]
    internal class DropUserMappingStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_DropUserMappingStmt;

        public RoleSpec user { get; set; }

        public string servername { get; set; }

        public bool? missing_ok { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 2139:1 - 2144:21
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("DropTableSpaceStmt")]
    internal class DropTableSpaceStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_DropTableSpaceStmt;

        public string tablespacename { get; set; }

        public bool? missing_ok { get; set; }
    }
}

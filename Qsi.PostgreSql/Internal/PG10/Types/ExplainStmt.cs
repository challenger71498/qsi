/* Generated by QSI

 Date: 2020-08-12
 Span: 3117:1 - 3122:14
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ExplainStmt")]
    internal class ExplainStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ExplainStmt;

        public IPg10Node[] query { get; set; }

        public IPg10Node[] options { get; set; }
    }
}

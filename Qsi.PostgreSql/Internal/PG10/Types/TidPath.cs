/* Generated by QSI

 Date: 2020-08-12
 Span: 1098:1 - 1102:10
 File: src/postgres/include/nodes/relation.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("TidPath")]
    internal class TidPath : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_TidPath;

        public Path path { get; set; }

        public IPg10Node[] tidquals { get; set; }
    }
}

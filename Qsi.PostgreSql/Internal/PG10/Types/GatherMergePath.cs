/* Generated by QSI

 Date: 2020-08-12
 Span: 1275:1 - 1280:18
 File: src/postgres/include/nodes/relation.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("GatherMergePath")]
    internal class GatherMergePath : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_GatherMergePath;

        public Path path { get; set; }

        public Path subpath { get; set; }

        public int? num_workers { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 1156:1 - 1164:13
 File: src/postgres/include/nodes/relation.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CustomPath")]
    internal class CustomPath : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CustomPath;

        public Path path { get; set; }

        public uint? flags { get; set; }

        public IPg10Node[] custom_paths { get; set; }

        public IPg10Node[] custom_private { get; set; }

        public CustomPathMethods methods { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 1059:1 - 1063:17
 File: src/postgres/include/nodes/relation.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("BitmapHeapPath")]
    internal class BitmapHeapPath : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_BitmapHeapPath;

        public Path path { get; set; }

        public Path bitmapqual { get; set; }
    }
}

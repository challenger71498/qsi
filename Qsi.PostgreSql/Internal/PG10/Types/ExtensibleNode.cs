/* Generated by QSI

 Date: 2020-08-12
 Span: 32:1 - 36:17
 File: src/postgres/include/nodes/extensible.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ExtensibleNode")]
    internal class ExtensibleNode : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ExtensibleNode;

        public char? extnodename { get; set; }
    }
}

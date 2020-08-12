/* Generated by QSI

 Date: 2020-08-12
 Span: 2787:1 - 2793:18
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("InlineCodeBlock")]
    internal class InlineCodeBlock : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_InlineCodeBlock;

        public string source_text { get; set; }

        public uint? langOid { get; set; }

        public bool? langIsTrusted { get; set; }
    }
}

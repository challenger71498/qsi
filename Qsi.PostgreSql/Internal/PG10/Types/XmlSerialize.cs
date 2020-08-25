/* Generated by QSI

 Date: 2020-08-12
 Span: 748:1 - 755:15
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("XmlSerialize")]
    internal class XmlSerialize : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_XmlSerialize;

        public XmlOptionType? xmloption { get; set; }

        public IPg10Node[] expr { get; set; }

        public TypeName[] typeName { get; set; }
    }
}

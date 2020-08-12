/* Generated by QSI

 Date: 2020-08-12
 Span: 765:1 - 773:16
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("PartitionElem")]
    internal class PartitionElem : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_PartitionElem;

        public string name { get; set; }

        public IPg10Node expr { get; set; }

        public IPg10Node[] collation { get; set; }

        public IPg10Node[] opclass { get; set; }
    }
}

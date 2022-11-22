/* Generated by QSI

 Date: 2020-08-12
 Span: 688:1 - 698:12
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("IndexElem")]
    internal class IndexElem : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_IndexElem;

        public string name { get; set; }

        public IPg10Node[] expr { get; set; }

        public string indexcolname { get; set; }

        public IPg10Node[] collation { get; set; }

        public IPg10Node[] opclass { get; set; }

        public SortByDir? ordering { get; set; }

        public SortByNulls? nulls_ordering { get; set; }
    }
}

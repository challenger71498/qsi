/* Generated by QSI

 Date: 2020-08-12
 Span: 718:1 - 726:10
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("DefElem")]
    internal class DefElem : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_DefElem;

        public string defnamespace { get; set; }

        public string defname { get; set; }

        public IPg10Node arg { get; set; }

        public DefElemAction? defaction { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 231:1 - 236:12
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ColumnRef")]
    internal class ColumnRef : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ColumnRef;

        public IPg10Node[] fields { get; set; }
    }
}

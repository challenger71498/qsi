/* Generated by QSI

 Date: 2020-08-12
 Span: 436:1 - 443:12
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ResTarget")]
    internal class ResTarget : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ResTarget;

        public string name { get; set; }

        public IPg10Node[] indirection { get; set; }

        public IPg10Node val { get; set; }
    }
}

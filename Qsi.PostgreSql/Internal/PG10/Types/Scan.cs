/* Generated by QSI

 Date: 2020-08-12
 Span: 326:1 - 330:7
 File: src/postgres/include/nodes/plannodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("Scan")]
    internal class Scan : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_Scan;

        public Plan plan { get; set; }

        public uint? scanrelid { get; set; }
    }
}

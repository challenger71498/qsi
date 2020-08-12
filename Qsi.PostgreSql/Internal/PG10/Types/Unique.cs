/* Generated by QSI

 Date: 2020-08-12
 Span: 818:1 - 824:9
 File: src/postgres/include/nodes/plannodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("Unique")]
    internal class Unique : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_Unique;

        public Plan plan { get; set; }

        public int? numCols { get; set; }

        public short? uniqColIdx { get; set; }

        public uint? uniqOperators { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 1121:1 - 1125:15
 File: src/postgres/include/nodes/execnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("SeqScanState")]
    internal class SeqScanState : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_SeqScanState;

        public ScanState ss { get; set; }

        public uint? pscan_len { get; set; }
    }
}

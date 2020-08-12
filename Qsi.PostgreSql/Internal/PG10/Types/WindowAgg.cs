/* Generated by QSI

 Date: 2020-08-12
 Span: 799:1 - 812:12
 File: src/postgres/include/nodes/plannodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("WindowAgg")]
    internal class WindowAgg : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_WindowAgg;

        public Plan plan { get; set; }

        public uint? winref { get; set; }

        public int? partNumCols { get; set; }

        public short? partColIdx { get; set; }

        public uint? partOperators { get; set; }

        public int? ordNumCols { get; set; }

        public short? ordColIdx { get; set; }

        public uint? ordOperators { get; set; }

        public int? frameOptions { get; set; }

        public IPg10Node startOffset { get; set; }

        public IPg10Node endOffset { get; set; }
    }
}

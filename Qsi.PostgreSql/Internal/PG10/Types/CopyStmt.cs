/* Generated by QSI

 Date: 2020-08-12
 Span: 1939:1 - 1951:11
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CopyStmt")]
    internal class CopyStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CopyStmt;

        public RangeVar relation { get; set; }

        public IPg10Node query { get; set; }

        public IPg10Node[] attlist { get; set; }

        public bool? is_from { get; set; }

        public bool? is_program { get; set; }

        public string filename { get; set; }

        public IPg10Node[] options { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 167:1 - 174:19
 File: src/postgres/src_backend_utils_mmgr_aset.c

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal class AllocBlockData
    {
        public AllocSetContext aset { get; set; }

        public AllocBlockData prev { get; set; }

        public AllocBlockData next { get; set; }

        public string freeptr { get; set; }

        public string endptr { get; set; }
    }
}

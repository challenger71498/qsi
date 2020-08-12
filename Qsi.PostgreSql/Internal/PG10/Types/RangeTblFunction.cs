/* Generated by QSI

 Date: 2020-08-12
 Span: 1079:1 - 1092:19
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("RangeTblFunction")]
    internal class RangeTblFunction : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_RangeTblFunction;

        public IPg10Node funcexpr { get; set; }

        public int? funccolcount { get; set; }

        public IPg10Node[] funccolnames { get; set; }

        public IPg10Node[] funccoltypes { get; set; }

        public IPg10Node[] funccoltypmods { get; set; }

        public IPg10Node[] funccolcollations { get; set; }

        public Bitmapset funcparams { get; set; }
    }
}

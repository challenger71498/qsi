/* Generated by QSI

 Date: 2020-08-12
 Span: 536:1 - 545:20
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ScalarArrayOpExpr")]
    internal class ScalarArrayOpExpr : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ScalarArrayOpExpr;

        public IPg10Node xpr { get; set; }

        public uint? opno { get; set; }

        public uint? opfuncid { get; set; }

        public bool? useOr { get; set; }

        public uint? inputcollid { get; set; }

        public IPg10Node[] args { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 873:1 - 879:14
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CollateExpr")]
    internal class CollateExpr : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CollateExpr;

        public IPg10ExpressionNode xpr { get; set; }

        public IPg10ExpressionNode arg { get; set; }

        public uint? collOid { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 903:1 - 912:11
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CaseExpr")]
    internal class CaseExpr : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CaseExpr;

        public IPg10ExpressionNode xpr { get; set; }

        public uint? casetype { get; set; }

        public uint? casecollid { get; set; }

        public IPg10ExpressionNode arg { get; set; }

        public IPg10Node[] args { get; set; }

        public IPg10ExpressionNode defresult { get; set; }
    }
}

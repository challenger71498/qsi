/* Generated by QSI

 Date: 2020-08-12
 Span: 949:1 - 958:12
 File: src/postgres/include/nodes/primnodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("ArrayExpr")]
    internal class ArrayExpr : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_ArrayExpr;

        public IPg10ExpressionNode xpr { get; set; }

        public uint? array_typeid { get; set; }

        public uint? array_collid { get; set; }

        public uint? element_typeid { get; set; }

        public IPg10Node[] elements { get; set; }

        public bool? multidims { get; set; }
    }
}

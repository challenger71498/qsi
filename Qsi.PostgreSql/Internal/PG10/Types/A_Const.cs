/* Generated by QSI

 Date: 2020-08-12
 Span: 284:1 - 289:10
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("A_Const")]
    internal class A_Const : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_A_Const;

        public Value val { get; set; }
    }
}

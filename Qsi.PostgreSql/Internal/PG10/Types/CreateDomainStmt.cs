/* Generated by QSI

 Date: 2020-08-12
 Span: 2505:1 - 2512:19
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreateDomainStmt")]
    internal class CreateDomainStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CreateDomainStmt;

        public IPg10Node[] domainname { get; set; }

        public TypeName[] typeName { get; set; }

        public CollateClause[] collClause { get; set; }

        public IPg10Node[] constraints { get; set; }
    }
}

/* Generated by QSI

 Date: 2020-08-12
 Span: 2404:1 - 2413:18
 File: src/postgres/include/nodes/parsenodes.h

*/

using Qsi.PostgreSql.Internal.Serialization;

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    [PgNode("CreatePLangStmt")]
    internal class CreatePLangStmt : IPg10Node
    {
        public virtual NodeTag Type => NodeTag.T_CreatePLangStmt;

        public bool? replace { get; set; }

        public string plname { get; set; }

        public IPg10Node[] plhandler { get; set; }

        public IPg10Node[] plinline { get; set; }

        public IPg10Node[] plvalidator { get; set; }

        public bool? pltrusted { get; set; }
    }
}

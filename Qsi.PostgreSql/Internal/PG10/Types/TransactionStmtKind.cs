/* Generated by QSI

 Date: 2020-08-12
 Span: 2917:1 - 2929:22
 File: src/postgres/include/nodes/parsenodes.h

*/

namespace Qsi.PostgreSql.Internal.PG10.Types
{
    internal enum TransactionStmtKind
    {
        TRANS_STMT_BEGIN = 0,
        TRANS_STMT_START = 1,
        TRANS_STMT_COMMIT = 2,
        TRANS_STMT_ROLLBACK = 3,
        TRANS_STMT_SAVEPOINT = 4,
        TRANS_STMT_RELEASE = 5,
        TRANS_STMT_ROLLBACK_TO = 6,
        TRANS_STMT_PREPARE = 7,
        TRANS_STMT_COMMIT_PREPARED = 8,
        TRANS_STMT_ROLLBACK_PREPARED = 9
    }
}

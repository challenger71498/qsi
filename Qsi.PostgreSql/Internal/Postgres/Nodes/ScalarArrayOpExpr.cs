// Generate from postgres/src/include/nodes/primnodes.h

namespace Qsi.PostgreSql.Internal.Postgres.Nodes
{
    internal class ScalarArrayOpExpr
    {
        public Expr xpr { get; set; }

        public int /* oid */ opno { get; set; }

        public int /* oid */ opfuncid { get; set; }

        public bool useOr { get; set; }

        public int /* oid */ inputcollid { get; set; }

        public IPgTree[] args { get; set; }

        public int location { get; set; }
    }
}

﻿using Qsi.Data;

namespace Qsi.PrimarSql.Data
{
    public sealed class PrimarSqlTableColumn : QsiTableColumn
    {
        public object[] Path { get; internal set; }
    }
}

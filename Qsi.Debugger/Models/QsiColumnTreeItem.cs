﻿using System.Collections.Generic;
using System.Linq;
using Qsi.Data;

namespace Qsi.Debugger.Models
{
    public class QsiColumnTreeItem
    {
        public int Depth { get; }

        public QsiDataColumn Column { get; }

        public QsiColumnTreeItem[] Items { get; }

        public bool IsRecursive { get; }

        public QsiColumnTreeItem(QsiDataColumn column, int depth = 0) : this(column, depth, new HashSet<QsiDataColumn>())
        {
        }

        private QsiColumnTreeItem(QsiDataColumn column, int depth, HashSet<QsiDataColumn> recursiveTracker)
        {
            Depth = depth;
            Column = column;

            if (recursiveTracker.Contains(column))
            {
                IsRecursive = true;
                return;
            }

            recursiveTracker.Add(column);

            Items = column.References
                .Select(c => new QsiColumnTreeItem(c, depth + 1, recursiveTracker))
                .ToArray();

            recursiveTracker.Remove(column);
        }
    }
}

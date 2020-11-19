﻿using System.Collections.Generic;
using Qsi.Tree.Data;

namespace Qsi.Tree.Immutable
{
    public class ImmutableGroupingExpressionNode : IQsiGroupingExpressionNode
    {
        public IQsiTreeNode Parent { get; }

        public IQsiExpressionNode[] Items { get; }

        public IQsiExpressionNode Having { get; }

        public IUserDataHolder UserData { get; }

        public IEnumerable<IQsiTreeNode> Children => Items;

        public ImmutableGroupingExpressionNode(
            IQsiTreeNode parent,
            IQsiExpressionNode[] items,
            IQsiExpressionNode having,
            IUserDataHolder userData)
        {
            Parent = parent;
            Items = items;
            Having = having;
            UserData = userData;
        }
    }
}

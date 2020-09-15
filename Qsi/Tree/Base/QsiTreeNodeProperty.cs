﻿namespace Qsi.Tree.Base
{
    public class QsiTreeNodeProperty<TNode> where TNode : QsiTreeNode
    {
        public TNode Value { get; private set; }

        public bool IsEmpty => Value == null;

        private readonly QsiTreeNode _owner;

        public QsiTreeNodeProperty(QsiTreeNode owner)
        {
            _owner = owner;
        }

        public void SetValue(TNode value)
        {
            value.Parent = _owner;
            Value = value;
        }
    }
}

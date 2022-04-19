﻿using System.Collections.Generic;

namespace Qsi.MongoDB.Internal.Nodes;

internal class ChainExpressionNode : BaseNode, IExpressionNode
{
    // SimpleCallExpression, MemberExpression
    public INode Expression { get; set; }

    public override IEnumerable<INode> Children
    {
        get { yield return Expression; }
    }
}

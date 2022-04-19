﻿using System.Collections.Generic;

namespace Qsi.MongoDB.Internal.Nodes;

internal class UnaryExpressionNode : BaseNode, IExpressionNode
{
    public string Operator { get; set; }

    public bool Prefix { get; set; }

    public IExpressionNode Argument { get; set; }

    public override IEnumerable<INode> Children
    {
        get { yield return Argument; }
    }
}

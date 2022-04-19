﻿using System.Collections.Generic;

namespace Qsi.MongoDB.Internal.Nodes;

internal class ArrayExpressionNode : BaseNode, IExpressionNode
{
    // BaseExpression, SpreadElement
    public INode[] Elements { get; set; }

    public override IEnumerable<INode> Children => Elements;
}

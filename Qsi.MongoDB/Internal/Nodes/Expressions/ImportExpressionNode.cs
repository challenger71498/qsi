﻿using System.Collections.Generic;

namespace Qsi.MongoDB.Internal.Nodes;

internal class ImportExpressionNode : BaseNode, IExpressionNode
{
    public IExpressionNode Source { get; set; }

    public override IEnumerable<INode> Children
    {
        get { yield return Source; }
    }
}

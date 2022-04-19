﻿using System.Collections.Generic;

namespace Qsi.MongoDB.Internal.Nodes;

internal class BlockStatementNode : BaseNode, IStatementNode
{
    public IStatementNode[] Body { get; set; }

    // public CommentNode[] InnerComments { get; set; }
    public override IEnumerable<INode> Children => Body;
}

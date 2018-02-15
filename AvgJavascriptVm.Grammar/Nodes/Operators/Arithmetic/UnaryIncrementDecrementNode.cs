using System;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public abstract class UnaryIncrementDecrementNode: UnaryOperatorNode
    {
        protected UnaryIncrementDecrementNode(ExpressionNode value) : base(value)
        {
            if (!(value is IdentifierNode) && !(value is IndexerGetterNode) && !(value is PropertyGetterNode))
            {
                throw new ApplicationException("lvalue must be identifier, indexer getter or property getter node");
            }
        }
    }
}
using System;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ObjectPropertyIdentifierNode: Node
    {
        public ExpressionNode Identifier { get; }

        public ObjectPropertyIdentifierNode(ExpressionNode identifier)
        {
            if (!(identifier is StringNode) && !(identifier is IdentifierNode))
            {
                throw new ApplicationException("Object property identifier must be string or identifier");
            }
            Identifier = identifier;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            Identifier.ToString(strBuilder);
        }
    }
}
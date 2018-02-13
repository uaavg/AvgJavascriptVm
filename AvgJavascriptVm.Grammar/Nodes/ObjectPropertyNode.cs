using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ObjectPropertyNode: Node
    {
        public ObjectPropertyIdentifierNode Identifier { get; }

        public ExpressionNode Expression { get; }

        public ObjectPropertyNode(ObjectPropertyIdentifierNode identifier, ExpressionNode expression)
        {
            Identifier = identifier;
            Expression = expression;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            Identifier.ToString(strBuilder);
            strBuilder.Append(": ");
            Expression.ToString(strBuilder);
        }
    }
}
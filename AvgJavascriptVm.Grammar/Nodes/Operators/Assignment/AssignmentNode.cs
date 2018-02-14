using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes.Operators.Assignment
{
    public class AssignmentNode: Node
    {
        public IdentifierNode Identifier { get; }

        public ExpressionNode RValue { get; }

        public AssignmentNode(IdentifierNode identifier, ExpressionNode rValue)
        {
            Identifier = identifier;
            RValue = rValue;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            Identifier.ToString(strBuilder);
            strBuilder.Append(" = ");
            RValue.ToString(strBuilder);
        }
    }
}
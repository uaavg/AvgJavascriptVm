using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class UnaryPlusNode: UnaryOperatorNode
    {
        public UnaryPlusNode(ExpressionNode value) : 
            base(value)
        {

        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("+");
            Value.ToString(strBuilder);
        }
    }
}
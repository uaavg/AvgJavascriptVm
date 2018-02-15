using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class UnaryNegationNode: UnaryOperatorNode
    {
        public UnaryNegationNode(ExpressionNode value) :
            base(value)
        {

        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("-");
            Value.ToString(strBuilder);
        }
    }
}
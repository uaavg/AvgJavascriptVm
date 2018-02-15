using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class PostfixIncrement: UnaryOperatorNode
    {
        public PostfixIncrement(ExpressionNode value) : 
            base(value)
        {

        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            Value.ToString(strBuilder);
            strBuilder.Append("++");
        }
    }
}
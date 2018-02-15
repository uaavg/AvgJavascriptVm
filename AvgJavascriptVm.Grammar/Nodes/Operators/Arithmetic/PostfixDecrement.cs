using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class PostfixDecrement: UnaryOperatorNode
    {
        public PostfixDecrement(ExpressionNode value) 
            : base(value)
        {

        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            Value.ToString(strBuilder);
            strBuilder.Append("--");
        }
    }
}
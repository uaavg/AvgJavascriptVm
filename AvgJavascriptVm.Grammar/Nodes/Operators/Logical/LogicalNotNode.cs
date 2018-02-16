using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class LogicalNotNode: UnaryOperatorNode
    {
        public LogicalNotNode(ExpressionNode value) : 
            base(value)
        {

        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("!");
            Value.ToString(strBuilder);
        }
    }
}
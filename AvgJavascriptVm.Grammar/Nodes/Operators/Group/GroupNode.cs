using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class GroupNode: UnaryOperatorNode
    {
        public GroupNode(ExpressionNode value) : 
            base(value)
        {

        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("(");
            Value.ToString(strBuilder);
            strBuilder.Append(")");
        }
    }
}
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class DeleteNode: UnaryOperatorNode
    {
        public DeleteNode(ExpressionNode value) : base(value)
        {

        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("delete ");
            Value.ToString(strBuilder);
        }
    }
}
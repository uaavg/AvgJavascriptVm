using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class VoidNode: UnaryOperatorNode
    {
        public VoidNode(ExpressionNode value) : base(value)
        {

        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("void ");
            Value.ToString(strBuilder);
        }
    }
}
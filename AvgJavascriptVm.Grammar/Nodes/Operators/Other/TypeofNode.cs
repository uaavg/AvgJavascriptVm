using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class TypeofNode: UnaryOperatorNode
    {
        public TypeofNode(ExpressionNode value) : base(value)
        {

        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("typeof ");
            Value.ToString(strBuilder);
        }
    }
}
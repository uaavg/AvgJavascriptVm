using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class EmptyExpression: ExpressionNode
    {
        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append(";");
        }
    }
}
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ExpressionNode: StatementNode
    {
        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("exp");
        }
    }
}
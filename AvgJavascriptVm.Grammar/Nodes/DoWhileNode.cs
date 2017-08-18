using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class DoWhileNode: StatementNode
    {
        public ExpressionNode Condition { get; }

        public StatementNode Body { get; }

        public DoWhileNode(ExpressionNode condition, StatementNode body)
        {
            Condition = condition;
            Body = body;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("do");
            Body.ToString(strBuilder);
            strBuilder.Append("while(");
            Condition.ToString(strBuilder);
            strBuilder.Append(")");
        }
    }
}

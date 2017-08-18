using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class WhileNode: StatementNode
    {
        public ExpressionNode Condition { get; }

        public StatementNode Body { get; }

        public WhileNode(ExpressionNode condition, StatementNode body)
        {
            Condition = condition;
            Body = body;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("while(");
            Condition.ToString(strBuilder);
            strBuilder.Append(")");
            Body.ToString(strBuilder);
        }
    }
}
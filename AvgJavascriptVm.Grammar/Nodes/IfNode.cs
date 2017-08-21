using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class IfNode: StatementNode
    {
        public ExpressionNode Condition { get; }

        public StatementNode Body { get; }

        public IfNode(ExpressionNode condition, StatementNode body)
        {
            Condition = condition;
            Body = body;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("if(");
            Condition.ToString(strBuilder);
            strBuilder.Append(") ");
            Body.ToString(strBuilder);
        }
    }
}
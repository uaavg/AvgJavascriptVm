using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class IfElseNode: StatementNode
    {
        public ExpressionNode Condition { get; }

        public StatementNode Body { get; }

        public StatementNode ElseBody { get; }

        public IfElseNode(ExpressionNode condition, StatementNode body, StatementNode elseBody)
        {
            Condition = condition;
            Body = body;
            ElseBody = elseBody;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("if(");
            Condition.ToString(strBuilder);
            strBuilder.Append(") ");
            Body.ToString(strBuilder);
            strBuilder.Append("else ");
            ElseBody.ToString(strBuilder);
        }
    }
}
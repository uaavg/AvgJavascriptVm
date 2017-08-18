using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ReturnNode: StatementNode
    {
        public ExpressionNode Expression { get; }

        public ReturnNode()
        {
            
        }

        public ReturnNode(ExpressionNode expression)
        {
            Expression = expression;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("return");
            if (Expression != null)
            {
                strBuilder.Append(" ");
                Expression.ToString(strBuilder);
            }           
            strBuilder.Append(";");
        }
    }
}
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class VariableDeclarationIdentifierNode: Node
    {
        public string Identifer { get; }

        public ExpressionNode Expression { get; }

        public VariableDeclarationIdentifierNode(string identifer, ExpressionNode expression = null)
        {
            Identifer = identifer;
            Expression = expression;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append($"{Identifer}");
            if (Expression != null)
            {
                strBuilder.Append(" = ");
                Expression.ToString(strBuilder);
            }
        }
    }
}
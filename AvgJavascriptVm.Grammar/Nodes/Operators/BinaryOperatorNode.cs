using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public abstract class BinaryOperatorNode: ExpressionNode
    {
        public ExpressionNode LValue { get; }

        public ExpressionNode RValue { get; }

        protected abstract string OperatorToken { get; }        

        protected BinaryOperatorNode(ExpressionNode lValue, ExpressionNode rValue)
        {
            LValue = lValue;
            RValue = rValue;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            LValue.ToString(strBuilder);
            strBuilder.Append($" {OperatorToken} ");
            RValue.ToString(strBuilder);
        }
    }
}
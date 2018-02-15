using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public abstract class ComparisonNode: ExpressionNode
    {
        public ExpressionNode LValue { get; }

        public ExpressionNode RValue { get; }

        protected abstract string ComparisonToken { get; }        

        protected ComparisonNode(ExpressionNode lValue, ExpressionNode rValue)
        {
            LValue = lValue;
            RValue = rValue;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            LValue.ToString(strBuilder);
            strBuilder.Append($" {ComparisonToken} ");
            RValue.ToString(strBuilder);
        }
    }
}
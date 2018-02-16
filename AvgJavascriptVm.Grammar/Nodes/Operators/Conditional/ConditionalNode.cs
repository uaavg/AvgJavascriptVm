using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ConditionalNode: ExpressionNode
    {
        public ExpressionNode Conditional { get; }

        public ExpressionNode TrueValue { get; }

        public ExpressionNode FalseValue { get; }

        public ConditionalNode(ExpressionNode conditional, ExpressionNode trueValue, ExpressionNode falseValue) 
        {
            Conditional = conditional;
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            Conditional.ToString(strBuilder);
            strBuilder.Append(" ? ");
            TrueValue.ToString(strBuilder);
            strBuilder.Append(" : ");
            FalseValue.ToString(strBuilder);
        }
    }
}
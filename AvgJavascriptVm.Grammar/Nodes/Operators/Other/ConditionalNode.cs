using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ConditionalNode: ExpressionNode
    {
        public ExpressionNode Condition { get; }

        public ExpressionNode TrueValue { get; }

        public ExpressionNode FalseValue { get; }

        public ConditionalNode(ExpressionNode condition, ExpressionNode trueValue, ExpressionNode falseValue) 
        {
            Condition = condition;
            TrueValue = trueValue;
            FalseValue = falseValue;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            Condition.ToString(strBuilder);
            strBuilder.Append(" ? ");
            TrueValue.ToString(strBuilder);
            strBuilder.Append(" : ");
            FalseValue.ToString(strBuilder);
        }
    }
}
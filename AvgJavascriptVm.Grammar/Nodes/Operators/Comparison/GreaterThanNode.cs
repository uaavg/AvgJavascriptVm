namespace AvgJavascriptVm.Grammar.Nodes
{
    public class GreaterThanNode: ComparisonNode
    {
        protected override string ComparisonToken { get; } = ">";

        public GreaterThanNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }
    }
}
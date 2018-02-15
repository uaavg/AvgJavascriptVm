namespace AvgJavascriptVm.Grammar.Nodes
{
    public class GreaterThanOrEqualNode: ComparisonNode
    {
        protected override string ComparisonToken { get; } = ">=";

        public GreaterThanOrEqualNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }        
    }
}
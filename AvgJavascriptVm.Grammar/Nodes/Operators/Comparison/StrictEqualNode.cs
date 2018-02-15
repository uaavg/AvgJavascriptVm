namespace AvgJavascriptVm.Grammar.Nodes
{
    public class StrictEqualNode: ComparisonNode
    {
        protected override string ComparisonToken { get; } = "===";

        public StrictEqualNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
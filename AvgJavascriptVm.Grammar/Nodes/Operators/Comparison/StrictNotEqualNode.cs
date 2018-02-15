namespace AvgJavascriptVm.Grammar.Nodes
{
    public class StrictNotEqualNode: ComparisonNode
    {
        protected override string ComparisonToken { get; } = "!==";

        public StrictNotEqualNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
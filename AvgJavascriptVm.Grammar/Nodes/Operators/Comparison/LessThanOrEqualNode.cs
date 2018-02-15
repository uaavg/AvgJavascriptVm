namespace AvgJavascriptVm.Grammar.Nodes
{
    public class LessThanOrEqualNode: ComparisonNode
    {
        protected override string ComparisonToken { get; } = "<=";

        public LessThanOrEqualNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }        
    }
}
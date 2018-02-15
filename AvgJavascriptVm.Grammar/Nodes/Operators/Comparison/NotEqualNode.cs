namespace AvgJavascriptVm.Grammar.Nodes
{
    public class NotEqualNode: ComparisonNode
    {
        protected override string ComparisonToken { get; } = "!=";

        public NotEqualNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
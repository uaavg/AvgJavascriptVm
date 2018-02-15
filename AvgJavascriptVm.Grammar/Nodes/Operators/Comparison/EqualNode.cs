namespace AvgJavascriptVm.Grammar.Nodes
{
    public class EqualNode: ComparisonNode
    {
        protected override string ComparisonToken { get; } = "==";

        public EqualNode(ExpressionNode lValue, ExpressionNode rValue):
            base(lValue, rValue)
        {
            
        }
    }
}
namespace AvgJavascriptVm.Grammar.Nodes
{
    public class LessThanNode: ComparisonNode
    {
        protected override string ComparisonToken { get; } = "<";

        public LessThanNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
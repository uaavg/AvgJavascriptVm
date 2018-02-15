namespace AvgJavascriptVm.Grammar.Nodes
{
    public class GreaterThanOrEqualNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = ">=";

        public GreaterThanOrEqualNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }        
    }
}
namespace AvgJavascriptVm.Grammar.Nodes
{
    public class StrictNotEqualNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "!==";

        public StrictNotEqualNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
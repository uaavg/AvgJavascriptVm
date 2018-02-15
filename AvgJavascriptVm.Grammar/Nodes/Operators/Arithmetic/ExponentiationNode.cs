namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ExponentiationNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "**";

        public ExponentiationNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }       
    }
}
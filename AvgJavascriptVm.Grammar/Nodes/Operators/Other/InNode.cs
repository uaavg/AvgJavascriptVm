namespace AvgJavascriptVm.Grammar.Nodes
{
    public class InNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "in";

        public InNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }

        
    }
}
namespace AvgJavascriptVm.Grammar.Nodes
{
    public class MultiplicationNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "*";

        public MultiplicationNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}
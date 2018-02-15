namespace AvgJavascriptVm.Grammar.Nodes
{
    public class GreaterThanNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = ">";

        public GreaterThanNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }
    }
}
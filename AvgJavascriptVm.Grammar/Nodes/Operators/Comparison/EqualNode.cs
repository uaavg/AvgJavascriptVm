namespace AvgJavascriptVm.Grammar.Nodes
{
    public class EqualNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "==";

        public EqualNode(ExpressionNode lValue, ExpressionNode rValue):
            base(lValue, rValue)
        {
            
        }
    }
}
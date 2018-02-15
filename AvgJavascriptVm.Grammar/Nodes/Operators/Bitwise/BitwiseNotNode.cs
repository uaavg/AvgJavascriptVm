namespace AvgJavascriptVm.Grammar.Nodes.Bitwise
{
    public class BitwiseNotNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "~";

        public BitwiseNotNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}
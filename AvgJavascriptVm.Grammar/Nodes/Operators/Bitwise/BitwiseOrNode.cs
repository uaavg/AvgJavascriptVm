namespace AvgJavascriptVm.Grammar.Nodes.Bitwise
{
    public class BitwiseOrNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "|";

        public BitwiseOrNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}
namespace AvgJavascriptVm.Grammar.Nodes
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
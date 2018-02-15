namespace AvgJavascriptVm.Grammar.Nodes.Bitwise
{
    public class BitwiseXorNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "^";

        public BitwiseXorNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}
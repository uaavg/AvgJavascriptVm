namespace AvgJavascriptVm.Grammar.Nodes
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
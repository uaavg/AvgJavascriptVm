namespace AvgJavascriptVm.Grammar.Nodes.Bitwise
{
    public class BitwiseAndNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "&";

        public BitwiseAndNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}
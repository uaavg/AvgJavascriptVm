namespace AvgJavascriptVm.Grammar.Nodes.Bitwise
{
    public class SignPropagatingRightShiftNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = ">>";

        public SignPropagatingRightShiftNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}
namespace AvgJavascriptVm.Grammar.Nodes
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
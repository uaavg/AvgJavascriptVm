namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ZeroFillRightShiftNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = ">>>";

        public ZeroFillRightShiftNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
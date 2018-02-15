namespace AvgJavascriptVm.Grammar.Nodes.Bitwise
{
    public class LeftShiftNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "<<";

        public LeftShiftNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
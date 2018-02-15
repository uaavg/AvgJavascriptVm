namespace AvgJavascriptVm.Grammar.Nodes
{
    public class LeftShiftNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "<<";

        public LeftShiftNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
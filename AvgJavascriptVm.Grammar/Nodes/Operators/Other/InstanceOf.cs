namespace AvgJavascriptVm.Grammar.Nodes
{
    public class InstanceOf: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "instanceof";

        public InstanceOf(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {
        }        
    }
}
namespace AvgJavascriptVm.Grammar.Nodes
{
    public class StrictEqualNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "===";

        public StrictEqualNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
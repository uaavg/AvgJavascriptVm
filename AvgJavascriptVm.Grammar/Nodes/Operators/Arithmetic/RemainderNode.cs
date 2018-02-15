namespace AvgJavascriptVm.Grammar.Nodes
{
    public class RemainderNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "%";

        public RemainderNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}
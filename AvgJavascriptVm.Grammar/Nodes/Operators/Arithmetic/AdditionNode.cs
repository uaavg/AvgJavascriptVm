namespace AvgJavascriptVm.Grammar.Nodes
{
    public class AdditionNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "+";

        public AdditionNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}
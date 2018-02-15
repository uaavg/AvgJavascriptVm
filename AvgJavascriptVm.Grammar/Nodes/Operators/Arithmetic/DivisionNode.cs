namespace AvgJavascriptVm.Grammar.Nodes
{
    public class DivisionNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "/";

        public DivisionNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }        
    }
}
namespace AvgJavascriptVm.Grammar.Nodes
{
    public class SubtractionNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "-";

        public SubtractionNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }        
    }
}
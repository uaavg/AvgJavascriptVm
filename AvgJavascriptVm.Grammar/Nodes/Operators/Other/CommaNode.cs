namespace AvgJavascriptVm.Grammar.Nodes
{
    public class CommaNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = ",";

        public CommaNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}

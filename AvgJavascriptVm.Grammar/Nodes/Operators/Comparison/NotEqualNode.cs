namespace AvgJavascriptVm.Grammar.Nodes
{
    public class NotEqualNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "!=";

        public NotEqualNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
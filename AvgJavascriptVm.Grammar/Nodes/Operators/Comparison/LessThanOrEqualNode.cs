namespace AvgJavascriptVm.Grammar.Nodes
{
    public class LessThanOrEqualNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "<=";

        public LessThanOrEqualNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }        
    }
}
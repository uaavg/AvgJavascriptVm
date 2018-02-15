namespace AvgJavascriptVm.Grammar.Nodes
{
    public class LessThanNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "<";

        public LessThanNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}
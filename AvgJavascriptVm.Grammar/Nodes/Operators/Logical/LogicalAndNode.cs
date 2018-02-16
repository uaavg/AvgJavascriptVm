namespace AvgJavascriptVm.Grammar.Nodes
{
    public class LogicalAndNode: BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "&&";

        public LogicalAndNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}
namespace AvgJavascriptVm.Grammar.Nodes
{
    public class LogicalOrNode : BinaryOperatorNode
    {
        protected override string OperatorToken { get; } = "||";

        public LogicalOrNode(ExpressionNode lValue, ExpressionNode rValue) :
            base(lValue, rValue)
        {

        }
    }
}
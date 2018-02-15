namespace AvgJavascriptVm.Grammar.Nodes
{
    public abstract class UnaryOperatorNode: ExpressionNode
    {
        public ExpressionNode Value { get; }

        protected UnaryOperatorNode(ExpressionNode value)
        {
            Value = value;
        }
    }
}
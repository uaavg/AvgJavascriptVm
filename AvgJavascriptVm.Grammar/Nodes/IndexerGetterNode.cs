using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class IndexerGetterNode: ExpressionNode
    {
        public ExpressionNode Value { get; }

        public ExpressionNode Index { get; }

        public IndexerGetterNode(ExpressionNode value, ExpressionNode index)
        {
            Value = value;
            Index = index;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            Value.ToString(strBuilder);
            strBuilder.Append("[");
            Index.ToString(strBuilder);
            strBuilder.Append("]");
        }
    }
}
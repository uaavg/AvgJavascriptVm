using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class BooleanNode: ExpressionNode
    {
        public bool Value { get; }

        public BooleanNode(bool value)
        {
            Value = value;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append(Value ? "true" : "false");
        }
    }
}
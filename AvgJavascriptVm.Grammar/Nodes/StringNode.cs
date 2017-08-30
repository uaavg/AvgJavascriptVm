using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class StringNode: ExpressionNode
    {
        public string String { get; }

        public StringNode(string @string)
        {
            String = @string;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            var preparedString = String.Replace("\r", "\\r").Replace("\n", "\\n").Replace("\v", "\\v");

            strBuilder.Append($"\"{preparedString}\"");
        }
    }
}
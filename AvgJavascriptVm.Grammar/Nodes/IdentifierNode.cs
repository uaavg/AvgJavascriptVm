using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class IdentifierNode: ExpressionNode
    {
        public IdentifierNode(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append(Name);
        }
    }
}
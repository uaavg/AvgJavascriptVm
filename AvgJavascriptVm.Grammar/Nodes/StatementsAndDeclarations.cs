using System.Collections.Generic;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class StatementsAndDeclarations: Node
    {
        public List<Node> Nodes { get; } = new List<Node>();

        public override void ToString(NodeStringBuilder strBuilder)
        {
            foreach (var node in Nodes)
            {
                node.ToString(strBuilder);
            }
        }
    }
}
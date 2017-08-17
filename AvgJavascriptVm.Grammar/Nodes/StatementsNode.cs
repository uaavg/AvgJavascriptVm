using System.Collections.Generic;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class StatementsNode: Node
    {
        public List<StatementNode> Statements { get; } = new List<StatementNode>();

        public override void ToString(NodeStringBuilder strBuilder)
        {
            foreach (var statement in Statements)
            {
                statement.ToString(strBuilder);
            }                       
        }
    }
}
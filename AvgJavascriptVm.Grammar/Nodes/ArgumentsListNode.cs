using System.Collections.Generic;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ArgumentsListNode: Node
    {
        public ArgumentsListNode()
        {
            
        }

        public ArgumentsListNode(IdentifierNode identifier)
        {
            Identifiers.Add(identifier);    
        }

        public ArgumentsListNode(ArgumentsListNode arguments, IdentifierNode identifier)
        {
            Identifiers.AddRange(arguments.Identifiers);
            Identifiers.Add(identifier);
        }
        
        public List<IdentifierNode> Identifiers { get; } = new List<IdentifierNode>();

        public override void ToString(NodeStringBuilder strBuilder)
        {
            for (int i = 0; i < Identifiers.Count; i++)
            {
                Identifiers[i].ToString(strBuilder);
                if (i != Identifiers.Count - 1)
                {
                    strBuilder.Append(", ");
                }
            }
        }
    }
}
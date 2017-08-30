using System.Collections.Generic;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class VariableDeclarationNode: Node
    {
        public List<VariableDeclarationIdentifierNode> Declarations { get; } = new List<VariableDeclarationIdentifierNode>();

        public VariableDeclarationNode(VariableDeclarationIdentifierNode declaration)
        {
            Declarations.Add(declaration);
        }
        
        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("var ");
            for (int i = 0; i < Declarations.Count; i++)
            {
                Declarations[i].ToString(strBuilder);
                if (i + 1 != Declarations.Count)
                {
                    strBuilder.Append(", ");
                }
            }
            strBuilder.Append(";");
        }
    }
}
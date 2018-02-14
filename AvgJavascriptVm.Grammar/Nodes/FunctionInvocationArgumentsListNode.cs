using System.Collections.Generic;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class FunctionInvocationArgumentsListNode: Node
    {
        public List<ExpressionNode> Arguments { get; } = new List<ExpressionNode>();

        public FunctionInvocationArgumentsListNode()
        {
            
        }

        public FunctionInvocationArgumentsListNode(ExpressionNode arg1)
        {
            Arguments.Add(arg1);
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            for (int i = 0; i < Arguments.Count; i++)
            {
                Arguments[i].ToString(strBuilder);
                if (i != Arguments.Count - 1)
                {
                    strBuilder.Append(", ");
                }
            }
        }
    }
}
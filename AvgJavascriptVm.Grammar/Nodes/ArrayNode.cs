using System.Collections.Generic;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ArrayNode: ExpressionNode
    {
        public List<ExpressionNode> Values { get; } = new List<ExpressionNode>();

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("[");
            for (int i = 0; i < Values.Count; i++)
            {
                Values[i].ToString(strBuilder);
                if (i + 1 != Values.Count)
                {
                    strBuilder.Append(", ");
                }
            }
            strBuilder.Append("]");
        }
    }
}
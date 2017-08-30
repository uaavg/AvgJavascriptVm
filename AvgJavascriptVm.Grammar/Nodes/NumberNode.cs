using System.Globalization;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class NumberNode: ExpressionNode
    {
        public double Number { get; }

        public NumberNode(double number)
        {
            Number = number;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append(Number.ToString(CultureInfo.InvariantCulture));
        }
    }
}
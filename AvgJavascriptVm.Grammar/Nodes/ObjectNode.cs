using System.Collections.Generic;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ObjectNode: ExpressionNode
    {
        public List<ObjectPropertyNode> Properties { get; }

        public ObjectNode(List<ObjectPropertyNode> properties)
        {
            Properties = properties ?? new List<ObjectPropertyNode>();
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("{ ");
            foreach (var property in Properties)
            {
                property.ToString(strBuilder);
                strBuilder.Append(", ");
            }
            strBuilder.Append(" }");
        }
    }
}
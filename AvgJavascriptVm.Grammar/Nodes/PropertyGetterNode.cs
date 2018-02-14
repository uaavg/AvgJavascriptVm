using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class PropertyGetterNode: ExpressionNode
    {
        public ExpressionNode This { get; }

        public IdentifierNode Property { get; }

        public PropertyGetterNode(ExpressionNode @this, IdentifierNode property)
        {
            This = @this;
            Property = property;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            This.ToString(strBuilder);
            strBuilder.Append(".");
            Property.ToString(strBuilder);
        }
    }
}
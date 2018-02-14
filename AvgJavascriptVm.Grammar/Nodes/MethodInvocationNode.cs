using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class MethodInvocationNode: FunctionInvocationNode
    {
        public ExpressionNode This { get; }

        public MethodInvocationNode(ExpressionNode @this, ExpressionNode function, FunctionInvocationArgumentsListNode arguments) : 
            base(function, arguments)
        {
            This = @this;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            This.ToString(strBuilder);
            strBuilder.Append(".");
            base.ToString(strBuilder);
        }
    }
}
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class FunctionInvocationNode : ExpressionNode
    {
        public ExpressionNode Function { get; }

        public FunctionInvocationArgumentsListNode Arguments { get; }

        public FunctionInvocationNode(ExpressionNode function, FunctionInvocationArgumentsListNode arguments)
        {
            Function = function;
            Arguments = arguments;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            Function.ToString(strBuilder);
            strBuilder.Append("(");
            Arguments.ToString(strBuilder);
            strBuilder.Append(")");
        }
    }
}
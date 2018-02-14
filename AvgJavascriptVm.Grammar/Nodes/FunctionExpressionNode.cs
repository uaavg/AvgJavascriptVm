using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class FunctionExpressionNode: ExpressionNode
    {
        public ArgumentsListNode Arguments { get; }

        public StatementsAndDeclarations Body { get; }

        public FunctionExpressionNode(ArgumentsListNode arguments, StatementsAndDeclarations body)
        {
            Arguments = arguments;
            Body = body;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("function (");
            Arguments.ToString(strBuilder);
            strBuilder.Append(") {");
            Body.ToString(strBuilder);
            strBuilder.Append("}");
        }
    }
}
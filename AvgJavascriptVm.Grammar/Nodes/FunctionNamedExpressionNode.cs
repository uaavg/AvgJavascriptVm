using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class FunctionNamedExpressionNode: FunctionExpressionNode
    {
        public IdentifierNode Name { get; }

        public FunctionNamedExpressionNode(IdentifierNode name, ArgumentsListNode arguments, StatementsAndDeclarations body) : base(arguments, body)
        {
            Name = name;
        }
        
        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append($"function {Name}(");
            Arguments.ToString(strBuilder);
            strBuilder.Append(") {");
            Body.ToString(strBuilder);
            strBuilder.Append("}");
        }
    }
}
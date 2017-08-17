using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class FunctionNode: StatementNode
    {
        public IdentifierNode Name { get; }

        public ArgumentsListNode Arguments { get; }

        public BlockNode Body { get; }

        public FunctionNode(IdentifierNode name, ArgumentsListNode arguments, BlockNode body)
        {
            Name = name;
            Arguments = arguments;
            Body = body;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append($"function {Name}(");
            Arguments.ToString(strBuilder);
            strBuilder.Append(")");
            Body.ToString(strBuilder);            
        }
    }
}
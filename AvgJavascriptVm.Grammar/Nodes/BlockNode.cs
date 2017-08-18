using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class BlockNode : StatementNode
    {
        public BlockNode()
        {
            
        }

        public BlockNode(StatementsNode statements)
        {
            Statements = statements;
        }

        public StatementsNode Statements { get; }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            var isMultiLine = Statements?.Statements?.Count > 0;

            strBuilder.Append("{");
            if (isMultiLine)
            {
                strBuilder.AppendLine();
            }
            using (strBuilder.Indent())
            {
                Statements?.ToString(strBuilder);
            }
            if (isMultiLine)
            {
                strBuilder.AppendLine("}");
            }
            else
            {
                strBuilder.Append("}");
            }                      
        }
    }
}
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ForNode: StatementNode
    {
        public StatementNode Initialization { get; }

        public StatementNode Condition { get; }

        public StatementNode Final { get; }

        public StatementNode Block { get; }

        public ForNode(StatementNode initialization, StatementNode condition, StatementNode final, StatementNode block)
        {
            Initialization = initialization;
            Condition = condition;
            Final = final;
            Block = block;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            strBuilder.Append("for(");
            Initialization?.ToString(strBuilder);
            strBuilder.Append(";");
            Condition?.ToString(strBuilder);
            strBuilder.Append(";");
            Final?.ToString(strBuilder);
            strBuilder.Append(")");
            if (Block == null)
            {
                strBuilder.Append(";");
            }
            else
            {
                Block.ToString(strBuilder);
            }
            
        }
    }
}
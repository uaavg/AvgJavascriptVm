using AvgJavascriptVm.Grammar.Helpers;
// ReSharper disable UnusedMember.Local

namespace AvgJavascriptVm.Grammar.Nodes
{
    public abstract class Node
    {
        public abstract void ToString(NodeStringBuilder strBuilder);

        public int Line { get; private set; }

        public int Column { get; private set; }

        public override string ToString()
        {
            var strBuilder = new NodeStringBuilder();

            ToString(strBuilder);
            return strBuilder.ToString();
        }

        public void SetLocation(int line, int column)
        {
            if (Line == 0)
            {
                Line = line;
                Column = column;
            }
        }

        private string NodeType => GetType().Name;

        private string DebugView => ToString();
    }
}

using AvgJavascriptVm.Grammar.Helpers;

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

        // ReSharper disable once UnusedMember.Local
        private string DebugView => ToString();        
    }
}

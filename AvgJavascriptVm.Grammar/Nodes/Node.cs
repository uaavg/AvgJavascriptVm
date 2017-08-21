using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public abstract class Node
    {
        public abstract void ToString(NodeStringBuilder strBuilder);

        public override string ToString()
        {
            var strBuilder = new NodeStringBuilder();            

            ToString(strBuilder);
            return strBuilder.ToString();
        }

        // ReSharper disable once UnusedMember.Local
        private string DebugView => ToString();
    }
}

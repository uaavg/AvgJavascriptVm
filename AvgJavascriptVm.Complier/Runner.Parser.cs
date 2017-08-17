using System.IO;
using System.Text;
using AvgJavascriptVm.Core.Infrastructure;
using AvgJavascriptVm.Grammar.Nodes;

namespace AvgJavascriptVm.Complier
{
    internal partial class RunnerParser
    {
        public GlobalScope GlobalEnvironment { get; }

        public StatementsNode Result { get; private set; }

        public RunnerParser(GlobalScope globalEnvironment) : base(null)
        {
            GlobalEnvironment = globalEnvironment;
        }

        public void Parse(string s)
        {
            byte[] inputBuffer = Encoding.Default.GetBytes(s);
            var stream = new MemoryStream(inputBuffer);
            Scanner = new RunnerScanner(stream);
            Parse();
        }
    }
}

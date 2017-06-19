using System.IO;
using System.Text;

namespace AvgJavascriptVm.Complier
{
    internal partial class RunnerParser
    {
        public RunnerParser() : base(null) { }

        public void Parse(string s)
        {
            byte[] inputBuffer = Encoding.Default.GetBytes(s);
            var stream = new MemoryStream(inputBuffer);
            Scanner = new RunnerScanner(stream);
            Parse();
        }
    }
}

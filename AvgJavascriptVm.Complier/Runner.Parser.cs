using System.Collections.Generic;
using System.IO;
using System.Text;
using AvgJavascriptVm.Core.Infrastructure;
using AvgJavascriptVm.Grammar.Nodes;

namespace AvgJavascriptVm.Complier
{
    internal partial class RunnerParser
    {
        public GlobalScope GlobalEnvironment { get; }

        public StatementsAndDeclarations Result { get; private set; }

        public RunnerParser(GlobalScope globalEnvironment) : base(null)
        {
            InitAliases();
            GlobalEnvironment = globalEnvironment;
        }

        public void Parse(string s)
        {
            byte[] inputBuffer = Encoding.Default.GetBytes(s);
            var stream = new MemoryStream(inputBuffer);
            Scanner = new RunnerScanner(stream);
            Parse();
        }

        private static void InitAliases()
        {
            if (aliases != null)
            {
                return;
            }
            aliases = new Dictionary<int, string>
            {
                [(int)Token.FUNCTION] = "'function'",
                [(int)Token.IF] = "'if'",
                [(int)Token.ELSE] = "'else'",
                [(int)Token.WHILE] = "'while'",
                [(int)Token.DO] = "'do'",
                [(int)Token.FOR] = "'for'",
                [(int)Token.RETURN] = "'return'",
                [(int)Token.SEMICOLON] = "';'",
                [(int)Token.COMMA] = "','",
                [(int)Token.LPARENTH] = "'('",
                [(int)Token.RPARENTH] = "')'",
                [(int)Token.LCURLYBRACE] = "'('",
                [(int)Token.RCURLYBRACE] = "')'",
                [(int)Token.NUMBER] = "number",
                [(int)Token.IDENTIFIER] = "identifier",                
            };
        }
    }
}

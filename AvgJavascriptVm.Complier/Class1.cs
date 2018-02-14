using System;
using System.IO;
using System.Text;
using AvgJavascriptVm.Core.Infrastructure;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Complier
{
    public class Class1
    {
        public static void Test()
        {
            var text = File.ReadAllText(@"C:\temp\test.js");
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));
            var parser = new RunnerParserWithLocation(new GlobalScope());

            parser.Parse(text);
            parser.Result.ToString(new NodeStringBuilder());
        }
    }
}
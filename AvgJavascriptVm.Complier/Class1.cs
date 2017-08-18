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
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));
            var parser = new RunnerParser(new GlobalScope());

   
            parser.Parse("function test(a, b, c) { while(true) { for(;b;) { do { } while(false); } } return; }");
            parser.Result.ToString(new NodeStringBuilder());
        }
    }
}

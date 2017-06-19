using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvgJavascriptVm.Complier
{
    public class Class1
    {
        public static void Test()
        {
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));
            var parser = new RunnerParser();

            parser.Parse("functiona");
        }
    }
}

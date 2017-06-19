using System;
using AvgJavascriptVm.Core.BaseTypes;

namespace AvgJavascriptVm.Complier
{
    internal partial class RunnerScanner
    {
        void GetNumber()
        {
            yylval.v = new JsNumber(double.Parse(yytext));            
        }

        void GetIdentifier()
        {
            yylval.v = new JsString(yytext);
        }

		public override void yyerror(string format, params object[] args)
		{
			base.yyerror(format, args);
			Console.WriteLine(format, args);
			Console.WriteLine();
		}
    }
}

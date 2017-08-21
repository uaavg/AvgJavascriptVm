using System;

namespace AvgJavascriptVm.Complier
{
    internal partial class RunnerScanner
    {
        void GetNumber()
        {
            yylval.num = double.Parse(yytext);            
        }

        void GetIdentifier()
        {
            yylval.str = yytext;
        }

		public override void yyerror(string format, params object[] args)
		{
            base.yyerror(format, args);
			Console.WriteLine($"Line: {yyline} Column: {yycol} {string.Format(format, args)}");			
		}
    }
}

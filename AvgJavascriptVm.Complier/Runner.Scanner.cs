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
			LogError(string.Format(format, args), yyline, yycol);			
		}

        public void LogError(string message, int line, int col)
        {
            Console.WriteLine($"Line: {line} Column: {col} {message}");
        }
    }
}

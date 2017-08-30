using System;
using System.Collections.Generic;
using System.Text;

namespace AvgJavascriptVm.Complier
{
    internal partial class RunnerScanner
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        private readonly static Dictionary<string, char> EscapedSymbols  = new Dictionary<string, char>
        {
            ["\\b"] = '\b',
            ["\\t"] = '\t',
            ["\\n"] = '\n',
            ["\\v"] = '\v',
            ["\\f"] = '\f',
            ["\\r"] = '\r',
            ["\\\""] = '"',
            ["\\'"] = '\'',
            ["\\\\"] = '\\'
        };

        private StringType _stringType;

        void GetNumber()
        {
            yylval.num = double.Parse(yytext);            
        }

        void GetIdentifier()
        {
            yylval.str = yytext;
        }

        void BeginString()
        {
            BEGIN(STRING);
            SetStringType();
            _stringBuilder.Clear();
        }

        bool AppendString()
        {
            if (IsStringEnd())
            {
                EndString();
                return true;
            }
            _stringBuilder.Append(yytext);
            return false;
        }

        void AppendStringEscapedSymbol()
        {
            if (!EscapedSymbols.TryGetValue(yytext, out var symbol))
            {
                throw new ApplicationException($"Unknown escaped symbol {yytext}");
            }
            _stringBuilder.Append(symbol);
        }

        void AppendStringUnicodeSymbol()
        {
            var hexStr = yytext.Substring(2, 4);
            var symbol = (char)Convert.ToInt16(hexStr, 16);

            _stringBuilder.Append(symbol);
        }

        void EndString()
        {
            yylval.str = _stringBuilder.ToString();
            BEGIN(INITIAL);
        }

        void SetStringType()
        {
            if (yytext == "'")
            {
                _stringType = StringType.Single;
            }
            else if (yytext == "\"")
            {
                _stringType = StringType.Double;
            }
        }

        bool IsStringEnd()
        {
            if (_stringType == StringType.Single && yytext == "'")
            {
                return true;
            }
            if (_stringType == StringType.Double && yytext == "\"")
            {
                return true;
            }
            return false;
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

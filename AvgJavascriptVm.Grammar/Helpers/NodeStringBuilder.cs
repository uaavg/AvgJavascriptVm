using System;
using System.Text;

namespace AvgJavascriptVm.Grammar.Helpers
{
    public class NodeStringBuilder: IDisposable
    {
        private int _indent;

        private readonly StringBuilder _strBuilder = new StringBuilder();

        private bool _isNewLine = true;

        public IDisposable Indent()
        {
            _indent++;
            return this;
        }

        void IDisposable.Dispose()
        {
            _indent--;
        }

        public void Append(string str)
        {
            if (_isNewLine)
            {
                _strBuilder.Append(GetIndentString());
            }
            _isNewLine = false;
            _strBuilder.Append(str);
        }

        public void AppendLine(string line)
        {
            if (!_isNewLine)
            {
                _strBuilder.AppendLine();
            }
            _isNewLine = true;
            _strBuilder.AppendLine(GetIndentString() + line);            
        }

        public void AppendLine()
        {
            _strBuilder.AppendLine();
            _isNewLine = true;
        }

        public override string ToString()
        {
            return _strBuilder.ToString();
        }

        private string GetIndentString()
        {
            return new string(' ', _indent);
        }
    }
}
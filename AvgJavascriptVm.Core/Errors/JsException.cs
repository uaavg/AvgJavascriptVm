using System;

namespace AvgJavascriptVm.Core.Errors
{
    public class JsException: ApplicationException
    {
        public JsException(string message): base(message)
        {
            
        }
    }
}
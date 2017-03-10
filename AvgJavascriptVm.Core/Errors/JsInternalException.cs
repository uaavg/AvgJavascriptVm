using System;

namespace AvgJavascriptVm.Core.Errors
{
    public class JsInternalException: JsException
    {
        public JsInternalException(string messge): base(messge)
        {
            
        }
    }
}
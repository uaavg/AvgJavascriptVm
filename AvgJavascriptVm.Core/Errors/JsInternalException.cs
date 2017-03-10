using System;

namespace AvgJavascriptVm.Core.Errors
{
    public class JsInternalException: ApplicationException
    {
        public JsInternalException(string messge): this(messge)
        {
            
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace AvgJavascriptVm.Core.Values
{
    public class JsArray: JsObject
    {
        public List<JsValue> Values { get; } = new List<JsValue>();

        public override JsString AsString()
        {
            if (Values.Count == 0)
            {
                return JsString.Empty;
            }
            return string.Join(",", Values.Select(v => v.AsString()));
        }

        public override JsNumber AsNumber()
        {
            return Values.Count == 0 ? 0 : Values[0].AsNumber();
        }        
    }
}
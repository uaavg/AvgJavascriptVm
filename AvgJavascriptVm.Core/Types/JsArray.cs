using System.Linq;
using AvgJavascriptVm.Core.BaseTypes;
using AvgJavascriptVm.Core.Integration;

namespace AvgJavascriptVm.Core.Types
{
    public class JsArray: JsNativeType
    {
        public JsArray(JsValue[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                This.SetProperty(i.ToString(), values[i]);
            }
        }

        [JsNativeMethod(Name = "toString")]
        public JsValue JsToString()
        {
            if (!This.Properties.Any())
            {
                return JsString.Empty;
            }
            return new JsString(string.Join(",", This.Properties.Select(p => p.Value.AsString())));
        }

        [JsNativeMethod]
        public JsValue ValueOf()
        {
            if (!This.Properties.Any())
            {
                return new JsNumber(0);
            }
            if (This.HasProperty("0"))
            {
                return This.GetProperty("0").AsNumber();
            }
            return JsNumber.NaN;
        }
    }
}
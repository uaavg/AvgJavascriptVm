using System.Linq;
using AvgJavascriptVm.Core.BaseTypes;
using AvgJavascriptVm.Core.Infrastructure;

namespace AvgJavascriptVm.Core.Types
{
    public class JsArray: JsObject
    {
        public JsArray(LexicalEnvironment lexEnv) : base(lexEnv)
        {
            
        }

        public JsArray(JsValue[] values, LexicalEnvironment lexEnv): base(lexEnv)
        {
            for (int i = 0; i < values.Length; i++)
            {
                SetProperty(i.ToString(), values[i]);
            }
        }

        [JsMethod(Name = "toString")]
        public JsValue JsToString(LexicalEnvironment lexEnv)
        {
            if (Properties.Any())
            {
                return JsString.Empty;
            }
            return new JsString(string.Join(",", Properties.Select(p => p.Value.AsString())));
        }

        [JsMethod(Name = "valueOf")]
        private JsValue ValueOf()
        {
            if (!Properties.Any())
            {
                return new JsNumber(0);
            }
            if (HasProperty("0"))
            {
                return GetProperty("0").AsNumber();
            }
            return JsNumber.NaN;
        }
    }
}
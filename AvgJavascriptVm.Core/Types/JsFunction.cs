using System;
using AvgJavascriptVm.Core.BaseTypes;
using AvgJavascriptVm.Core.Integration;

namespace AvgJavascriptVm.Core.Types
{
    public class JsFunction: JsNativeType
    {
        public static JsFunction Empty { get; } = new JsFunction((t, a) => { }, null, new JsObject());

        public Action<JsValue /* this */, JsValue[] /* parameters */> Action { get; }

        public JsObject Scope { get; }

        public string[] Parameters { get; }

        public JsFunction(Action<JsValue, JsValue[]> action, string[] parameters, JsObject scope)
        {
            Action = action;
            Scope = scope ?? new JsObject();
            Parameters = parameters ?? new string[0];        
        }

        public JsValue Call(JsValue @this, params JsValue[] parameters)
        {
            throw new NotImplementedException();
        }

        [JsNativeMethod(Name = "toString")]
        public JsValue JsToString()
        {
            return new JsString("function");
        }
    }
}
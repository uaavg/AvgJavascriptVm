using System;

namespace AvgJavascriptVm.Core.Values
{
    public class JsFunction: JsObject
    {
        public Action<JsValue /* this */, JsValue[] /* parameters */> Action { get; }

        public JsObject Scope { get; }

        public string[] Parameters { get; }

        public string Body { get; }

        public string Name { get; }

        public JsFunction(Action<JsValue, JsValue[]> action, string[] parameters, JsObject scope, string name = null, string body = null)
        {
            Action = action;
            Scope = scope;
            Parameters = parameters;
            Body = body;
            Name = name;
        }

        public override JsString AsString()
        {
            if (Body == null)
            {
                return $"function {Name}({string.Join(",", Parameters)})" + "{ [native code] }";
            }
            return Body;
        }
    }
}
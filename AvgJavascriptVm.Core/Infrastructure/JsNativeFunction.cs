using System;
using AvgJavascriptVm.Core.BaseTypes;

namespace AvgJavascriptVm.Core.Infrastructure
{
    public class JsNativeFunction: JsFunction
    {
        private readonly Func<LexicalEnvironment, JsValue> _action;

        public override string[] Parameters { get; } = new string[0];        

        public JsNativeFunction(Func<LexicalEnvironment, JsValue> action, string name, LexicalEnvironment lexEnvironment) : base(lexEnvironment)
        {
            _action = action;                        
            SetProperty("name", new JsString(name));
        }

        protected override JsValue CallInternal(LexicalEnvironment lexEnvironment)
        {
            return _action(lexEnvironment);
        }

        [JsMethod(Name = "toString")]
        public static JsValue JsToString(LexicalEnvironment lexEnv)
        {
            return new JsString("function () { [native code] }");
        }
    }
}
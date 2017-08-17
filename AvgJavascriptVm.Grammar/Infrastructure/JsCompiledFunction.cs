using System;
using AvgJavascriptVm.Core.BaseTypes;
using AvgJavascriptVm.Core.Infrastructure;

namespace AvgJavascriptVm.Grammar.Infrastructure
{
    public class JsCompiledFunction : JsFunction
    {
        public JsCompiledFunction(LexicalEnvironment lexEnv, string[] parameters) : base(lexEnv)
        {
            Parameters = parameters;
        }

        public override string[] Parameters { get; }

        protected override JsValue CallInternal(LexicalEnvironment env)
        {
            throw new NotImplementedException();
        }
    }
}
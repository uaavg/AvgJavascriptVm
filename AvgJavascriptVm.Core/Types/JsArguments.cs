using AvgJavascriptVm.Core.BaseTypes;
using AvgJavascriptVm.Core.Infrastructure;

namespace AvgJavascriptVm.Core.Types
{
    public class JsArguments: JsObject
    {
        public int Length { get; }

        public JsArguments(LexicalEnvironment lexEnv, JsValue[] arguments) : base(lexEnv)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                SetProperty(i.ToString(), arguments[i]);
            }
            Length = arguments.Length;
        }               
    }
}
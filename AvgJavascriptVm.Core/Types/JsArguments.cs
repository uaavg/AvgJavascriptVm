using AvgJavascriptVm.Core.BaseTypes;
using AvgJavascriptVm.Core.Integration;

namespace AvgJavascriptVm.Core.Types
{
    public class JsArguments: JsNativeType
    {
        private readonly JsNumber _length;

        public JsArguments(JsValue[] parameters)
        {
            _length = parameters.Length;
            for (int i = 0; i < parameters.Length; i++)
            {
                This.SetProperty(i.ToString(), parameters[i]);
            }
        }

        [JsNativeProperty]
        public JsValue Length => new JsNumber(_length);
    }
}
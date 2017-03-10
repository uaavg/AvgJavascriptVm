using AvgJavascriptVm.Core.Errors;

namespace AvgJavascriptVm.Core.BaseTypes
{
    public sealed class JsUndefined: JsValue
    {
        public static JsUndefined Instance = new JsUndefined();

        public override JsString AsString()
        {
            return new JsString("undefined");
        }

        public override JsNumber AsNumber()
        {
            return JsNumber.NaN;
        }

        public override JsBoolean AsBoolean()
        {
            return false;
        }

        public override JsObject AsObject()
        {
            throw new JsTypeErrorException("undefined");
        }
    }
}
using AvgJavascriptVm.Core.Errors;

namespace AvgJavascriptVm.Core.BaseTypes
{
    public sealed class JsNull: JsValue
    {
        public static JsNull Instance = new JsNull();

        private JsNull()
        {
            
        }

        public override JsString AsString()
        {
            return "null";
        }

        public override JsNumber AsNumber()
        {
            return 0;
        }

        public override JsBoolean AsBoolean()
        {
            return false;
        }

        public override JsObject AsObject()
        {
            throw new JsTypeErrorException("null");
        }
    }
}
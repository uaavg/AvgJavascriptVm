using AvgJavascriptVm.Core.Errors;

namespace AvgJavascriptVm.Core.BaseTypes
{
    public sealed class JsBoolean: JsValue
    {
        public static JsBoolean True = new JsBoolean(true);

        public static JsBoolean False = new JsBoolean(false);

        public bool Value { get;  }

        public JsBoolean(bool value)
        {
            Value = value;
        }

        public override JsString AsString()
        {
            return Value ? "true" : "false";
        }

        public override JsNumber AsNumber()
        {
            return Value ? 1 : 0;
        }

        public override JsBoolean AsBoolean()
        {
            return Value;
        }

        public override JsObject AsObject()
        {
            throw new JsNotImplementedException();
        }

        public static implicit operator JsBoolean(bool value)
        {
            return value ? True : False;
        }

        public static implicit operator bool(JsBoolean jsBool)
        {
            return jsBool.Value;
        }        
    }
}
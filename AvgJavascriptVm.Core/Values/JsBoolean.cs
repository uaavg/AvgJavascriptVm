namespace AvgJavascriptVm.Core.Values
{
    public class JsBoolean: JsValue
    {
        public static JsBoolean True = new JsBoolean(true);

        public static JsBoolean False = new JsBoolean(false);

        public bool Value { get;  }

        private JsBoolean(bool value)
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

        public override JsString TypeOf()
        {
            return "boolean";
        }

        public override JsBoolean AsBoolean()
        {
            return Value;
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
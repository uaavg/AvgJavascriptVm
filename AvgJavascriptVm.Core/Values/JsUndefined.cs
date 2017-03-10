namespace AvgJavascriptVm.Core.Values
{
    public class JsUndefined: JsValue
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

        public override JsString TypeOf()
        {
            return "undefined";
        }
    }
}
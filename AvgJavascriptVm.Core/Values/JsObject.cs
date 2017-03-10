namespace AvgJavascriptVm.Core.Values
{
    public class JsObject: JsValue
    {
        public JsObject Prototype { get; set; }

        public JsObject(JsObject prototype)
        {
            Prototype = prototype;
        }

        public JsObject()
        {
            Prototype = new JsObject(null);
        }

        public override JsString AsString()
        {
            return "[object Object]";
        }

        public override JsNumber AsNumber()
        {
            return JsNumber.NaN;
        }

        public override JsBoolean AsBoolean()
        {
            return true;
        }

        public override JsString TypeOf()
        {
            return "object";
        }
    }
}
namespace AvgJavascriptVm.Core.Values
{
    public abstract class JsValue
    {
        public abstract JsString AsString();

        public abstract JsNumber AsNumber();

        public abstract JsBoolean AsBoolean();

        public abstract JsString TypeOf();
    }
}
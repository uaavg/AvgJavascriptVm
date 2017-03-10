namespace AvgJavascriptVm.Core.BaseTypes
{
    public abstract class JsValue
    {
        public abstract JsString AsString();

        public abstract JsNumber AsNumber();

        public abstract JsBoolean AsBoolean();

        public abstract JsObject AsObject();
    }
}
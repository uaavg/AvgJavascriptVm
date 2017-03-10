namespace AvgJavascriptVm.Core.Values
{
    public class JsNull: JsValue
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

        public override JsString TypeOf()
        {
            return "object";
        }        
    }
}
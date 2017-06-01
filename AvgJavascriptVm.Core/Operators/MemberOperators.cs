using AvgJavascriptVm.Core.BaseTypes;

namespace AvgJavascriptVm.Core.Operators
{
    public static partial class Operators
    {
        public static JsValue GetMember(this JsValue obj, JsValue memberName)
        {
            return obj.AsObject().GetProperty(memberName.AsString());
        }

        public static JsValue SetMember(this JsValue obj, string memberName, JsValue value)
        {
            obj.AsObject().SetProperty(memberName, value);
            return value;
        }        
    }
}
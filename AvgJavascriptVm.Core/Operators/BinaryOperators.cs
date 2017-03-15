using AvgJavascriptVm.Core.BaseTypes;

namespace AvgJavascriptVm.Core.Operators
{
    public static class BinaryOperators
    {
        public static JsValue GetMember(this JsValue obj, JsValue memberName)
        {
            return obj.AsObject().GetProperty(memberName.AsString());
        }       
    }
}
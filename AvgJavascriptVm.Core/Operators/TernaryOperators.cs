using AvgJavascriptVm.Core.BaseTypes;

namespace AvgJavascriptVm.Core.Operators
{
    public static class TernaryOperators
    {
        public static JsValue SetMember(this JsValue obj, string memberName, JsValue value)
        {
            obj.AsObject().SetProperty(memberName, value);
            return value;
        }
    }
}
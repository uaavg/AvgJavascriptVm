namespace AvgJavascriptVm.Core.Errors
{
    public class JsTypeErrorException: JsException
    {
        public JsTypeErrorException(string type) : base($"{type} is not expected")
        {

        }
    }
}
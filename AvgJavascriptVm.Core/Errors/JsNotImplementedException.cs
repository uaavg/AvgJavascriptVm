namespace AvgJavascriptVm.Core.Errors
{
    public class JsNotImplementedException: JsException
    {
        public JsNotImplementedException() : base("Feature is not implemented yet")
        {
        }
    }
}
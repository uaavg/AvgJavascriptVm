namespace AvgJavascriptVm.Core.Errors
{
    public class JsIsNotDefinedException: JsException
    {
        public JsIsNotDefinedException(string variable) : base($"{variable} is not defined")
        {
        }
    }
}
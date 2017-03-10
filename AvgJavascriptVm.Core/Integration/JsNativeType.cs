using AvgJavascriptVm.Core.BaseTypes;

namespace AvgJavascriptVm.Core.Integration
{
    public abstract class JsNativeType
    {
        protected JsObject This { get; }

        public JsNativeType()
        {
            This = new JsObject();
        }

        public virtual void Constructor(JsValue[] parameters)
        {
            
        }
    }
}
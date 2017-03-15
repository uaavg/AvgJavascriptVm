using AvgJavascriptVm.Core.BaseTypes;

namespace AvgJavascriptVm.Core.Infrastructure
{
    public class JsProperty
    {
        public JsProperty(JsObject @this)
        {
            This = @this;
        }

        public JsObject This { get; }

        public JsFunction Getter { get; set; }

        public JsFunction Setter { get; set; }

        public JsValue RawValue { get; set; }

        public JsValue Value
        {
            get
            {
                return Getter == null ? RawValue : Getter.Call(This);
            }
            set
            {
                if (Setter == null)
                {
                    RawValue = value;
                }
                else
                {
                   Setter.Call(This, value);
                }
            }
        }
        
                
    }
}
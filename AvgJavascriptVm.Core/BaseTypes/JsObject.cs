using System.Collections.Generic;
using AvgJavascriptVm.Core.Infrastructure;

namespace AvgJavascriptVm.Core.BaseTypes
{
    public sealed class JsObject: JsValue
    {
        public JsObject Prototype { get; set; }

        private Dictionary<string, JsProperty> _properties { get; } = new Dictionary<string, JsProperty>();

        public JsObject(JsObject prototype)
        {
            Prototype = prototype;
        }

        public JsObject()
        {
            Prototype = new JsObject(null);
        }

        public override JsString AsString()
        {
            return "[object Object]";
        }

        public override JsNumber AsNumber()
        {
            return JsNumber.NaN;
        }

        public override JsBoolean AsBoolean()
        {
            return true;
        }

        public override JsObject AsObject()
        {
            return this;
        }

        public bool HasProperty(string propertyName)
        {
            return _properties.ContainsKey(propertyName);
        }

        public JsValue GetProperty(string propertyName)
        {
            JsProperty prop;

            if (_properties.TryGetValue(propertyName, out prop))
            {
                return prop.Value;
            }
            return JsUndefined.Instance;
        }

        public void SetProperty(string propertyName, JsValue value)
        {
            JsProperty prop;

            if (!_properties.TryGetValue(propertyName, out prop))
            {
                prop = new JsProperty(this);
                _properties.Add(propertyName, prop);
            }
            prop.Value = value;
        }

        public IEnumerable<JsProperty> Properties => _properties.Values;        
    }
}
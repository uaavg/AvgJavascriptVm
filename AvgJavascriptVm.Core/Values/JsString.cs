using System.Globalization;

namespace AvgJavascriptVm.Core.Values
{
    public class JsString: JsValue
    {
        public static JsString Empty = new JsString("");

        public string Value { get; }

        public JsString(string value)
        {
            Value = value;
        }

        public override JsString AsString()
        {
            return this;
        }

        public override JsNumber AsNumber()
        {
            if (Value.Length == 0) return 0;

            int parsed;

            if (int.TryParse(Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out parsed))
            {
                return parsed;
            }
            return JsNumber.NaN;
        }

        public override JsBoolean AsBoolean()
        {
            return Value.Length != 0;
        }

        public override JsString TypeOf()
        {
            return "string";
        }

        public static implicit operator JsString(string value)
        {
            return new JsString(value);
        }

        public static implicit operator string(JsString jsStr)
        {
            return jsStr.Value;
        }
    }
}
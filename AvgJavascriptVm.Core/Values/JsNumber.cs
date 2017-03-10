using System.Globalization;

namespace AvgJavascriptVm.Core.Values
{
    public class JsNumber: JsValue
    {
        public static JsNumber NaN = new JsNumber(double.NaN);

        public static JsNumber PostiveInfinity = new JsNumber(double.PositiveInfinity);

        public static JsNumber NegativeInfinity = new JsNumber(double.NegativeInfinity);

        public double Value { get; }

        public JsNumber(double value)
        {
            Value = value;
        }

        public override JsString AsString()
        {
            return new JsString(Value.ToString(CultureInfo.InvariantCulture));
        }

        public override JsNumber AsNumber()
        {
            return this;
        }

        public override JsBoolean AsBoolean()
        {
            return ((int) Value) != 0;
        }

        public override JsString TypeOf()
        {
            return "number";
        }

        public static implicit operator JsNumber(double value)
        {
            return new JsNumber(value);
        }

        public static implicit operator double(JsNumber jsNum)
        {
            return jsNum.Value;
        }
    }
}
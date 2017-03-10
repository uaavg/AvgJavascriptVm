using System.Globalization;
using AvgJavascriptVm.Core.Errors;

namespace AvgJavascriptVm.Core.BaseTypes
{
    public sealed class JsNumber: JsValue
    {
        public static JsNumber NaN { get; } = new JsNumber(double.NaN);

        public static JsNumber PostiveInfinity { get; } = new JsNumber(double.PositiveInfinity);

        public static JsNumber NegativeInfinity { get;  } = new JsNumber(double.NegativeInfinity);

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

        public override JsObject AsObject()
        {
            throw new JsNotImplementedException();
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
using System;
using System.Net;
using AvgJavascriptVm.Core.BaseTypes;
using AvgJavascriptVm.Core.Errors;

namespace AvgJavascriptVm.Core.Operators
{
    public static partial class Operators
    {
        public static JsValue Delete(JsValue val)
        {
            throw new NotImplementedException();
        }
        
        public static JsValue TypeOf(JsValue val)
        {
            if (val is JsUndefined)
            {
                return new JsString("undefined");
            }
            if (val is JsNull)
            {
                return new JsString("object");
            }
            if (val is JsBoolean)
            {
                return new JsString("boolean");
            }
            if (val is JsString)
            {
                return new JsString("string");
            }
            if (val is JsFunction)
            {
                return new JsString("function");
            }
            if (val is JsObject)
            {
                return new JsString("object");
            }

            throw new JsInternalException("Unexpected type for typeof operator");
        }

        public static JsValue PreIncrement(ref JsValue val)
        {
            val = new JsNumber(val.AsNumber().Value + 1);
            return val;
        }

        public static JsValue PostIncrement(ref JsValue val)
        {
            var prev = val.AsNumber();

            val = new JsNumber(prev.Value + 1);
            return prev;
        }

        public static JsValue PreDecrement(ref JsValue val)
        {
            val = new JsNumber(val.AsNumber().Value - 1);
            return val;
        }

        public static JsValue PostDecrement(ref JsValue val)
        {
            var prev = val.AsNumber();

            val = new JsNumber(prev.Value - 1);
            return prev;
        }

        public static JsValue UnaryPlus(JsValue val)
        {
            return val.AsNumber();
        }

        public static JsValue UnaryMinus(JsValue val)
        {
            return new JsNumber(-val.AsNumber().Value);
        }

        public static JsValue BitwiseNot(JsValue val)
        {
            return new JsNumber(~val.AsNumber().ToInt32());
        }

        public static JsValue LogicalNot(JsValue val)
        {
            return new JsBoolean(!val.AsBoolean().Value);
        }
    }
}

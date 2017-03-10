using System;

namespace AvgJavascriptVm.Core.Integration
{
    [AttributeUsage(AttributeTargets.Method)]
    public class JsNativeMethodAttribute: Attribute
    {
        public string Name { get; set; }
    }
}
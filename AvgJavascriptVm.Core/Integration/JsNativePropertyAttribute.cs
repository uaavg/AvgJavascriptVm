using System;

namespace AvgJavascriptVm.Core.Integration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class JsNativePropertyAttribute: Attribute
    {
        public string Name { get; set; }
    }
}
using System;

namespace AvgJavascriptVm.Core.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class JsPropertyAttribute: Attribute
    {
        public string Name { get; set; }

        public bool IsInline { get; set; } = false;
    }
}
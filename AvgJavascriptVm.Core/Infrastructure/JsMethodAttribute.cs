using System;

namespace AvgJavascriptVm.Core.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method)]
    public class JsMethodAttribute: Attribute
    {
        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using AvgJavascriptVm.Core.BaseTypes;

namespace AvgJavascriptVm.Core.Infrastructure
{
    public class GlobalScope: LexicalEnvironment
    {
        public Dictionary<Type, JsFunction> Constructors { get; set; } = new Dictionary<Type, JsFunction>();

        public Dictionary<Type, JsObject> Prototypes { get; set; } = new Dictionary<Type, JsObject>();

        public GlobalScope()
        {
            GlobalScope = this;            
        }

        public JsObject NewObject()
        {
            return new JsObject(this);
        }
    }
}
using System.Collections.Generic;
using AvgJavascriptVm.Core.BaseTypes;
using AvgJavascriptVm.Core.Errors;

namespace AvgJavascriptVm.Core.Infrastructure
{
    public class LexicalEnvironment
    {
        private readonly LexicalEnvironment _parent;

        private readonly Dictionary<string, JsValue> _values = new Dictionary<string, JsValue>();

        public GlobalScope GlobalScope { get; protected set; }

        public bool IsNewCall { get; }
        
        public LexicalEnvironment(LexicalEnvironment parent, bool isNewCall = false)
        {
            _parent = parent;
            IsNewCall = isNewCall;
            GlobalScope = parent.GlobalScope;
        }

        public LexicalEnvironment()
        {
            
        }
        
        public bool HasProperty(string name)
        {
            if (!_values.ContainsKey(name))
            {
                return _parent.HasProperty(name);
            }
            return false;
        }

        public JsValue Get(string name)
        {
            if (!_values.ContainsKey(name))
            {
                if (name == "this" || _parent == null)
                {
                    throw new JsIsNotDefinedException(name);
                }
                return _parent.Get(name);
            }
            return _values[name];
        }

        public void Set(string name, JsValue value)
        {
            if (!SetInternal(name, value))
            {
                throw new JsIsNotDefinedException(name);
            }
        }

        public void New(string name, JsValue value = null)
        {
            _values[name] = value ?? JsUndefined.Instance;
        }

        private bool SetInternal(string name, JsValue value)
        {            
            if (!_values.ContainsKey(name))
            {
                if (name == "this" || _parent == null)
                {
                    return false;
                }
                return _parent.SetInternal(name, value);
            }
            _values[name] = value;
            return true;
        }        
    }
}
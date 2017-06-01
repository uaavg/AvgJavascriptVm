using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AvgJavascriptVm.Core.Errors;
using AvgJavascriptVm.Core.Infrastructure;

namespace AvgJavascriptVm.Core.BaseTypes
{
    public class JsObject : JsValue
    {
        public GlobalScope GlobalScope { get; }

        private readonly Dictionary<string, JsProperty> _properties = new Dictionary<string, JsProperty>();

        public virtual string TypeName => "Object";

        public JsObject(LexicalEnvironment lexEnv)
        {            
            GlobalScope = lexEnv.GlobalScope;
        }

        public virtual JsObject Constructor(LexicalEnvironment lexEnv)
        {
            return new JsObject(lexEnv);
        }

        public override JsString AsString()
        {
            return $"[object {TypeName}]";
        }

        public override JsNumber AsNumber()
        {
            return JsNumber.NaN;
        }

        public override JsBoolean AsBoolean()
        {
            return true;
        }

        public override JsObject AsObject()
        {
            return this;
        }

        public bool HasProperty(string propertyName)
        {
            return _properties.ContainsKey(propertyName);
        }

        public JsValue GetProperty(string propertyName)
        {
            if (_properties.TryGetValue(propertyName, out JsProperty prop))
            {
                return prop.Value;
            }
            return JsUndefined.Instance;
        }

        public void SetProperty(string propertyName, JsValue value)
        {
            if (!_properties.TryGetValue(propertyName, out JsProperty prop))
            {
                prop = new JsProperty(this);
                _properties.Add(propertyName, prop);
            }
            prop.Value = value;
        }

        public IEnumerable<JsProperty> Properties => _properties.Values;

        private JsValue _proto;

        [JsProperty(Name = "__proto__")]
        public JsValue JsProto
        {
            get { return _proto ?? (_proto = GetPrototype(GetType())); }
            set { _proto = value; }
        }

        private JsValue _constructor;

        [JsProperty(Name = "constructor")]
        public JsValue JsConstructor
        {
            get { return _constructor ?? (_constructor = GetConstructor()); }
            set { _constructor = value; }
        }

        private JsFunction GetConstructor()
        {
            if (!GlobalScope.Constructors.TryGetValue(GetType(), out var constructor))
            {
                constructor = GenerateConstructor();
                GlobalScope.Constructors.Add(GetType(), constructor);
            }
            return constructor;
        }

        private JsFunction GenerateConstructor()
        {
            var type = GetType();
            var constructor = type.GetMethod("Constructor", BindingFlags.DeclaredOnly);
            var name = type.Name.Replace("Js", string.Empty);
            
            if (constructor == null)
            {
                return new JsNativeFunction(le => JsUndefined.Instance, name, GlobalScope);
            }
            var parameters = constructor.GetParameters();

            if (constructor.ReturnType != typeof(JsValue))
            {
                throw new JsInternalException("Constructor of native javascript type must have JsValue return type");
            }
            if (parameters.Length != 1 || parameters[0].ParameterType != typeof(LexicalEnvironment))
            {
                throw new JsInternalException("Constructor of native javascript type must have one input paramter with LexicalEnvironment type");
            }
            return new JsNativeFunction(CreateMethodDelegate(constructor), name, GlobalScope);            
        }

        private JsObject GetPrototype(Type type)
        {
            if (!GlobalScope.Prototypes.TryGetValue(type, out var prototype))
            {
                prototype = GeneratePrototype(type);
                GlobalScope.Prototypes.Add(type, prototype);
            }
            return prototype;
        }

        private JsObject GeneratePrototype(Type type)
        {
            var ret = new JsObject(GlobalScope);
            var methods = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).Where(m => m.GetCustomAttribute(typeof(JsMethodAttribute)) != null);
            var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance).Where(m => m.GetCustomAttribute(typeof(JsPropertyAttribute)) != null);

            if (type == typeof(JsObject))
            {
                ret.JsProto = JsNull.Instance;
            }
            else
            {
                ret.JsProto = GetPrototype(type.BaseType);
            }
            foreach (var method in methods)
            {
                var methodProps = method.GetCustomAttribute<JsMethodAttribute>();
                var parameters = method.GetParameters();

                if (method.ReturnType != typeof(JsValue))
                {
                    throw new JsInternalException("Method of native javascript type must have JsValue return type");
                }
                if (parameters.Length != 1 || parameters[0].ParameterType != typeof(LexicalEnvironment))
                {
                    throw new JsInternalException("Method of native javascript type must have one input paramter with LexicalEnvironment type");
                }
                var jsFunc = new JsNativeFunction(CreateMethodDelegate(method), methodProps.Name, GlobalScope);

                SetProperty(methodProps.Name, jsFunc);
            }
            foreach (var property in properties)
            {
                var propProps = property.GetCustomAttribute<JsPropertyAttribute>();
                var setter = property.SetMethod;
                var getter = property.GetMethod;
                var jsProperty = new JsProperty(ret);

                if (property.PropertyType != typeof(JsValue))
                {
                    throw new JsInternalException("Javascript native property type must be JsValue");
                }
                if (propProps.IsInline)
                {
                    jsProperty.RawValue = (JsValue) getter.Invoke(ret, null);
                }
                else
                {
                    if (getter != null)
                    {
                        jsProperty.Getter = new JsNativeFunction(CreateGetterDelegate(getter), "", GlobalScope);
                    }
                    if (setter != null)
                    {
                        jsProperty.Setter = new JsNativeFunction(CreateSetterDelegate(setter), "", GlobalScope);
                    }
                }
                ret._properties.Add(propProps.Name, jsProperty);
            }
            return ret;
        }

        private Func<LexicalEnvironment, JsValue> CreateMethodDelegate(MethodInfo method)
        {
            return (Func<LexicalEnvironment, JsValue>)method.CreateDelegate(typeof(Func<LexicalEnvironment, JsValue>), this);
        }

        private Func<LexicalEnvironment, JsValue> CreateGetterDelegate(MethodInfo method)
        {
            var getter = (Func<JsValue>)method.CreateDelegate(typeof(Func<JsValue>), this);
            return le => getter();
        }

        private Func<LexicalEnvironment, JsValue> CreateSetterDelegate(MethodInfo method)
        {
            var setter = (Action<JsValue>)method.CreateDelegate(typeof(Action<JsValue>), this);
            return le =>
            {
                var value = le.Get("arguments").AsObject().GetProperty("0");

                setter(value);
                return JsUndefined.Instance;
            };
        }

    }
}
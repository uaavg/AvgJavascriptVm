using AvgJavascriptVm.Core.Infrastructure;

namespace AvgJavascriptVm.Core.BaseTypes
{
    public abstract class JsFunction: JsObject
    {
        public abstract string[] Parameters { get; }

        public LexicalEnvironment Scope { get; }

        protected JsFunction(LexicalEnvironment lexEnv): base(lexEnv)
        {
            Scope = lexEnv;
        }

        public JsValue Call(JsValue @this, params JsValue[] parameters)
        {
            var lexicalEnv = new LexicalEnvironment(Scope);

            lexicalEnv.New("this", @this);
            for (int i = 0; i < Parameters.Length; i++)
            {
                if (parameters.Length - 1 >= i)
                {
                    lexicalEnv.New(Parameters[i], JsUndefined.Instance);
                }
                lexicalEnv.New(Parameters[i], parameters[i]);
            }
            return CallInternal(lexicalEnv);
        }

        protected abstract JsValue CallInternal(LexicalEnvironment lexEnvironment);        
    }
}
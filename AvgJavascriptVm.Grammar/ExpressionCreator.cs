using System;
using System.Linq.Expressions;
using AvgJavascriptVm.Core.BaseTypes;
using AvgJavascriptVm.Core.Infrastructure;

namespace AvgJavascriptVm.Grammar
{
    public static class ExpressionCreator
    {
        public static Expression Function(Expression body)
        {
            var param = Expression.Parameter(typeof(LexicalEnvironment), "env");

            return Expression.Lambda<Func<LexicalEnvironment, JsValue>>(body, param);
        }
    }
}
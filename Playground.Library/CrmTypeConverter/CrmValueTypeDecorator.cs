using Microsoft.Xrm.Sdk;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Playground.Library.CrmTypeConverter
{
    public static class CrmValueTypeDecorator<TInput, TOutput> where TInput : class, new() 
                                                        where TOutput : struct
    {
        private static Type[] ValidTypes = new[] { typeof(Money), typeof(OptionSetValue), typeof(EntityReference) };

        private static string[] ValidTypeNames = ValidTypes.Select(t => t.Name).ToArray();

        private static Func<TInput, TOutput> GetValueFn;

        static CrmValueTypeDecorator()
        {
            ParameterExpression paramExpr = Expression.Parameter(typeof(TInput), "x");
            Expression propertyExpr = Expression.Property(paramExpr, "Value");
            GetValueFn = Expression.Lambda<Func<TInput, TOutput>>(propertyExpr, paramExpr).Compile();
        }

        public static TOutput GetValue(TInput obj)
        {
            AssertIsCrmType(obj);

            return GetValueFn(obj);
        }

        private static void AssertIsCrmType(TInput obj)
        {
            bool isCrmType = ValidTypes.Any(t => t == obj.GetType());

            if (!isCrmType)
            {
                throw new InvalidCastException($"{nameof(obj)} must be one of the followin types: {string.Join(", ", ValidTypeNames)}");
            }
        }
    }
}

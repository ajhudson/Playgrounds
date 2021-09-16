using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Library.CrmTypeConverter
{
    public class CrmValueTypeDecorator<T> where T : class, new()
    {
        private static Type[] ValidTypes = new[] { typeof(Money), typeof(OptionSetValue), typeof(EntityReference) };

        private static string[] ValidTypeNames = ValidTypes.Select(t => t.Name).ToArray();

        public T Value { get; }

        public CrmValueTypeDecorator(T obj)
        {
            this.AssertIsCrmType(obj);




        }

        private void AssertIsCrmType(T obj)
        {
            bool isCrmType = ValidTypes.Any(t => t == obj.GetType());

            if (!isCrmType)
            {
                throw new InvalidCastException($"{nameof(obj)} must be one of the followin types: {string.Join(", ", ValidTypeNames)}");
            }
        }
    }
}

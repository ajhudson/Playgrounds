using Microsoft.Xrm.Sdk;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Playground.UnitTests.CrmTypeConverterTests
{
    [TestFixture]
    public class ExpressionTreeXpTest
    {
        [Test]
        public void ShouldGetValueWithDelegate()
        {
            var optionSetValue = new OptionSetValue(256);
            Func<OptionSetValue, int> getValueFn = x => x.Value;
            int result = getValueFn(optionSetValue);

            result.ShouldBe(256);
        }

        [Test]
        public void ShouldGetValueWithExpressionTree()
        {
            var optionSetValue = new OptionSetValue(512);
            ParameterExpression paramExpr = Expression.Parameter(typeof(OptionSetValue), "x");
            Expression propertyExpr = Expression.Property(paramExpr, "Value");
            var compiledFn = Expression.Lambda<Func<OptionSetValue, int>>(propertyExpr, paramExpr).Compile();
            int val = compiledFn(optionSetValue);

            val.ShouldBe(512);
        }
    }
}

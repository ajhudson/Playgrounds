using Microsoft.Xrm.Sdk;
using NUnit.Framework;
using Playground.Library.CrmTypeConverter;
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

        [Test]
        public void ShouldGetOptionSetValueUsingHelper()
        {
            var optionSetValue = new OptionSetValue(876);
            int optionSetValueResult = CrmValueTypeDecorator<OptionSetValue, int>.GetValue(optionSetValue);
            optionSetValueResult.ShouldBe(876);
        }

        [Test]
        public void ShouldGetMoneyValueUsingHelper()
        {
            var money = new Money(34.56m);
            decimal moneyResult = CrmValueTypeDecorator<Money, decimal>.GetValue(money);
            moneyResult.ShouldBe(34.56m);
        }

        [Test]
        public void ShouldGetEntityReferenceValueUsingHelper()
        {
            Guid id = Guid.Parse("666879EA-050E-4A35-AFA6-CEAA9EEF0B1D");
            var entityRef = new EntityReference("account", id);
            Guid entityRefResult = CrmValueTypeDecorator<EntityReference, Guid>.GetValue(entityRef);
            entityRefResult.ShouldBe(id);
        }
    }
}

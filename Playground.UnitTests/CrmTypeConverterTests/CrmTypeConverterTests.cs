using NUnit.Framework;
using System.Collections;
using Shouldly;
using Playground.Library.CrmTypeConverter;
using System;
using System.Text;
using Microsoft.Xrm.Sdk;

namespace Playground.UnitTests.CrmTypeConverterTests
{
    [TestFixture]
    [TestFixtureSource(typeof(CrmTypeConverterTestData), nameof(CrmTypeConverterTestData.Parameters))]
    public class CrmTypeConverterTests<TOriginal, TExpected>
    {
        private readonly TOriginal _inputValue;

        public CrmTypeConverterTests(TOriginal inputValue)
        {
            this._inputValue = inputValue;
        }

        [Test]
        public void ShouldConvertToExpectedType()
        {
            // Arrange
            // Act
            object result = CrmTypeConverterUtils.ConvertCrmType(this._inputValue);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<TExpected>();
        }

    }

    public class CrmTypeConverterTestData
    {
        public static IEnumerable Parameters
        {
            get
            {
                yield return new TestFixtureData(typeof(short), typeof(int), short.MaxValue);
                yield return new TestFixtureData(typeof(int), typeof(int), int.MaxValue);
                yield return new TestFixtureData(typeof(decimal), typeof(decimal), decimal.MaxValue);
                yield return new TestFixtureData(typeof(DateTime), typeof(DateTime), DateTime.MaxValue);
                yield return new TestFixtureData(typeof(bool), typeof(bool), true);
                yield return new TestFixtureData(typeof(byte[]), typeof(byte[]), Encoding.UTF8.GetBytes("some text"));
                yield return new TestFixtureData(typeof(Guid), typeof(Guid), Guid.NewGuid());
                yield return new TestFixtureData(typeof(Money), typeof(int), new Money(256.78m));
                yield return new TestFixtureData(typeof(OptionSetValue), typeof(int), new OptionSetValue(2));
                yield return new TestFixtureData(typeof(EntityReference), typeof(Guid), new EntityReference("new_newsite", Guid.NewGuid()));
            }
        }
    }
}

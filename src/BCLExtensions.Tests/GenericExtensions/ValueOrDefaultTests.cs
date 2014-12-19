using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Extensions;

namespace BCLExtensions.Tests.GenericExtensions
{
    public class ValueOrDefaultTests
    {

        [Theory]
        [InlineData((string) null)]
        [InlineData((List<int>) null)]
        [InlineData((object) null)]
        public void WhenInputNullAndDefaultValueIsNullThrowsException<T>(T input) where T : class
        {
            Assert.Throws<ArgumentNullException>(() => input.GetValueOrDefault(null));
        }

        [Theory]
        [InlineData("Valid Non-null string")]
        [ListData]
        [ObjectData]
        public void WhenValidInputAndDefaultValueIsNullThrowsException<T>(T input) where T : class
        {
            Assert.Throws<ArgumentNullException>(() => input.GetValueOrDefault(null));
        }

        [Theory]
        [InlineData("Valid Non-null string", "(Default)")]
        [ListData]
        [ObjectData]
        public void WhenInputIsNotNullThenReturnsInputValue<T>(T input, T defaultValue) where T : class
        {
            var result = input.GetValueOrDefault(defaultValue);
            Assert.Equal(input, result);
        }

        [Theory]
        [InlineData((string) null, "(Default)")]
        [ListData(inputIsNull:true)]
        [ObjectData(inputIsNull: true)]
        public void WhenInputIsNullThenReturnsDefaultValue<T>(T input, T defaultValue) where T : class
        {
            var result = input.GetValueOrDefault(defaultValue);
            Assert.Equal(defaultValue, result);
        }

        public class ListDataAttribute : DataAttribute
        {
            private readonly bool _inputIsNull;

            private readonly List<int> _defaultList = new List<int>();

            private readonly List<int> _validList = new List<int>();

            public ListDataAttribute(bool inputIsNull = false)
            {
                _inputIsNull = inputIsNull;
            }

            public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest, Type[] parameterTypes)
            {
                if (parameterTypes.Length == 1)
                {
                    yield return new object[]
                    {
                        _inputIsNull ? null : _validList
                    };
                }
                else
                {
                    yield return new object[]
                    {
                        _inputIsNull ? null : _validList,
                        _defaultList
                    };
                }
            }
        }

        public class ObjectDataAttribute : DataAttribute
        {
            private readonly bool _inputIsNull;

            private readonly object _defaultObject = new Object();

            private readonly object _validObject = new Object();

            public ObjectDataAttribute(bool inputIsNull = false)
            {
                _inputIsNull = inputIsNull;
            }

            public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest, Type[] parameterTypes)
            {
                if (parameterTypes.Length == 1)
                {
                    yield return new[]
                    {
                        _inputIsNull ? null : _validObject,
                    };
                }
                else
                {
                    yield return new[]
                    {
                        _inputIsNull ? null : _validObject,
                        _defaultObject
                    };
                }
            }
        }
    }
}
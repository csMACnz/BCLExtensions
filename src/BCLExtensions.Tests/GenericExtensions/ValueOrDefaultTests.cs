using System;
using System.Collections.Generic;
using Xunit;

namespace BCLExtensions.Tests.GenericExtensions
{
    public class ValueOrDefaultTests
    {
        public abstract class GivenATOfBase<T> where T : class
        {
            protected abstract T DefaultValue { get; }
            protected abstract T ValidInput { get; }

            [Fact]
            public void WhenInputNullAndDefaultValueIsNullThrowsException()
            {
                T input = null;
                Assert.Throws<ArgumentNullException>(
                    () => {
                        var result = input.GetValueOrDefault(null);
                    });
            }

            [Fact]
            public void WhenValidInputAndDefaultValueIsNullThrowsException()
            {
                T input = ValidInput;
                Assert.Throws<ArgumentNullException>(
                    () =>
                    {
                        var result = input.GetValueOrDefault(null);
                    });
            }

            [Fact]
            public void WhenInputIsNotNullThenReturnsInputValue()
            {
                T input = ValidInput;
                var result = input.GetValueOrDefault(DefaultValue);
                Assert.Equal(ValidInput, result);
            }

            [Fact]
            public void WhenInputIsNullThenReturnsDefaultValue()
            {
                T input = null;
                var result = input.GetValueOrDefault(DefaultValue);
                Assert.Equal(DefaultValue, result);
            }
        }

        public class GivenATOfString : GivenATOfBase<string>
        {
            protected override string DefaultValue
            {
                get { return "(Default)"; }
            }

            protected override string ValidInput
            {
                get { return "Valid Non-null string"; }
            }
        }

        public class GivenATOfListOfInt : GivenATOfBase<List<int>>
        {
            private List<int> _defaultList = new List<int>();
            protected override List<int> DefaultValue
            {
                get { return _defaultList; }
            }

            private List<int> _validInput = new List<int>();
            protected override List<int> ValidInput
            {
                get { return _validInput; }
            }
        }

        public class GivenATOfObject : GivenATOfBase<object>
        {
            private object _defaultObject = new Object();
            protected override object DefaultValue
            {
                get { return _defaultObject; }
            }

            private object _validInput = new Object();
            protected override object ValidInput
            {
                get { return _validInput; }
            }
        }
    }
}
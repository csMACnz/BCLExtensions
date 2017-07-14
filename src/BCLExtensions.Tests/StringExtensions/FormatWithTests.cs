using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;

namespace BCLExtensions.Tests.StringExtensions
{
    public class FormatWithTests
    {
        public class WithNullInputString
        {
            private readonly string _myString = null;

            [Fact]
            public void NoParametersProvidedThowsArgumentNullException()
            {
                Func<string, object[], string> formatWith = BCLExtensions.StringExtensions.FormatWith;
                Assert.Throws<ArgumentNullException>(formatWith.AsActionUsing(_myString, new object[0]));
            }
        }

        public class WithEmptyInputString
        {
            readonly string _myString = string.Empty;

            [Fact]
            public void NoParametersProvidedReturnsEmptyOutput()
            {
                var formattedString = _myString.FormatWith();
                Assert.Equal(string.Empty, formattedString);
            }

        }

        public class WithInputStringContainingNoParameters
        {
            readonly string _myString = "my string with no parameters";

            [Fact]
            public void NoParametersProvidedReturnsOriginalString()
            {
                var formattedString = _myString.FormatWith();
                Assert.Equal(_myString, formattedString);
            }

        }

        public class WithInputStringContainingOneParameter
        {
            readonly string _myString = "my string has {0}";

            [Fact]
            public void NoParametersProvidedThrowsFormatException()
            {
                Func<string, object[], string> formatWith = BCLExtensions.StringExtensions.FormatWith;
                Assert.Throws<FormatException>(formatWith.AsActionUsing(_myString, new object[0]));
            }

            [Fact]
            public void OneStringParametersProvidedReturnsWithContainingParameter()
            {
                var stringParameter = "FizzBuzz";
                var formattedString = _myString.FormatWith(stringParameter);
                Assert.True(formattedString.Contains(stringParameter));
            }
        }
    }
}

using System;
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
                Assert.Throws<ArgumentNullException>(() => _myString.FormatWith());
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
                Assert.Throws<FormatException>(() => _myString.FormatWith());
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

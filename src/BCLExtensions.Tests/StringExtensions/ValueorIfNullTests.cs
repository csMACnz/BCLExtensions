using System;
using Xunit;

namespace BCLExtensions.Tests.StringExtensions
{
    public class ValueorIfNullTests
    {
        public class WithNullInputString
        {
            private readonly string input = null;

            [Fact]
            public void DefaultStringReturnsDefaultString()
            {
                string expected = "(Default)";
                var result = input.ValueOrIfNull(expected);
                Assert.Equal(expected, result);
            }

            [Fact]
            public void NullDefaultStringThrowsException()
            {
                Assert.Throws<ArgumentNullException>(() => input.ValueOrIfNull(null));
            }

            [Fact]
            public void EmptyDefaultStringReturnsEmptyString()
            {
                var result = input.ValueOrIfNull(string.Empty);
                Assert.Equal(string.Empty, result);
            }
        }

        [Fact]
        public void WithNonNullInputAndNullDefaultStringThrowsException()
        {
            var input = "Test";
            Assert.Throws<ArgumentNullException>(() => input.ValueOrIfNull(null));
        }

        [Fact]
        public void WithEmptyStringReturnsEmptyString()
        {
            string input = "";
            var result = input.ValueOrIfNull("(Default)");
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void WithStringEmptyReturnsEmptyString()
        {
            string input = string.Empty;
            var result = input.ValueOrIfNull("(Default)");
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void WithWhitespaceReturnsInputString()
        {
            string input = "   ";
            var result = input.ValueOrIfNull("(Default)");
            Assert.Equal(input, result);
        }
    }
}

using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;
using Xunit.Extensions;

namespace BCLExtensions.Tests.StringExtensions
{
    public class RightTests
    {
        [Theory]
        [InlineData("Hello World", 5, "World")]
        [InlineData("Not Long Enough", 100, "Not Long Enough")]
        [InlineData("", 0, "")]
        [InlineData("", 5, "")]
        [InlineData("Becomes Empty String", 0, "")]
        public void InputReturnsExpectedOutput(string input, int length, string expected)
        {
            var formattedString = input.Right(length);
            Assert.Equal(expected, formattedString);
        }

        [Fact]
        public void NullInputThrowsException()
        {
            Func<string, int, string> right = BCLExtensions.StringExtensions.Right;
            Assert.Throws<ArgumentNullException>(right.AsActionUsing(null, 0));
        }

        [Fact]
        public void NegativeLengthThrowsException()
        {
            Func<string, int, string> right = BCLExtensions.StringExtensions.Right;
            Assert.Throws<ArgumentOutOfRangeException>(right.AsActionUsing("Hello World", -1));
        }
    }
}

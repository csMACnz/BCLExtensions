using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;
using Xunit.Extensions;

namespace BCLExtensions.Tests.StringExtensions
{
    public class LeftTests
    {
        [Theory]
        [InlineData("Hello World", 5, "Hello")]
        [InlineData("Not Long Enough", 100, "Not Long Enough")]
        [InlineData("", 0, "")]
        [InlineData("", 5, "")]
        [InlineData("Becomes Empty String", 0, "")]
        public void InputReturnsExpectedOutput(string input, int length, string expected)
        {
            var formattedString = input.Left(length);
            Assert.Equal(expected, formattedString);
        }

        [Fact]
        public void NullInputThrowsException()
        {
            Func<string, int, string> left = BCLExtensions.StringExtensions.Left;
            Assert.Throws<ArgumentNullException>(left.AsActionUsing(null, 0));
        }

        [Fact]
        public void NegativeLengthThrowsException()
        {
            Func<string, int, string> left = BCLExtensions.StringExtensions.Left;
            Assert.Throws<ArgumentOutOfRangeException>(left.AsActionUsing("Hello World", -1));
        }
    }
}

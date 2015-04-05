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
        public void RightInputReturnsExpectedOutput(string input, int length, string expected)
        {
            var formattedString = input.Right(length);
            Assert.Equal(expected, formattedString);
        }

        [Fact]
        public void NullInputThrowsException()
        {
            Func<string, int, string> Right = BCLExtensions.StringExtensions.Right;
            Assert.Throws<ArgumentNullException>(Right.AsActionUsing(null, 0).AsThrowsDelegate());
        }

        [Fact]
        public void NegativeLengthThrowsException()
        {
            Func<string, int, string> Right = BCLExtensions.StringExtensions.Right;
            Assert.Throws<ArgumentOutOfRangeException>(Right.AsActionUsing("Hello World", -1).AsThrowsDelegate());
        }
    }
}

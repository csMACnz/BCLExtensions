using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;
using Xunit.Extensions;

namespace BCLExtensions.Tests.StringExtensions
{
    public class SafeLeftTests
    {
        [Theory]
        [InlineData("Hello World", 5, "Hello")]
        [InlineData("Not Long Enough", 100, "Not Long Enough")]
        [InlineData("", 0, "")]
        [InlineData("", 5, "")]
        [InlineData("Becomes Empty String", 0, "")]
        public void InputReturnsExpectedOutput(string input, int length, string expected)
        {
            var formattedString = input.SafeLeft(length);
            Assert.Equal(expected, formattedString);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(int.MaxValue)]
        public void NullInputReturnsEmptyString(int length)
        {
            string input = null;
            
            var formattedString = input.SafeLeft(length);
            
            Assert.Equal(string.Empty, formattedString);
        }

        [Fact]
        public void NegativeLengthThrowsException()
        {
            Func<string, int, string> safeLeft = BCLExtensions.StringExtensions.SafeLeft;
            Assert.Throws<ArgumentOutOfRangeException>(safeLeft.AsActionUsing("Hello World", -1).AsThrowsDelegate());
        }


        [Fact]
        public void NegativeLengthOnNullThrowsException()
        {
            Func<string, int, string> safeLeft = BCLExtensions.StringExtensions.SafeLeft;
            Assert.Throws<ArgumentOutOfRangeException>(safeLeft.AsActionUsing(null, -1).AsThrowsDelegate());
        }
    }
}

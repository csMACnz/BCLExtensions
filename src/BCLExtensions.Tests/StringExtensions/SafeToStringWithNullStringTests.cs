using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;

namespace BCLExtensions.Tests.StringExtensions
{
    public class SafeToStringWithNullStringTests
    {
        [Fact]
        public void NullWithNullNullStringThrowsException()
        {
            Func<string, string, string> safeToString = BCLExtensions.StringExtensions.SafeToString;
            Assert.Throws<ArgumentNullException>(safeToString.AsActionUsing(null, null).AsThrowsDelegate());
        }

        [Fact]
        public void NullReturnsEmptyString()
        {
            object value = null;

            // ReSharper disable once ExpressionIsAlwaysNull
            var result = value.SafeToString("[NULL]");

            Assert.Equal("[NULL]", result);
        }

        [Fact]
        public void StringWithNullNullStringThrowsException()
        {
            Func<string, string, string> safeToString = BCLExtensions.StringExtensions.SafeToString;
            Assert.Throws<ArgumentNullException>(safeToString.AsActionUsing("String Object", null).AsThrowsDelegate());
        }

        [Fact]
        public void StringReturnsOriginalString()
        {
            const string expected = "String Object";

            var result = expected.SafeToString();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void StringAsObjectReturnsOriginalString()
        {
            const string expected = "Test String";
            object value = expected;

            var result = value.SafeToString();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CustomObjectReturnsCorrectString()
        {
            var value = new TestObject();

            var result = value.SafeToString();

            Assert.Equal(TestObject.ExpectedString, result);
        }

        [Fact]
        public void CustomObjectWithNullNullStringThrowsException()
        {
            Func<TestObject, string, string> safeToString = BCLExtensions.StringExtensions.SafeToString;
            Assert.Throws<ArgumentNullException>(safeToString.AsActionUsing(new TestObject(), null).AsThrowsDelegate());
        }

        private class TestObject
        {
            public const string ExpectedString = "Sample String";

            public override string ToString()
            {
                return ExpectedString;
            }
        }
    }
}

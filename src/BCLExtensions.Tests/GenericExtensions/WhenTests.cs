using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;

namespace BCLExtensions.Tests.GenericExtensions
{
    public class WhenTests
    {
        [Fact]
        public void GivenALongStringCanConditionalSubString()
        {
            var value = "Hello";

            var result = CallLengthWhenOnString(value);

            Assert.Equal("Hel", result);
        }

        [Fact]
        public void GivenAShortStringOriginalStringReturns()
        {
            var value = "He";

            var result = CallLengthWhenOnString(value);

            Assert.Equal("He", result);
        }

        [Fact]
        public void FunctionLambdaNullThrows()
        {
            var value = "A";
            Func<string, Func<string, bool>, Func<string, string>, string> action = BCLExtensions.GenericExtensions.When;
            Assert.Throws<ArgumentNullException>(action.AsActionUsing(value, FuncHelpers.ReturnFalse, null).AsThrowsDelegate());
        }

        [Fact]
        public void PredicateLambdaNullThrows()
        {
            var value = "A";
            Func<string, Func<string, bool>, Func<string, string>, string> action = BCLExtensions.GenericExtensions.When;
            Assert.Throws<ArgumentNullException>(action.AsActionUsing(value, null, FuncHelpers.SelectSelf).AsThrowsDelegate());
        }

        [Fact]
        public void BothLambdasNullThrows()
        {
            var value = "A";
            Func<string, Func<string, bool>, Func<string, string>, string> action = BCLExtensions.GenericExtensions.When;
            Assert.Throws<ArgumentNullException>(action.AsActionUsing(value, null, null).AsThrowsDelegate());
        }

        private static string CallLengthWhenOnString(string value)
        {
            var result = value.When(v => v.Length > 3, v => v.Substring(0, 3));
            return result;
        }
    }
}

using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;

namespace BCLExtensions.Tests.GenericExtensions
{
    public class WhenFunctionTests
    {
        private string _newValue = "New World";

        [Fact]
        public void ValidateInputCannotBeNull()
        {
            string input = null;
            Func<string, Func<string, bool>, Func<string,string>, string> func = BCLExtensions.GenericExtensions.When;
            Assert.Throws<ArgumentNullException>(func.AsActionUsing(input, AlwaysTrue, ReturnsNewValue).AsThrowsDelegate());
        }

        [Fact]
        public void ValidatePredicateCannotBeNull()
        {
            string input = "Hello World";
            Func<string, bool> predicate = null;
            Func<string, Func<string, bool>, Func<string, string>, string> func = BCLExtensions.GenericExtensions.When;
            Assert.Throws<ArgumentNullException>(func.AsActionUsing(input, predicate, ReturnsNewValue).AsThrowsDelegate());
        }

        [Fact]
        public void ValidateActionCannotBeNull()
        {
            string input = "Hello World";
            Func<string, string> action = null;
            Func<string, Func<string, bool>, Func<string, string>, string> func = BCLExtensions.GenericExtensions.When;
            Assert.Throws<ArgumentNullException>(func.AsActionUsing(input, AlwaysTrue, action).AsThrowsDelegate());
        }

        [Fact]
        public void TruePredicateCallsFunction()
        {
            var executed = TestFunctionExecution(AlwaysTrue);

            Assert.True(executed);
        }

        [Fact]
        public void TruePredicateReturnsFunctionResult()
        {
            string input = "Hello World";

            Func<string, string> function = ReturnsNewValue;
            var result = input.When(AlwaysTrue, function);

            Assert.Equal(_newValue, result);
        }

        [Fact]
        public void FalsePredicateDoesNotCallFunction()
        {
            var executed = TestFunctionExecution(AlwaysFalse);

            Assert.False(executed);
        }

        [Fact]
        public void FalsePredicateReturnsInputValue()
        {
            string input = "Hello World";

            Func<string,string> function = ReturnsNewValue;
            var result = input.When(AlwaysFalse, function);

            Assert.Equal(input, result);
        }

        private bool TestFunctionExecution(Func<string, bool> predicate)
        {
            var executed = false;
            string input = "Hello World";

            input.When(predicate, s =>
            {
                executed = true;
                return s;
            });
            return executed;
        }

        private string ReturnsNewValue(string s)
        {
            return _newValue;
        }

        private bool AlwaysFalse(string s)
        {
            return false;
        }

        private bool AlwaysTrue(string s)
        {
            return true;
        }

    }
}

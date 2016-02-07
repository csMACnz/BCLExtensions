using System;
using Xunit;

namespace BCLExtensions.Tests.GenericExtensions
{
    public class WhenFunctionTests
    {
        [Fact]
        public void TruePredicateCallsFunction()
        {
            var executed = TestFunctionExecution(AlwaysTrue);

            Assert.True(executed);
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

        [Fact]
        public void TruePredicateReturnsFunctionResult()
        {
            string input = "Hello World";
            string expected = "New World";

            var result = input.When(AlwaysTrue, s => expected);

            Assert.Equal(expected, result);
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

            var result = input.When(AlwaysFalse, s => "New World");

            Assert.Equal(input, result);
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

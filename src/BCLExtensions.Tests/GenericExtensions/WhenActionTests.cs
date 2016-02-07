using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;

namespace BCLExtensions.Tests.GenericExtensions
{
    public class WhenActionTests
    {
        [Fact]
        public void ValidateInputCannotBeNull()
        {
            string input = null;
            Func<string, Func<string,bool>, Action<string>, string> func = BCLExtensions.GenericExtensions.When;
            Assert.Throws<ArgumentNullException>(func.AsActionUsing(input, AlwaysTrue, DoNothing).AsThrowsDelegate());
        }

        [Fact]
        public void TruePredicateCallsAction()
        {
            var executed = TestActionExecution(AlwaysTrue);

            Assert.True(executed);
        }

        [Fact]
        public void TruePredicateReturnsInputValue()
        {
            string input = "Hello World";

            Action<string> action = DoNothing;
            var result = input.When(AlwaysTrue, action);

            Assert.Equal(input, result);
        }

        [Fact]
        public void FalsePredicateDoesNotCallFunction()
        {
            var executed = TestActionExecution(AlwaysFalse);

            Assert.False(executed);
        }

        [Fact]
        public void FalsePredicateReturnsInputValue()
        {
            string input = "Hello World";

            Action<string> action = DoNothing;
            var result = input.When(AlwaysFalse, action);

            Assert.Equal(input, result);
        }

        private static void DoNothing(string s)
        {
        }

        private bool TestActionExecution(Func<string, bool> predicate)
        {
            var executed = false;
            string input = "Hello World";

            input.When(predicate, s =>
            {
                executed = true;
            });
            return executed;
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

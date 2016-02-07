using System;
using Xunit;

namespace BCLExtensions.Tests.GenericExtensions
{
    public class WhenActionTests
    {
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
            
            var result = input.When(AlwaysTrue, s => { });

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

            var result = input.When(AlwaysFalse, s => { });

            Assert.Equal(input, result);
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

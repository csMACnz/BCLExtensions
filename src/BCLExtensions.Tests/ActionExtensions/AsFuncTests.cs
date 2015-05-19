using System;
using Xunit;

namespace BCLExtensions.Tests.ActionExtensions
{
    public class AsFuncTests
    {
        [Fact]
        public void SampleActionIsValid()
        {
            Assert.DoesNotThrow(SampleAction);
        }

        [Fact]
        public void ResultNotNull()
        {
            Action action = SampleAction;

            var func = action.AsFunc();

            Assert.NotNull(func);
        }

        private void SampleAction()
        {
        }
    }
}

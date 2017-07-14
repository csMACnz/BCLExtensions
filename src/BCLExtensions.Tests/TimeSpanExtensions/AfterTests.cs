using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;

namespace BCLExtensions.Tests.TimeSpanExtensions
{
    public class AfterTests
    {
        [Fact]
        public void WorksWhenUsedAsAnExtension()
        {
            var now = DateTime.Now;
            var result = 5.Minutes().After(now);
            Assert.Equal(now + TimeSpan.FromMinutes(5), result);
        }

        [Fact]
        public void AttemptToGoAfterMaxValueCausesArgumentOutOfRangeException()
        {
            var endOfTime = DateTime.MaxValue;
            var twoMinutes = 2.Minutes();

            Func<TimeSpan, DateTime, DateTime> afterAction =
                BCLExtensions.TimeSpanExtensions.After;

            Assert.Throws<ArgumentOutOfRangeException>(
                afterAction.AsActionUsing(twoMinutes, endOfTime));
        }
    }
}

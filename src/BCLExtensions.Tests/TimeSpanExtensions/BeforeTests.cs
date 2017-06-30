using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;

namespace BCLExtensions.Tests.TimeSpanExtensions
{
    public class BeforeTests
    {
        [Fact]
        public void WorksWhenUsedAsAnExtension()
        {
            var now = DateTime.Now;
            var result = 5.Minutes().Before(now);
            Assert.Equal(now - TimeSpan.FromMinutes(5), result);
        }

        [Fact]
        public void AttemptToGoBeforeMinValueCausesArgumentOutOfRangeException()
        {
            var startOfTime = DateTime.MinValue;
            var twoMinutes = 2.Minutes();

            Func<TimeSpan, DateTime, DateTime> beforeAction =
                BCLExtensions.TimeSpanExtensions.Before;

            Assert.Throws<ArgumentOutOfRangeException>(
                beforeAction.AsActionUsing(twoMinutes, startOfTime));
        }
    }
}

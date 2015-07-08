using System;
using Xunit;
using Xunit.Extensions;

namespace BCLExtensions.Tests.IntTimespanExtensions
{
    public class HoursTests
    {
        [Fact]
        public void WorksWhenUsedOnAnInlineConstant()
        {
            TimeSpan result = (5).Hours();

            Assert.Equal(5, result.TotalHours);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(265)]
        [InlineData(9001)]
        [InlineData(-1)]
        [InlineData(-5)]
        [InlineData(-10)]
        [InlineData(-265)]
        [InlineData(-9001)]
        [InlineData(-256204778)]
        [InlineData(256204778)]
        public void WhenGivenANumberThenReturnsCorrectTimeSpan(int numberOfHours)
        {
            TimeSpan result = numberOfHours.Hours();

            Assert.Equal(numberOfHours, result.TotalHours);
        }

        [Theory]
        [InlineData(-256204779)]
        [InlineData(256204779)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void DayCountsOutsideOfTheMaximumLimitThrowAnArgumentOutOfRangeException(int numberOfHours)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => numberOfHours.Hours());
        }
    }
}

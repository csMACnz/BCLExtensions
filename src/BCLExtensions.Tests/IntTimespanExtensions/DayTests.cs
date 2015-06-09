using System;
using Xunit;
using Xunit.Extensions;

namespace BCLExtensions.Tests.IntTimespanExtensions
{
    public class DayTests
    {
        [Fact]
        public void WorksWhenUsedOnAnInlineConstant()
        {
            TimeSpan result = (1).Day();

            Assert.Equal(1, result.TotalDays);
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
        [InlineData(-10675199)]
        [InlineData(10675199)]
        public void WhenGivenANumberThenReturnsCorrectTimeSpan(int numberOfDays)
        {
            TimeSpan result = numberOfDays.Day();

            Assert.Equal(numberOfDays, result.TotalDays);
        }

        [Theory]
        [InlineData(-10675200)]
        [InlineData(10675200)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void DayCountsOutsideOfTheMaximumLimitThrowAnArgumentOutOfRangeException(int numberOfDays)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => numberOfDays.Day());
        }
    }
}

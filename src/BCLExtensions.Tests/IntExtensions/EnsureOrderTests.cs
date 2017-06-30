using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;
using Xunit.Extensions;

namespace BCLExtensions.Tests.IntExtensions
{
    public class EnsureOrderTests
    {
        [Theory]
        [InlineData(int.MaxValue, int.MinValue)]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(0, -1)]
        [InlineData(-1, -2)]
        [InlineData(-2, -3)]
        [InlineData(42, -42)]
        public void InvalidOrderThrowsExceptions(int first, int second)
        {
            Action<int, int> ensureOrder = BCLExtensions.IntExtensions.EnsureOrder;

            Assert.Throws<InvalidOperationException>(ensureOrder.AsActionUsing(first, second));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(int.MinValue, int.MaxValue)]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(-2, -1)]
        [InlineData(-3, -2)]
        [InlineData(42, 42)]
        [InlineData(-42, 42)]
        public void ValidDataDoesNotThrowExceptions(int first, int second)
        {
            Action<int, int> ensureOrder = BCLExtensions.IntExtensions.EnsureOrder;

            var action = ensureOrder.AsActionUsing(first, second);
            action();
        }
    }
}

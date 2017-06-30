using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;
using Xunit.Extensions;

namespace BCLExtensions.Tests.TypeExtensions
{
    public class IsNullableTests
    {
        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(object))]
        [InlineData(typeof(byte?))]
        [InlineData(typeof(int?))]
        [InlineData(typeof(float?))]
        [InlineData(typeof(double?))]
        [InlineData(typeof(decimal?))]
        public void IntIsNullableReturnsTrue(Type type)
        {
            var isIntNullable = type.IsNullable();

            Assert.True(isIntNullable);
        }

        [Theory]
        [InlineData(typeof(byte))]
        [InlineData(typeof(int))]
        [InlineData(typeof(float))]
        [InlineData(typeof(double))]
        [InlineData(typeof(decimal))]
        public void IntIsNullableReturnsFalse(Type type)
        {
            var isIntNullable = type.IsNullable();

            Assert.False(isIntNullable);
        }

        [Fact]
        public void Exception()
        {
            Type type = null;

            Func<Type, bool> isNullable = BCLExtensions.TypeExtensions.IsNullable;

            Assert.Throws<ArgumentNullException>(isNullable.AsActionUsing(type));
        }
    }
}

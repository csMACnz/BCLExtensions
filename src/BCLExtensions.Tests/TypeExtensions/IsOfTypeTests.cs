using System;
using Xunit;

namespace BCLExtensions.Tests.TypeExtensions
{
    public class IsOfTypeTests
    {
        [Fact]
        public void WhenInstanceIsNullReturnsFalse()
        {
            object item = null;
            var result = item.IsOfType<object>();
            Assert.False(result);
        }

        [Fact]
        public void WhenInstanceIsObjectAndOfTypeIsObjectReturnsTrue()
        {
            object item = new object();
            var result = item.IsOfType<object>();
            Assert.True(result);
        }


        [Fact]
        public void WhenInstanceIsStringAndOfTypeIsObjectReturnsFalse()
        {
            object item = new String('c',5);
            var result = item.IsOfType<object>();
            Assert.False(result);
        }

    }
}

using System;
using BCLExtensions.Tests.TestHelpers;
using Xunit;

namespace BCLExtensions.Tests.GenericExtensions
{
    public class MapTests
    {
        [Fact]
        public void MapExecutesWhenRun()
        {
            var value = "Hello World";

            int result = value.Map(x => x.Length);

            Assert.Equal(11, result);
        }

        [Fact]
        public void MapCanPassThroughSelf()
        {
            var value = "Hello World";

            var result = value.Map(x => x);

            Assert.Equal(value, result);
        }

        [Fact]
        public void MapThrowsOnNullFunction()
        {
            var value = "Hello World";

            Func<string, Func<string, int>, int> func = BCLExtensions.GenericExtensions.Map;

            Assert.Throws<ArgumentNullException>(func.AsActionUsing(value, null).AsThrowsDelegate());
        }
    }
}

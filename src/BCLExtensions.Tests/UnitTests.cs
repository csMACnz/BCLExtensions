using Xunit;

namespace BCLExtensions.Tests
{
    public class UnitTests
    {
        [Fact]
        public void DefaultUnitEqualToNewUnit()
        {
            Assert.Equal(Unit.Default, new Unit());
        }

        [Fact]
        public void NewUnitEqualToNewUnit()
        {
            Assert.Equal(new Unit(), new Unit());
        }
        [Fact]
        public void DefaultedUnitEqualDefaultUnit()
        {
            Assert.Equal(default(Unit), Unit.Default);
        }

        [Fact]
        public void NewUnitEqualToDefaultedUnit()
        {
            Assert.Equal(new Unit(), default(Unit));
        }

    }
}

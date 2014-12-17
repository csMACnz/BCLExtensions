using System;
using Xunit;

namespace BCLExtensions.Tests.ObjectExtensions
{
    public class EnsureIsNotNullTests
    {
        private string instanceArgumentName = "instance";

        [Fact]
        public void WhenInstanceIsNullThrowsException()
        {
            object instance = null;
            Assert.Throws<ArgumentNullException>(() => instance.EnsureIsNotNull());
        }

        [Fact]
        public void WhenInstanceIsNotNullThenRunsSuccessfully()
        {
            var instance = new object();
            instance.EnsureIsNotNull();
        }

        [Fact]
        public void WhenInstanceIsNotNullWithNamedArgumentThenRunsSuccessfully()
        {
            var instance = new object();
            instance.EnsureIsNotNull(instanceArgumentName);
        }

        [Fact]
        public void WhenInstanceIsNullWithNamedArgumentThrowsException()
        {
            object instance = null;
            Assert.Throws<ArgumentNullException>(() => instance.EnsureIsNotNull(instanceArgumentName));
        }

        [Fact]
        public void WhenInstanceIsNullWithNamedArgumentCorrectArgumentNameIsProvidedInException()
        {
            object instance = null;

            var exception = Assert.Throws<ArgumentNullException>(() => instance.EnsureIsNotNull(instanceArgumentName));

            Assert.Equal(instanceArgumentName, exception.ParamName);
        }

    }
}

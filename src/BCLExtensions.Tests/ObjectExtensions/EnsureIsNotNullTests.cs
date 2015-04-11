using System;
using BCLExtensions.Tests.TestHelpers;
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
            Action<object> action = BCLExtensions.ObjectExtensions.EnsureIsNotNull;
            Assert.Throws<ArgumentNullException>(action.AsActionUsing(instance).AsThrowsDelegate());
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
            Action<object, string> action = BCLExtensions.ObjectExtensions.EnsureIsNotNull;
            Assert.Throws<ArgumentNullException>(action.AsActionUsing(instance,instanceArgumentName).AsThrowsDelegate());
        }

        [Fact]
        public void WhenInstanceIsNullWithNamedArgumentCorrectArgumentNameIsProvidedInException()
        {
            object instance = null;

            Action<object, string> action = BCLExtensions.ObjectExtensions.EnsureIsNotNull;
            var exception = Assert.Throws<ArgumentNullException>(action.AsActionUsing(instance, instanceArgumentName).AsThrowsDelegate());

            Assert.Equal(instanceArgumentName, exception.ParamName);
        }

    }
}

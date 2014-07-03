using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCLExtensions.Tests.ObjectExtensions
{
    [TestClass]
    public class EnsureIsNotNullTests
    {
        private string instanceArgumentName = "instance";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenInstanceIsNullThrowsException()
        {
            object instance = null;
            instance.EnsureIsNotNull();
        }

        [TestMethod]
        public void WhenInstanceIsNotNullThenRunsSuccessfully()
        {
            var instance = new object();
            instance.EnsureIsNotNull();
        }

        [TestMethod]
        public void WhenInstanceIsNotNullWithNamedArgumentThenRunsSuccessfully()
        {
            var instance = new object();
            instance.EnsureIsNotNull(instanceArgumentName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenInstanceIsNullWithNamedArgumentThrowsException()
        {
            object instance = null;
            instance.EnsureIsNotNull(instanceArgumentName);
        }

        [TestMethod]
        public void WhenInstanceIsNullWithNamedArgumentCorrectArgumentNameIsProvidedInException()
        {
            object instance = null;

            try
            {
                instance.EnsureIsNotNull(instanceArgumentName);
                Assert.Fail("Should have thrown Exception");
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual(instanceArgumentName, exception.ParamName);
            }
        }

    }
}

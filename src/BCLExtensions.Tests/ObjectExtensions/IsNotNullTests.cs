using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCLExtensions.Tests.ObjectExtensions
{
    [TestClass]
    public class IsNotNullTests
    {
        [TestMethod]
        public void WhenInstanceIsNullReturnsFalse()
        {
            object instance = null;
            var result = instance.IsNotNull();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenInstanceIsNotNullReturnsTrue()
        {
            var instance = new Object();
            var result = instance.IsNotNull();

            Assert.IsTrue(result);
        }
    }
}
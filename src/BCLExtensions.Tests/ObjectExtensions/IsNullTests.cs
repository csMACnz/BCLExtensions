using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCLExtensions.Tests.ObjectExtensions
{
    [TestClass]
    public class IsNullTests
    {
        [TestMethod]
        public void WhenInstanceIsNullReturnsTrue()
        {
            object instance = null;
            var result = instance.IsNull();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenInstanceIsNotNullReturnsFalse()
        {
            var instance = new Object();
            var result = instance.IsNull();

            Assert.IsFalse(result);
        }
    }
}

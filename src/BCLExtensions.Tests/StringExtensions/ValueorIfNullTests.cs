using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLExtensions.Tests.StringExtensions
{
    [TestClass]
    public class ValueorIfNullTests
    {
        [TestClass]
        public class WithNullInputString
        {
            private readonly string input = null;

            [TestMethod]
            public void DefaultStringReturnsDefaultString()
            {
                string expected = "(Default)";
                var result = input.ValueOrIfNull(expected);
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void NullDefaultStringThrowsException()
            {
                var result = input.ValueOrIfNull(null);
            }

            [TestMethod]
            public void EmptyDefaultStringReturnsEmptyString()
            {
                var result = input.ValueOrIfNull(string.Empty);
                Assert.AreEqual(string.Empty, result);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WithNonNullInputAndNullDefaultStringThrowsException()
        {
            var input = "Test";
            var result = input.ValueOrIfNull(null);
        }

        [TestMethod]
        public void WithEmptyStringReturnsEmptyString()
        {
            string input = "";
            var result = input.ValueOrIfNull("(Default)");
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void WithStringEmptyReturnsEmptyString()
        {
            string input = string.Empty;
            var result = input.ValueOrIfNull("(Default)");
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void WithWhitespaceReturnsInputString()
        {
            string input = "   ";
            var result = input.ValueOrIfNull("(Default)");
            Assert.AreEqual(input, result);
        }
    }
}

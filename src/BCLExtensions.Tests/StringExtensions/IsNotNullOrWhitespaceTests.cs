using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLExtensions.Tests.StringExtensions
{
    [TestClass]
    public class IsNotNullOrWhitespaceTests
    {
        [TestMethod]
        public void WhenInputHasContentThenReturnsTrue()
        {
            string input = "Test";
            var result = input.IsNotNullOrWhitespace();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenInputNullThenReturnsFalse()
        {
            string input = null;
            var result= input.IsNotNullOrWhitespace();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenInputIsStringEmptyThenReturnsFalse()
        {
            string input = string.Empty;
            var result = input.IsNotNullOrWhitespace();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenInputIsEmptyStringThenReturnsFalse()
        {
            string input = "";
            var result = input.IsNotNullOrWhitespace();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenInputIsWhitespaceThenReturnsFalse()
        {
            string input = "    ";
            var result = input.IsNotNullOrWhitespace();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenInputIsNewlineThenReturnsFalse()
        {
            string input = "\n";
            var result = input.IsNotNullOrWhitespace();
            Assert.IsFalse(result);
        }
    }
}

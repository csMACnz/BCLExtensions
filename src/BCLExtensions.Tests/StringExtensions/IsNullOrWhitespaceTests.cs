using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLExtensions.Tests.StringExtensions
{
    [TestClass]
    public class IsNullOrWhitespaceTests
    {
        [TestMethod]
        public void WhenInputHasContentThenReturnsFalse()
        {
            string input = "Test";
            var result = input.IsNullOrWhitespace();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenInputNullThenReturnsTrue()
        {
            string input = null;
            var result= input.IsNullOrWhitespace();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenInputIsStringEmptyThenReturnsTrue()
        {
            string input = string.Empty;
            var result = input.IsNullOrWhitespace();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenInputIsEmptyStringThenReturnsTrue()
        {
            string input = "";
            var result = input.IsNullOrWhitespace();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenInputIsWhitespaceThenReturnsTrue()
        {
            string input = "    ";
            var result = input.IsNullOrWhitespace();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenInputIsNewlineThenReturnsTrue()
        {
            string input = "\n";
            var result = input.IsNullOrWhitespace();
            Assert.IsTrue(result);
        }
    }
}

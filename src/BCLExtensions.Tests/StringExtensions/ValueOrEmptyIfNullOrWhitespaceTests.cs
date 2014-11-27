using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLExtensions.Tests.StringExtensions
{
    [TestClass]
    public class ValueOrEmptyIfNullOrWhitespaceTests
    {
        [TestMethod]
        public void WithEmptyInputStringReturnsEmptyString()
        {
            string input = "";
            var result = input.ValueOrEmptyIfNullOrWhitespace();
            Assert.AreEqual(string.Empty, result);
        }
        
        [TestMethod]
        public void WithNullInputStringReturnsEmptyString()
        {
            string input = null;
            var result = input.ValueOrEmptyIfNullOrWhitespace();
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void WithNewLineInputStringReturnsEmptyString()
        {
            string input = "\n";
            var result = input.ValueOrEmptyIfNullOrWhitespace();
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void WithEmptySpacesInputStringReturnsEmptyString()
        {
            string input = "   ";
            var result = input.ValueOrEmptyIfNullOrWhitespace();
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void WithNonEmptyInputStringReturnsOriginalString()
        {
            string input = "The quick brown fox jumps over the lazy dog.";
            var result = input.ValueOrEmptyIfNullOrWhitespace();
            Assert.AreEqual(input, result);
        }
    }
}

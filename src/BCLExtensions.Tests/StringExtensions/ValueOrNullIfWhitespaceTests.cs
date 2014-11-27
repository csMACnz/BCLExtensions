using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLExtensions.Tests.StringExtensions
{
    [TestClass]
    public class ValueOrNullIfWhitespaceTests
    {
        [TestMethod]
        public void WithEmptyInputStringReturnsNull()
        {
            string input = "";
            var result = input.ValueOrNullIfWhitespace();
            Assert.IsNull(result);
        }
        
        [TestMethod]
        public void WithNullInputStringReturnsNull()
        {
            string input = null;
            var result = input.ValueOrNullIfWhitespace();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void WithNewLineInputStringReturnsNull()
        {
            string input = "\n";
            var result = input.ValueOrNullIfWhitespace();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void WithEmptySpacesInputStringReturnsNull()
        {
            string input = "   ";
            var result = input.ValueOrNullIfWhitespace();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void WithNonEmptyInputStringReturnsOriginalString()
        {
            string input = "The quick brown fox jumps over the lazy dog.";
            var result = input.ValueOrNullIfWhitespace();
            Assert.AreEqual(input, result);
        }
    }
}

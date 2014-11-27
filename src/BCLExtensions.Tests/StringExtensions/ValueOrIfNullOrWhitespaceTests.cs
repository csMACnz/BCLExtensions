using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLExtensions.Tests.StringExtensions
{
    [TestClass]
    public class ValueOrIfNullOrWhitespaceOrWhitespaceTests
    {
        [TestClass]
        public abstract class WithInputStringBase
        {
            protected abstract string input{ get; }

            [TestMethod]
            public void DefaultStringReturnsDefaultString()
            {
                string expected = "(Default)";
                var result = input.ValueOrIfNullOrWhitespace(expected);
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void NullDefaultStringThrowsException()
            {
                var result = input.ValueOrIfNullOrWhitespace(null);
            }

            [TestMethod]
            public void EmptyDefaultStringReturnsEmptyString()
            {
                var result = input.ValueOrIfNullOrWhitespace(string.Empty);
                Assert.AreEqual(string.Empty, result);
            }
        }

        [TestClass]
        public class WithNullInputString : WithInputStringBase
        {
            protected override string input
            {
                get { return null; }
            }
        }

        [TestClass]
        public class WithEmptyInputString : WithInputStringBase
        {
            protected override string input
            {
                get { return string.Empty; }
            }
        }

        [TestClass]
        public class WithWhitespaceInputString : WithInputStringBase
        {
            protected override string input
            {
                get { return "    "; }
            }
        }

        [TestClass]
        public class WithNewlineInputString : WithInputStringBase
        {
            protected override string input
            {
                get { return "\n"; }
            }
        }
        [TestClass]
        public class WithNonNullNonWhitespaceInputString
        {
            private readonly string input = "Test";

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void NullReplacementThrowsArgumentNullException()
            {
                var result = input.ValueOrIfNullOrWhitespace(null);
            }

            [TestMethod]
            public void WithStringEmptyReplacementReturnsInputString()
            {
                var result = input.ValueOrIfNullOrWhitespace(string.Empty);
                Assert.AreEqual(input, result);
            }
            [TestMethod]
            public void WithNonNullNonWhitespaceReplacementReturnsInputString()
            {   
                var result = input.ValueOrIfNullOrWhitespace("(Default)");
                Assert.AreEqual(input, result);
            }
        }
    }
}

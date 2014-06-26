using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BCLExtensions.Tests.StringExtensions
{
    public class FormatWithTests
    {
        [TestClass]
        public class WithNullInputString
        {
            private readonly string _myString = null;

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void NoParametersProvidedThowsArgumentNullException()
            {
                _myString.FormatWith();
            }
        }

        [TestClass]
        public class WithEmptyInputString
        {
            readonly string _myString = string.Empty;

            [TestMethod]
            public void NoParametersProvidedReturnsEmptyOutput()
            {
                
                var formattedString = _myString.FormatWith();
                Assert.AreEqual(string.Empty, formattedString);
            }
           
        }

        [TestClass]
        public class WithInputStringContainingNoParameters
        {
            readonly string _myString = "my string with no parameters";

            [TestMethod]
            public void NoParametersProvidedReturnsOriginalString()
            {
                var formattedString = _myString.FormatWith();
                Assert.AreEqual(_myString, formattedString);
            }

        }

        [TestClass]
        public class WithInputStringContainingOneParameter
        {
            readonly string _myString = "my string has {0}";

            [TestMethod]
            [ExpectedException(typeof(FormatException))]
            public void NoParametersProvidedThrowsFormatException()
            {
                _myString.FormatWith();
            }

            [TestMethod]
            public void OneStringParametersProvidedReturnsWithContainingParameter()
            {
                var stringParameter = "FizzBuzz";
                var formattedString = _myString.FormatWith(stringParameter);
                Assert.IsTrue(formattedString.Contains(stringParameter));
            }
        }
    }
}

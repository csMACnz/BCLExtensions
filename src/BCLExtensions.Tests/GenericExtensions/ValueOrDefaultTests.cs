using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLExtensions.Tests.GenericExtensions
{
    public class ValueOrDefaultTests
    {
        [TestClass]
        public abstract class GivenATOfBase<T> where T : class
        {
            protected abstract T DefaultValue { get; }
            protected abstract T ValidInput { get; }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void WhenInputNullAndDefaultValueIsNullThrowsException()
            {
                T input = null;
                var result = input.GetValueOrDefault(null);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void WhenValidInputAndDefaultValueIsNullThrowsException()
            {
                T input = ValidInput;
                var result = input.GetValueOrDefault(null);
            }

            [TestMethod]
            public void WhenInputIsNotNullThenReturnsInputValue()
            {
                T input = ValidInput;
                var result = input.GetValueOrDefault(DefaultValue);
                Assert.AreEqual(ValidInput, result);
            }

            [TestMethod]
            public void WhenInputIsNullThenReturnsDefaultValue()
            {
                T input = null;
                var result = input.GetValueOrDefault(DefaultValue);
                Assert.AreEqual(DefaultValue, result);
            }
        }

        [TestClass]
        public class GivenATOfString : GivenATOfBase<string>
        {
            protected override string DefaultValue
            {
                get { return "(Default)"; }
            }
            
            protected override string ValidInput
            {
                get { return "Valid Non-null string"; }
            }
        }

        [TestClass]
        public class GivenATOfListOfInt : GivenATOfBase<List<int>>
        {
            private List<int> _defaultList = new List<int>();
            protected override List<int> DefaultValue
            {
                get { return _defaultList; }
            }

            private List<int> _validInput = new List<int>();
            protected override List<int> ValidInput
            {
                get { return _validInput; }
            }
        }

        [TestClass]
        public class GivenATOfObject : GivenATOfBase<object>
        {
            private object _defaultObject = new Object();
            protected override object DefaultValue
            {
                get { return _defaultObject; }
            }

            private object _validInput = new Object();
            protected override object ValidInput
            {
                get { return _validInput; }
            }
        }
    }
}
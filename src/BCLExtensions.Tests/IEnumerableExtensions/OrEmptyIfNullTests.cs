using BCLExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCLExtensions.Tests.IEnumerableExtensions
{
    public class OrEmptyIfNullTests
    {
        [TestClass]
        public abstract class GivenABase<T>
        {
            protected abstract IEnumerable<T> GetEmptyEnumerable();

            protected abstract IEnumerable<T> GetEnumerableWithOneNonNullItem();

            [TestMethod]
            public void WhenNullThenReturnsEmptyEnumerable()
            {
                IEnumerable<T> input = null;
                var result = input.OrEmptyIfNull();
                Assert.IsNotNull(result);
                Assert.AreEqual(0, result.Count());
            }

            [TestMethod]
            public void WhenEmptyThenReturnsOriginalReference()
            {
                IEnumerable<T> input = GetEmptyEnumerable();
                var result = input.OrEmptyIfNull();
                Assert.AreEqual(input, result);
            }

            [TestMethod]
            public void WhenNonEmptyThenReturnsOriginalReference()
            {
                IEnumerable<T> input = GetEnumerableWithOneNonNullItem();
                var result = input.OrEmptyIfNull();
                Assert.AreEqual(input, result);
            }
        }

        [TestClass]
        public abstract class GivenAnEnumerableOfBase<T>: GivenABase<T>
        {
            protected override IEnumerable<T> GetEmptyEnumerable()
            {
                return Enumerable.Empty<T>();
            }

            protected override IEnumerable<T> GetEnumerableWithOneNonNullItem()
            {
                return Enumerable.Range(1, 1).Select(n => CreateItem());
            }

            protected abstract T CreateItem();
        }

        [TestClass]
        public class GivenAnEnumerableOfString: GivenAnEnumerableOfBase<string>
        {
            protected override string CreateItem()
            {
                return "Test string";
            }
        }

        [TestClass]
        public class GivenAnEnumerableOfInt : GivenAnEnumerableOfBase<int>
        {
            protected override int CreateItem()
            {
                return 42;
            }
        }

        [TestClass]
        public abstract class GivenAnArrayOfBase<T> : GivenABase<T>
        {
            protected override IEnumerable<T> GetEmptyEnumerable()
            {
                return new T[0];
            }

            protected override IEnumerable<T> GetEnumerableWithOneNonNullItem()
            {
                return new[] { CreateItem() };
            }

            protected abstract T CreateItem();
        }

        [TestClass]
        public class GivenAnArrayOfString: GivenAnArrayOfBase<string>
        {
            protected override string CreateItem()
            {
                return "Test string";
            }
        }

        [TestClass]
        public class GivenAnArrayOfInt : GivenAnArrayOfBase<int>
        {
            protected override int CreateItem()
            {
                return 42;
            }
        }

        [TestClass]
        public abstract class GivenAListOfBase<T> : GivenABase<T>
        {
            protected override IEnumerable<T> GetEmptyEnumerable()
            {
                return new List<T>();
            }

            protected override IEnumerable<T> GetEnumerableWithOneNonNullItem()
            {
                return new[] { CreateItem() };
            }

            protected abstract T CreateItem();
        }

        [TestClass]
        public class GivenAListOfString : GivenAListOfBase<string>
        {
            protected override string CreateItem()
            {
                return "Test string";
            }
        }

        [TestClass]
        public class GivenAListOfInt : GivenAListOfBase<int>
        {
            protected override int CreateItem()
            {
                return 42;
            }
        }

        [TestClass]
        public abstract class GivenADictionaryOfBase<T> : GivenABase<KeyValuePair<object,T>>
        {
            protected override IEnumerable<KeyValuePair<object, T>> GetEmptyEnumerable()
            {
                return new Dictionary<object, T>();
            }

            protected override IEnumerable<KeyValuePair<object, T>> GetEnumerableWithOneNonNullItem()
            {
                return new Dictionary<object, T> { { new object(), CreateItem() } };
            }

            protected abstract T CreateItem();
        }

        [TestClass]
        public class GivenADictionaryOfObjectString : GivenADictionaryOfBase<string>
        {
            protected override string CreateItem()
            {
                return "Test string";
            }
        }

        [TestClass]
        public class GivenADictionaryOfObjectInt : GivenADictionaryOfBase<int>
        {
            protected override int CreateItem()
            {
                return 42;
            }
        }
    }
}
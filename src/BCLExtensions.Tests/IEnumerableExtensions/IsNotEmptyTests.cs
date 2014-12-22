using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace BCLExtensions.Tests.IEnumerableExtensions
{
    public class IsNotEmptyTests
    {
        public interface IDataProvider
        {
            object GetPlaceholder();
        }

        public interface IDataProvider<out T> : IDataProvider
        {
            IEnumerable<T> GetEmptyEnumerable();

            IEnumerable<T> GetEnumerableWithOneNonNullItem();
        }

        [Theory]
        [ClassData(typeof(TestPermutations))]
        public void WhenNullThenReturnsTrue<T>(T placeholder, IDataProvider<T> dataProvider)
        {
            IEnumerable<T> input = null;
            var result = input.IsNotEmpty();
            Assert.False(result);
        }

        [Theory]
        [ClassData(typeof(TestPermutations))]
        public void WhenEmptyThenReturnsTrue<T>(T placeholder, IDataProvider<T> dataProvider)
        {
            IEnumerable<T> input = dataProvider.GetEmptyEnumerable();
            var result = input.IsNotEmpty();
            Assert.False(result);
        }

        [Theory]
        [ClassData(typeof(TestPermutations))]
        public void WhenNonEmptyThenReturnsFalse<T>(T placeholder, IDataProvider<T> dataProvider)
        {
            IEnumerable<T> input = dataProvider.GetEnumerableWithOneNonNullItem();
            var result = input.IsNotEmpty();
            Assert.True(result);
        }

        public class TestPermutations : IEnumerable<object[]>
        {
            private readonly List<IDataProvider> _providers = new List<IDataProvider>();
            public TestPermutations()
            {
                _providers.Add(new EnumerableProviderString());
                _providers.Add(new EnumerableProviderInt());
                _providers.Add(new ArrayProviderString());
                _providers.Add(new ArrayProviderInt());
                _providers.Add(new ListProviderString());
                _providers.Add(new ListProviderInt());
                _providers.Add(new DictionaryProviderObjectString());
                _providers.Add(new DictionaryProviderObjectInt());
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                foreach (var provider in _providers)
                {
                    yield return new[] {provider.GetPlaceholder(), provider};
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public abstract class EnumerableProviderBase<T> : IDataProvider<T>
        {
            public IEnumerable<T> GetEmptyEnumerable()
            {
                return Enumerable.Empty<T>();
            }

            public IEnumerable<T> GetEnumerableWithOneNonNullItem()
            {
                return Enumerable.Range(1, 1).Select(n => CreateItem());
            }

            public object GetPlaceholder()
            {
                return CreateItem();
            }

            protected abstract T CreateItem();
        }

        public class EnumerableProviderString : EnumerableProviderBase<string>
        {
            protected override string CreateItem()
            {
                return "Test string";
            }
        }

        public class EnumerableProviderInt : EnumerableProviderBase<int>
        {
            protected override int CreateItem()
            {
                return 42;
            }
        }

        public abstract class ArrayProviderBase<T> : IDataProvider<T>
        {
            public IEnumerable<T> GetEmptyEnumerable()
            {
                return new T[0];
            }

            public IEnumerable<T> GetEnumerableWithOneNonNullItem()
            {
                return new[] { CreateItem() };
            }

            public object GetPlaceholder()
            {
                return CreateItem();
            }

            protected abstract T CreateItem();
        }

        public class ArrayProviderString : ArrayProviderBase<string>
        {
            protected override string CreateItem()
            {
                return "Test string";
            }
        }

        public class ArrayProviderInt : ArrayProviderBase<int>
        {
            protected override int CreateItem()
            {
                return 42;
            }
        }

        public abstract class ListProviderBase<T> : IDataProvider<T>
        {
            public IEnumerable<T> GetEmptyEnumerable()
            {
                return new List<T>();
            }

            public IEnumerable<T> GetEnumerableWithOneNonNullItem()
            {
                return new[] { CreateItem() };
            }

            public object GetPlaceholder()
            {
                return CreateItem();
            }

            protected abstract T CreateItem();
        }

        public class ListProviderString : ListProviderBase<string>
        {
            protected override string CreateItem()
            {
                return "Test string";
            }
        }

        public class ListProviderInt : ListProviderBase<int>
        {
            protected override int CreateItem()
            {
                return 42;
            }
        }

        public abstract class DictionaryProviderBase<T> : IDataProvider<KeyValuePair<object, T>>
        {
            public IEnumerable<KeyValuePair<object, T>> GetEmptyEnumerable()
            {
                return new Dictionary<object, T>();
            }

            public IEnumerable<KeyValuePair<object, T>> GetEnumerableWithOneNonNullItem()
            {
                return new Dictionary<object, T> { { new object(), CreateItem() } };
            }

            public object GetPlaceholder()
            {
                return new KeyValuePair<object, T>(new object(), CreateItem());
            }

            protected abstract T CreateItem();
        }

        public class DictionaryProviderObjectString : DictionaryProviderBase<string>
        {
            protected override string CreateItem()
            {
                return "Test string";
            }
        }

        public class DictionaryProviderObjectInt : DictionaryProviderBase<int>
        {
            protected override int CreateItem()
            {
                return 42;
            }
        }
    }
}

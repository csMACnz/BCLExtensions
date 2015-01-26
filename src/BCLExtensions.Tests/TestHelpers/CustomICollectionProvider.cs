using System.Collections.Generic;

namespace BCLExtensions.Tests.TestHelpers
{
    public class CustomICollectionProvider<T> : IDataProvider<T>
    {
        private readonly IItemProvider<T> _provider;

        public CustomICollectionProvider(IItemProvider<T> provider)
        {
            _provider = provider;
        }

        public IEnumerable<T> GetEmptyEnumerable()
        {
            return new CustomICollection<T>();
        }

        public IEnumerable<T> GetEnumerableWithOneNonNullItem()
        {
            return new CustomICollection<T> { _provider.CreateItem() };
        }

        public object GetPlaceholder()
        {
            return _provider.CreateItem();
        }
    }
}
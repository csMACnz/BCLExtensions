using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Extensions;

namespace BCLExtensions.Tests.TestHelpers
{
    public class EnumerablePermutationDataAttribute : DataAttribute
    {
        private readonly List<IDataProvider> _providers = new List<IDataProvider>();

        public EnumerablePermutationDataAttribute()
        {
            _providers.Add(new EnumerableProvider<string>(new StringProvider()));
            _providers.Add(new EnumerableProvider<int>(new IntProvider()));
            _providers.Add(new ArrayProvider<string>(new StringProvider()));
            _providers.Add(new ArrayProvider<int>(new IntProvider()));
            _providers.Add(new ListProvider<string>(new StringProvider()));
            _providers.Add(new ListProvider<int>(new IntProvider()));
            _providers.Add(new DictionaryProvider<string>(new StringProvider()));
            _providers.Add(new DictionaryProvider<int>(new IntProvider()));
        }

        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest, Type[] parameterTypes)
        {
            return _providers.Select(provider => new object[] {provider.GetPlaceholder(), provider});
        }
    }
}
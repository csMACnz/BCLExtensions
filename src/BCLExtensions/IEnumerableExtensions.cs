using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="IEnumerable<T>"/> class.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Determines whether a sequence is null or empty
        /// </summary>
        /// <typeparam name="TItem">The type contained in the collection</typeparam>
        /// <param name="items">The collection to check</param>
        /// <returns>true if items is null or empty, otherwise false</returns>
        public static bool IsNullOrEmpty<TItem>(this IEnumerable<TItem> items)
        {
            if (items == null) return true;

            if (items is TItem[])
            {
                return ((TItem[])items).Length == 0;
            }

            if (items is ICollection<TItem>)
            {
                return ((ICollection<TItem>)items).Count == 0;
            }

            if (items is ICollection)
            {
                return ((ICollection)items).Count == 0;
            }

            return !items.Any();
        }

        /// <summary>
        /// Take a collection, and returns it if it has items, or returns null.
        /// </summary>
        /// <typeparam name="TItem">The type contained in the collection</typeparam>
        /// <param name="items">The collection to check</param>
        /// <returns>null if null or empty, otherwise the original collection</returns>
        public static IEnumerable<TItem> OrNullIfEmpty<TItem>(this IEnumerable<TItem> items)
        {
            var isEmpty = IsNullOrEmpty(items);

            if (isEmpty) return null;
            
            return items;
        }
    }
}

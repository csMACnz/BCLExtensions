using System;
using System.Linq;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="System.Array"/> class.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Sets all the elements in an array to zero, false, or null, depending on their default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        public static void Clear<T>(this T[] items)
        {
            Array.Clear(items, 0, items.Length);
        }

        /// <summary>
        /// Ensures the array result either has items, or references null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns>null if items is empty or null, otherwise the array is returned.</returns>
        public static T[] OrNullIfEmpty<T>(this T[] items)
        {
            if (items != null && items.Any(i => i != null))
            {
                return items;
            }
            return null;
        }

        /// <summary>
        /// Ensures the array result is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns>an empty array if null, otherwise the array is returned.</returns>
        public static T[] OrEmptyIfNull<T>(this T[] items)
        {
            return items ?? new T[0];
        }
    }
}

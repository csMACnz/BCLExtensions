using System;
using System.Linq;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="System.Array"/> class.
    /// </summary>
    public static class ArrayExtensions
    {
        public static void Clear<T>(this T[] items)
        {
            Array.Clear(items, 0, items.Length);
        }

        public static T[] OrNullIfEmpty<T>(this T[] items)
        {
            if (items != null && items.Any(i => i != null))
            {
                return items;
            }
            return null;
        }

        public static T[] OrEmptyIfNull<T>(this T[] items)
        {
            return items ?? new T[0];
        }
    }
}

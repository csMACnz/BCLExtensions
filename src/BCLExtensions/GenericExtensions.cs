using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods that can be applied Generically.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Takes a reference type, and returns it, or default if the reference type is null.
        /// </summary>
        /// <typeparam name="T">Type of the item</typeparam>
        /// <param name="item">The item to check</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>item if not null; otherwise defaultValue</returns>
        public static T GetValueOrDefault<T>(this T item, T defaultValue) where T : class
        {
            if (defaultValue == null) throw new ArgumentNullException("defaultValue");
            if (item != null) return item;
            return defaultValue;
        }

        /// <summary>
        /// Pipes through T and if the predicate is met, pipes it through func.
        /// Otherwise the original T is returned.
        /// </summary>
        /// <typeparam name="T">Type of the item</typeparam>
        /// <param name="item">The item.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="func">The function.</param>
        /// <returns></returns>
        public static T When<T>(this T item, Func<T, bool> predicate, Func<T, T> func)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (func == null) throw new ArgumentNullException("func");
            if (predicate(item))
            {
                item = func(item);
            }
            return item;
        }
    }
}

using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods that can be applied Generically.
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Takes a reference type, and returns it, or default if the reference type is null
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
        /// When the predicate returns true, pipes the data through the transform function.
        /// </summary>
        /// <typeparam name="T">The Type of the value</typeparam>
        /// <param name="value">The value to process.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="function">The function that runs when the predicate is true.</param>
        /// <returns>The original value if the predicate is false, otherwise the result of the function.</returns>
        public static T When<T>(this T value, Func<T, bool> predicate, Func<T, T> function)
        {
            if (predicate(value))
            {
                return function(value);
            }
            return value;
        }

        /// <summary>
        /// When the predicate is true, executes the action.
        /// </summary>
        /// <typeparam name="T">The Type of the value</typeparam>
        /// <param name="value">The value to process.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="function">The function.</param>
        /// <returns>The original value.</returns>
        public static T When<T>(this T value, Func<T, bool> predicate, Action<T> function)
        {
            if (predicate(value))
            {
                function(value);
            }
            return value;
        }
    }
}

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
    }
}

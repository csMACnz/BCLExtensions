using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="System.Type"/> class.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Checks if the value is of the exact type of the Generic type T.
        /// </summary>
        /// <param name="value">The value whose type is being checked.</param>
        /// <returns>true if value is not null and the exact type of value matches T, otherwise false.</returns>
        public static bool IsOfType<T>(this object value)
        {
            if (value == null) return false;
            return value.GetType() == typeof(T);
        }

        /// <summary>
        /// Determines whether this Type allows the assignment of the <value>null</value> Value.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static bool IsNullable(this Type type)
        {
            if(type == null) throw new ArgumentNullException("type");

            return !type.IsValueType || Nullable.GetUnderlyingType(type) != null;
        }
    }
}

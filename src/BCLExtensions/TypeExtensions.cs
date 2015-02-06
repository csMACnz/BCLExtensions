using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}

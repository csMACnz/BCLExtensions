using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="TimeSpan"/> type.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Substracts the specified duration from the current DateTime.Now value.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <returns>The calculated Result DateTime.</returns>
        public static DateTime Ago(this TimeSpan duration)
        {
            return DateTime.Now - duration;
        }
    }
}

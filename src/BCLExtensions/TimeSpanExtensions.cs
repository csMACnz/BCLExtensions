using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="TimeSpan"/> type.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Adds the specified duration from the provided <see cref="System.DateTime" />.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <param name="dateTime">The date time.</param>
        /// <returns>The calculated Result DateTime.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DateTime After(this TimeSpan duration, DateTime dateTime)
        {
            return dateTime + duration;
        }

        /// <summary>
        /// Substracts the specified duration from the current DateTime.Now value.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <returns>The calculated Result DateTime.</returns>
        public static DateTime Ago(this TimeSpan duration)
        {
            return DateTime.Now - duration;
        }

        /// <summary>
        /// Substracts the specified duration from the provided <see cref="System.DateTime" />.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <param name="dateTime">The date time.</param>
        /// <returns>The calculated Result DateTime.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DateTime Before(this TimeSpan duration, DateTime dateTime)
        {
            return dateTime - duration;
        }

        /// <summary>
        /// Adds the specified duration from the current DateTime.Now value.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <returns>The calculated Result DateTime.</returns>
        public static DateTime FromNow(this TimeSpan duration)
        {
            return DateTime.Now + duration;
        }
    }
}

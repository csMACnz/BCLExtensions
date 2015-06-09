using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for <see cref="int"/> that return <see cref="TimeSpan"/> values.
    /// </summary>
    public static class IntTimespanExtensions
    {
        /// <summary>
        /// The specified number in days as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="numberOfDays">The number of days.</param>
        /// <returns>The <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan Day(this int numberOfDays)
        {
            return Days(numberOfDays);
        }

        /// <summary>
        /// The specified number in days as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="numberOfDays">The number of days.</param>
        /// <returns>The <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan Days(this int numberOfDays)
        {
            return new TimeSpan(numberOfDays, 0, 0, 0);
        }

        /// <summary>
        /// Determines whether the number of days is valid for time span.
        /// </summary>
        /// <param name="numberOfDays">The number of days.</param>
        /// <returns>true if number is valid, otherwise false.</returns>
        public static bool IsAValidNumberOfDaysForTimeSpan(this int numberOfDays)
        {
            return TimeSpan.MinValue.TotalDays <= numberOfDays && numberOfDays <= TimeSpan.MaxValue.TotalDays;
        }
    }
}

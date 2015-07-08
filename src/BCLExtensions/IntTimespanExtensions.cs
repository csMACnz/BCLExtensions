using System;

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
        /// The specified number in hours as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="numberOfHours">The number of hours.</param>
        /// <returns>The <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan Hour(this int numberOfHours)
        {
            return new TimeSpan(numberOfHours, 0, 0);
        }

        /// <summary>
        /// The specified number in hours as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="numberOfHours">The number of hours.</param>
        /// <returns>The <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan Hours(this int numberOfHours)
        {
            return new TimeSpan(numberOfHours, 0, 0);
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

        /// <summary>
        /// Determines whether the number of hours is valid for time span.
        /// </summary>
        /// <param name="numberOfHours">The number of hours.</param>
        /// <returns>true if number is valid, otherwise false.</returns>
        public static bool IsAValidNumberOfHoursForTimeSpan(this int numberOfHours)
        {
            return TimeSpan.MinValue.TotalHours <= numberOfHours && numberOfHours <= TimeSpan.MaxValue.TotalHours;
        }

        /// <summary>
        /// The specified number in minutes as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="numberOfMilliseconds">The number of minutes.</param>
        /// <returns>The <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan Millisecond(this int numberOfMilliseconds)
        {
            return new TimeSpan(0, 0, 0, 0, numberOfMilliseconds);
        }

        /// <summary>
        /// The specified number in minutes as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="numberOfMilliseconds">The number of minutes.</param>
        /// <returns>The <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan Milliseconds(this int numberOfMilliseconds)
        {
            return new TimeSpan(0, 0, 0, 0, numberOfMilliseconds);
        }

        /// <summary>
        /// The specified number in minutes as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="numberOfMinutes">The number of minutes.</param>
        /// <returns>The <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan Minute(this int numberOfMinutes)
        {
            return new TimeSpan(0, numberOfMinutes, 0);
        }

        /// <summary>
        /// The specified number in minutes as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="numberOfMinutes">The number of minutes.</param>
        /// <returns>The <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan Minutes(this int numberOfMinutes)
        {
            return new TimeSpan(0, numberOfMinutes, 0);
        }

        /// <summary>
        /// The specified number in seconds as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="numberOfSeconds">The number of seconds.</param>
        /// <returns>The <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan Second(this int numberOfSeconds)
        {
            return new TimeSpan(0, 0, numberOfSeconds);
        }

        /// <summary>
        /// The specified number in seconds as a <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="numberOfSeconds">The number of seconds.</param>
        /// <returns>The <see cref="TimeSpan"/> representation.</returns>
        public static TimeSpan Seconds(this int numberOfSeconds)
        {
            return new TimeSpan(0, 0, numberOfSeconds);
        }
    }
}

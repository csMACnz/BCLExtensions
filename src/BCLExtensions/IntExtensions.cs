using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="int"/> class.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Determines whether the value is inclusively between the lower and upper limit.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lowerLimit">The lower limit.</param>
        /// <param name="upperLimit">The upper limit.</param>
        /// <returns>true is value is between or equal to lower and upper limit, otherwise false.</returns>
        /// <exception cref="InvalidOperationException">When lowerLimit is greater than upperLimit.</exception>
        public static bool IsBetween(this int value, int lowerLimit, int upperLimit)
        {
            if(upperLimit<lowerLimit)throw new InvalidOperationException("The upperLimit cannot be less than the lowerLimit.");
            return lowerLimit <= value && value <= upperLimit;
        }

        /// <summary>
        /// Determines whether [is between exclusive] [the specified lower limit].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lowerLimit">The lower limit.</param>
        /// <param name="upperLimit">The upper limit.</param>
        /// <returns>true is value is between lower and upper limit, otherwise false.</returns>
        /// <exception cref="InvalidOperationException">When lowerLimit is greater than upperLimit.</exception>
        public static bool IsBetweenExclusive(this int value, int lowerLimit, int upperLimit)
        {
            if (upperLimit < lowerLimit) throw new InvalidOperationException("The upperLimit cannot be less than the lowerLimit.");
            return lowerLimit < value && value < upperLimit;
        }
    }
}

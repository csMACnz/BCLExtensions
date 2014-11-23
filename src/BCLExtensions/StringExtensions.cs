using System;

namespace BCLExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces format items in the string with the string representation of a corresponding object from the provided parameters.
        /// </summary>
        /// <param name="input">The parameterised string.</param>
        /// <param name="stringParameter">The parameters.</param>
        /// <returns></returns>
        /// <remarks>This is a fluent version of the String.Format static method.</remarks>
        /// <exception cref="System.ArgumentNullException">thrown when input is null, since it is required.</exception>
        /// <exception cref="System.FormatException">Thrown When more parameters than expected are provided.</exception>
        public static string FormatWith(this string input, params object[] stringParameter)
        {
            return String.Format(input, stringParameter);
        }

        public static string ValueOrEmptyIfNull(this string input)
        {
            if (input == null)
            {
                return string.Empty;
            }
            return input;
        }
    }
}

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
        /// <returns>The formatted string</returns>
        /// <remarks>This is a fluent version of the String.Format static method.</remarks>
        /// <exception cref="System.ArgumentNullException">thrown when input is null, since it is required.</exception>
        /// <exception cref="System.FormatException">Thrown When more parameters than expected are provided.</exception>
        public static string FormatWith(this string input, params object[] stringParameter)
        {
            return String.Format(input, stringParameter);
        }

        /// <summary>
        /// Indicates whether the string is not null, not empty and not only of whitespace characters.
        /// </summary>
        /// <param name="input">The string to check</param>
        /// <returns>true if not null and contains non-whitespace characters; otherwise false</returns>
        public static bool IsNotNullOrWhitespace(this string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Indicates whether the string is null, empty or consists only of whitespace characters.
        /// </summary>
        /// <param name="input">The string to check</param>
        /// <returns>true if null, empty, or whitespace; otherwise false</returns>
        public static bool IsNullOrWhitespace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Gets the the left most characters from the input string to a given length.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="length">The length.</param>
        /// <returns>The substring from the left of the string.</returns>
        /// <remarks>When the input length is shorter than the requested length, the original string is returned.</remarks>
        /// <exception cref="System.ArgumentNullException">Thrown when input is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when length is less than zero.</exception>
        public static string Left(this string input, int length)
        {
            input.EnsureIsNotNull("input");
            return length >= input.Length
                ? input
                : input.Substring(0, length);
        }

        /// <summary>
        /// Removes surrounding double or single quotes from a string, if applicable.
        /// </summary>
        /// <param name="value">The string to process.</param>
        /// <returns>input with quotes removed if surrounded by quotes; otherwise original value is returned</returns>
        public static string Unquoted(this string value)
        {
            if (value == null) return null;
            if (value.Length < 2) return value;

            const char singleQuote = '\'';
            const char doubleQuote = '"';
            if ((value[0] == doubleQuote && value[value.Length - 1] == doubleQuote)
                || (value[0] == singleQuote && value[value.Length - 1] == singleQuote))
            {
                return value.Substring(1, value.Length - 2);
            }
            return value;
        }

        /// <summary>
        /// Takes the input string and returns the same string, or empty string if null 
        /// </summary>
        /// <param name="input">The string to process</param>
        /// <returns>An empty string if input is null; otherwise input</returns>
        public static string ValueOrEmptyIfNull(this string input)
        {
            if (input == null)
            {
                return string.Empty;
            }
            return input;
        }

        /// <summary>
        /// Takes the input string and returns the same string, or empty string if null or whitespace
        /// </summary>
        /// <param name="input">The string to process</param>
        /// <returns>An empty string if input is null, or whitespace; othewise input</returns>
        public static string ValueOrEmptyIfNullOrWhitespace(this string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            return input;
        }

        /// <summary>
        /// Takes the input string and returns the same string, or the replacement 
        /// string if input is null
        /// </summary>
        /// <param name="value">The string to process</param>
        /// <param name="replacement">A replacement string if required</param>
        /// <returns>input if it is not null; otherwise replacement</returns>
        /// <exception cref="System.ArgumentNullException">thrown when replacement is null, since it is required.</exception>
        public static string ValueOrIfNull(this string value, string replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            if (value == null) return replacement;
            return value;
        }

        /// <summary>
        /// Takes the input string and returns the same string, or the replacement 
        /// string if input is null, empty, or contains only whitespace characters
        /// </summary>
        /// <param name="value">The string to process</param>
        /// <param name="replacement">A replacement string if required</param>
        /// <returns>input if it is not null and not whitespace; otherwise replacement</returns>
        /// <exception cref="System.ArgumentNullException">thrown when replacement is null, since it is required.</exception>
        public static string ValueOrIfNullOrWhitespace(this string value, string replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            if (String.IsNullOrWhiteSpace(value)) return replacement;
            return value;
        }

        /// <summary>
        /// Takes the input string and returns the same string, or null if the string 
        /// has no non-whitespace characters
        /// </summary>
        /// <param name="value">The string to process</param>
        /// <returns>input if it contains non-whitespace characters; otherwise null</returns>
        public static string ValueOrNullIfWhitespace(this string value)
        {
            if (value == null || String.IsNullOrWhiteSpace(value)) return null;
            return value;
        }
    }
}

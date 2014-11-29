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

        public static bool IsNotNullOrWhitespace(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        public static bool IsNullOrWhitespace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
        
        public static string ValueOrEmptyIfNull(this string input)
        {
            if (input == null)
            {
                return string.Empty;
            }
            return input;
        }

        public static string ValueOrEmptyIfNullOrWhitespace(this string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            return input;
        }

        public static string ValueOrNullIfWhitespace(this string value)
        {
            if (value == null || String.IsNullOrWhiteSpace(value)) return null;
            return value;
        }

        public static string ValueOrIfNull(this string value, string replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            if (value == null) return replacement;
            return value;
        }

        public static string ValueOrIfNullOrWhitespace(this string value, string replacement)
        {
            if (replacement == null) throw new ArgumentNullException("replacement");
            if (String.IsNullOrWhiteSpace(value)) return replacement;
            return value;
        }
    }
}

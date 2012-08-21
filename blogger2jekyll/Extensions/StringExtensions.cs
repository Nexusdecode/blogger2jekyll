using System;

namespace blogger2jekyll.Extensions
{
    /// <summary>
    /// Contains <see cref="string"/> extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks for a null or empty string and optionally trims the string before testing.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns><c>true</c> if the string is null or emtpy; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmptyTrimmed(this string s)
        {
            return String.IsNullOrEmpty((s != null) ? s.Trim() : s);
        }

        /// <summary>
        /// Checks for a null or empty string and optionally trims the string before testing.
        /// </summary>
        /// <param name="param">The string.</param>
        /// <exception cref="ArgumentNullException"><b>param</b> was null.</exception>
        public static void CheckNullOrEmpty(this string param)
        {
            param.CheckNullOrEmpty(null);
        }

        /// <summary>
        /// Checks parameter for null and throws <code>ArgumentNullException</code> if null.
        /// </summary>
        /// <param name="param">The string.</param>
        /// <param name="paramName">The name of the parameter to check.</param>
        /// <exception cref="ArgumentNullException"><b>param</b> was null.</exception>
        /// <exception cref="ArgumentException"><b>param</b> was empty.</exception>
        public static void CheckNullOrEmpty(this string param, string paramName)
        {
            if (param == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if (param.IsNullOrEmptyTrimmed())
            {
                throw new ArgumentException("Value cannot be empty", paramName);
            }
        }
    }
}

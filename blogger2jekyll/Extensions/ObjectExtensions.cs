using System;

namespace blogger2jekyll.Extensions
{
    /// <summary>
    /// Contains <see cref="object"/> extension methods.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Checks for and throws an <see cref="ArgumentNullException"/> if the object is null.
        /// </summary>
        /// <param name="param">The <see cref="object"/>.</param>
        /// <exception cref="ArgumentNullException"><b>parm</b> was null.</exception>
        public static void CheckNull(this object param)
        {
            param.CheckNull(null);
        }

        /// <summary>
        /// Checks for and throws an <see cref="ArgumentNullException"/> if the object is null.
        /// </summary>
        /// <param name="param">The <see cref="object"/>.</param>
        /// <param name="parmName">Name of the parameter to check.</param>
        /// <exception cref="ArgumentNullException"><b>param</b> was null.</exception>
        public static void CheckNull(this object param, string parmName)
        {
            if (param == null)
            {
                throw new ArgumentNullException(parmName);
            }
        }
    }
}
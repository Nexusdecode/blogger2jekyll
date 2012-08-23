/* 
 * blogger2jekyll - Blogger to Jekyll conversion utility
 * Copyright (c) 2012 Cargile Techology Group, LLC
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */ 

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
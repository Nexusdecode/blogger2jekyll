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
using blogger2jekyll.Extensions;
using NUnit.Framework;

namespace blogger2jekyll.tests.Extensions
{
    [TestFixture]
    public class StringExtensionsFixture
    {
        [Test]
        public void CheckNullOrEmpty()
        {
            string s1 = string.Empty;
            Assert.Throws<ArgumentException>(() => s1.CheckNullOrEmpty("s1"));
            Assert.Throws<ArgumentException>(() => s1.CheckNullOrEmpty());

            s1 = null;
            Assert.Throws<ArgumentNullException>(() => s1.CheckNullOrEmpty("s1"));
            Assert.Throws<ArgumentNullException>(() => s1.CheckNullOrEmpty());
            
            const string s2 = "not empty";
            Assert.DoesNotThrow(() => s2.CheckNullOrEmpty("s2"));
            Assert.DoesNotThrow(() => s2.CheckNullOrEmpty());
        }
    }
}

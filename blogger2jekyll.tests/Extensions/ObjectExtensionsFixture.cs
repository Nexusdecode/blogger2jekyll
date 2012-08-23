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
    public class ObjectExtensionsFixture
    {
        [Test]
        public void TestIsParameterNull()
        {
            new object().CheckNull();

            object o = null;
            Assert.Throws<ArgumentNullException>(() => o.CheckNull());
        }

        [Test]
        public void TestIsParameterNullWithNull()
        {
            object obj = null;
            Assert.That(() => obj.CheckNull(), Throws.TypeOf<ArgumentNullException>().With.Message.EqualTo("Value cannot be null."));
        }

        [Test]
        public void TestIsParameterNullWithName()
        {
            new object().CheckNull("parameter1");
        }

        [Test]
        public void TestIsParameterNullWithNullAndName()
        {
            object obj = null;
            Assert.That(() => obj.CheckNull("parameter1"), Throws.TypeOf<ArgumentNullException>().With.Message.EqualTo("Value cannot be null.\r\nParameter name: parameter1"));
        }
    }
}

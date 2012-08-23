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
using System.IO;
using System.Linq;
using blogger2jekyll.Blogger;
using blogger2jekyll.Jekyll;
using blogger2jekyll.tests.Blogger;
using NUnit.Framework;

namespace blogger2jekyll.tests.Jekyll
{
    [TestFixture]
    public class XsltOutputBuilderFixture
    {
        [Test]
        public void OutputPosts()
        {
            ExportXmlParser parser = new ExportXmlParser();
            Feed feed = parser.Parse(ExportXmlParserFixture.PathToExportFile);

            Assert.IsNotNull(feed);

            XsltOutputBuilder builder = new XsltOutputBuilder();
            builder.GenerateOutput(feed, string.Empty);

            Assert.AreEqual(feed.Posts.Where(post => post.Type == EntryType.Post).Count(), Directory.GetFiles("_converted/_posts").Count());
            
            Assert.Throws<ArgumentNullException>(() => builder.GenerateOutput(null));
        }
    }
}

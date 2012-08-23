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
using System.Collections.Generic;
using System.Xml.Serialization;

namespace blogger2jekyll.Blogger
{
    /// <summary>
    /// The Blogger export document root. This represents the entire blog.
    /// </summary>
    [XmlRoot(ElementName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class Feed
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the date the feed was last updated.
        /// </summary>
        /// <value>The date of the last update. This will usually be the date the export occured.</value>
        [XmlElement(ElementName = "updated")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        /// <value>The entries.</value>
        [XmlElement(ElementName = "entry")]
        public List<Entry> Posts { get; set; }

        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>The pages.</value>
        [XmlElement(ElementName = "page")]
        public List<Entry> Pages { get; set; }

        /// <summary>
        /// Gets or sets the blog settings.
        /// </summary>
        /// <value>The settings.</value>
        [XmlElement(ElementName = "setting")]
        public List<Entry> Settings { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        [XmlElement(ElementName = "author")]
        public Author Author { get; set; }

        /// <summary>
        /// Gets or sets the generator (exporter) information.
        /// </summary>
        /// <value>The generator.</value>
        [XmlElement(ElementName = "generator")]
        public Generator Generator { get; set; }

        /// <summary>
        /// Gets or sets the link elements.
        /// </summary>
        /// <value>The links.</value>
        [XmlElement(ElementName = "link")]
        public List<Link> Links { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Feed"/> class.
        /// </summary>
        public Feed()
        {
            Posts = new List<Entry>();
            Links = new List<Link>();
            Pages = new List<Entry>();
            Settings = new List<Entry>();
        }
    }
}

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

using System.Xml.Serialization;

namespace blogger2jekyll.Blogger
{
    /// <summary>
    /// A link element.
    /// </summary>
    [XmlRoot(ElementName = "link")]
    public class Link    
    {
        /// <summary>
        /// Gets or sets the relationship.
        /// </summary>
        /// <value>The relationship.</value>
        [XmlAttribute(AttributeName = "rel")]
        public string Rel { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the href.
        /// </summary>
        /// <value>The href.</value>
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
    }
}

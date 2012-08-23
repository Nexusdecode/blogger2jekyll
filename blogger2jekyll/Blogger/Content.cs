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
    /// An entry's associated content.
    /// </summary>
    [XmlRoot(ElementName = "content")]
    public class Content
    {
        /// <summary>
        /// Gets or sets the content type. Likely will always be HTML.
        /// </summary>
        /// <value>The content type.</value>
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the content text.
        /// </summary>
        /// <value>The content.</value>
        [XmlText]
        public string Value { get; set; }
    }
}

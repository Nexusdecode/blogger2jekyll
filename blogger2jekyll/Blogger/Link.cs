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

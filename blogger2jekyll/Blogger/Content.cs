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

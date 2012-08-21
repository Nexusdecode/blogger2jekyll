using System.Xml.Serialization;

namespace blogger2jekyll.Blogger
{
    /// <summary>
    /// Blog export generator.
    /// </summary>
    [XmlRoot(ElementName = "generator")]
    public class Generator
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [XmlAttribute(AttributeName = "version")]
        public float Version { get; set; }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>The URI.</value>
        [XmlAttribute(AttributeName = "uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [XmlText]
        public string Name { get; set; }
    }
}

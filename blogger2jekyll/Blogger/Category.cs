using System.Xml.Serialization;

namespace blogger2jekyll.Blogger
{
    /// <summary>
    /// A category (tag).
    /// </summary>
    [XmlRoot(ElementName = "category")]
    public class Category
    {
        /// <summary>
        /// Gets or sets the scheme.
        /// </summary>
        /// <value>The scheme.</value>
        [XmlAttribute(AttributeName = "scheme")]
        public string Scheme { get; set; }

        /// <summary>
        /// Gets or sets the term.
        /// </summary>
        /// <value>The term.</value>
        [XmlAttribute(AttributeName = "term")]
        public string Term { get; set; }
    }
}

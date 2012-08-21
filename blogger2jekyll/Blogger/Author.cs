using System.Xml.Serialization;

// NOTE: this class will ignore the <gd:image> element, since it's just a link to Blogger's icon.

namespace blogger2jekyll.Blogger
{
    /// <summary>
    /// A blog author.
    /// </summary>
    [XmlRoot(ElementName = "author")]
    public class Author
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>The URI.</value>
        [XmlElement(ElementName = "uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
    }
}

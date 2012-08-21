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
        public List<Entry> Entries { get; set; }

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
            Entries = new List<Entry>();
            Links = new List<Link>();
        }
    }
}

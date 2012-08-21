using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace blogger2jekyll.Blogger
{
    /// <summary>
    /// Entry types.
    /// </summary>
    public enum EntryType
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Layout enty (contains the actual template).
        /// </summary>
        Layout,

        /// <summary>
        /// Settings entry. These contain blog settings and metadata.
        /// </summary>
        Settings,

        /// <summary>
        /// A post.
        /// </summary>
        Post,

        /// <summary>
        /// A comment.
        /// </summary>
        Comment
    }

    /// <summary>
    /// An entry in the export document. This could be a post, could be metadata.
    /// </summary>
    [XmlRoot(ElementName = "entry")]
    public class Entry
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date this entry was published.
        /// </summary>
        /// <value>The published date.</value>
        [XmlElement(ElementName = "published")]
        public DateTime Published { get; set; }

        /// <summary>
        /// Gets or sets the date this entry was last updated.
        /// </summary>
        /// <value>The updated date.</value>
        [XmlElement(ElementName = "updated")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the entry content.
        /// </summary>
        /// <value>The content.</value>
        [XmlElement(ElementName = "content")]
        public Content Content { get; set; }

        /// <summary>
        /// Gets or sets the blog author.
        /// </summary>
        /// <value>The blog author.</value>
        [XmlElement(ElementName = "author")]
        public Author Author { get; set; }

        /// <summary>
        /// Gets the entry type.
        /// </summary>
        /// <value>The type.</value>
        [XmlIgnore]
        public EntryType Type
        {
            get
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    if (Id.Contains("post") && !Categories.All(category => category.Term == "http://schemas.google.com/blogger/2008/kind#comment"))
                    {
                        return EntryType.Post;
                    }

                    if (Id.Contains("post") && Categories.Any(category => category.Term == "http://schemas.google.com/blogger/2008/kind#comment"))
                    {
                        return EntryType.Comment;
                    }

                    if (Id.Contains("layout"))
                    {
                        return EntryType.Layout;
                    }

                    if (Id.Contains("settings"))
                    {
                        return EntryType.Settings;
                    }
                }

                return EntryType.Unspecified;
            }
        }

        /// <summary>
        /// Gets or sets the link elements.
        /// </summary>
        /// <value>The links.</value>
        [XmlElement(ElementName = "link")]
        public List<Link> Links { get; set; }

        /// <summary>
        /// Gets or sets the categories (tags).
        /// </summary>
        /// <value>The categories.</value>
        [XmlElement(ElementName = "category")]
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets other non-specified entry metadata.
        /// </summary>
        /// <value>The metadata.</value>
        [XmlAnyElement]
        public XmlElement[] Metadata { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is a draft.
        /// </summary>
        /// <value><c>true</c> if this instance is a draft; otherwise, <c>false</c>.</value>
        [XmlElement(ElementName = "isDraft")]
        public bool IsDraft
        {
            get
            {
                XmlNode appControlNode = (from meta in Metadata where meta.LocalName == "control" select meta).FirstOrDefault();
                if (null != appControlNode)
                {
                    XPathNavigator navigator = appControlNode.CreateNavigator();
                    if (null != navigator)
                    {
                        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
                        manager.AddNamespace("app", "http://purl.org/atom/app#");

                        XPathNodeIterator draft = navigator.Select("./app:draft", manager);
                        while (draft.MoveNext())
                        {
                            if (draft.Current.Value == "yes")
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            set
            {
                // nothing to do; enables serialization
            }
        }

        /// <summary>
        /// Gets the comment count.
        /// </summary>
        /// <value>The comment count.</value>
        [XmlElement(ElementName = "commentCount")]
        public int CommentCount
        {
            get
            {
                int count = 0;
                XmlNode commentCountNode = (from meta in Metadata where meta.LocalName == "total" select meta).FirstOrDefault();
                if (null != commentCountNode)
                {
                    count = Convert.ToInt32(commentCountNode.Value);
                }

                return count;
            }
            set
            {
                // nothing to do; enables serialization
            }
        }

        /// <summary>
        /// Gets the permalink for this post.
        /// </summary>
        /// <value>The permalink.</value>
        [XmlElement(ElementName = "permalink")]
        public string Permalink
        {
            get
            {
                Link permalinkNode = Links.Where(link => link.Rel == "alternate").FirstOrDefault();
                if (null != permalinkNode && !permalinkNode.Href.Contains("http://"))
                {
                    // first try to use the link element containing a permalink
                    return permalinkNode.Href;
                }

                // otherwise, slug the title
                return SlugTitle();
            }
            set
            {
                // nothing to do; enables serialization
            }
        }

        /// <summary>
        /// Gets the post summary, if it can be determined.
        /// </summary>
        /// <value>The summary.</value>
        [XmlElement(ElementName = "summary")]
        public string Summary
        {
            get
            {
                if (string.IsNullOrEmpty(Content.Value))
                {
                    return string.Empty;
                }

                // if there is a more tag, we'll pull everything before that
                int index = Content.Value.IndexOf("<a name='more'></a>");
                return Content.Value.Substring(0, index > -1 ? index : 160);
            }
        }

        /// <summary>
        /// Slugs the specified title.
        /// </summary>
        /// <returns>A properly slugged title.</returns>
        private string SlugTitle()
        {
            string title = Title;

            title = HttpUtility.HtmlDecode(title.ToLower().Trim());
            title = new string(title.Where(c => !char.IsPunctuation(c) || char.IsSeparator(c)).ToArray());
            title = title.Replace(' ', '-');

            return string.Format("{0}-{1}", Published.ToString("yyyy-MM-dd"), title);
        }
    }
}
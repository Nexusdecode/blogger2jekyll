using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using blogger2jekyll.Extensions;
using log4net;

namespace blogger2jekyll.Blogger
{
    /// <summary>
    /// Parses Blogger XML and converts it to the desired Jekyll format.
    /// </summary>
    public class ExportXmlParser
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Parses the export file at the specified disk path.
        /// </summary>
        /// <param name="diskPathToExportFile">The disk path to the export file.</param>
        public Feed Parse(string diskPathToExportFile)
        {
            diskPathToExportFile.CheckNullOrEmpty("diskPathToExportFile");

            Log.InfoFormat("blogger2jekyll.Blogger.ExportXmlParses conversion started at {0}.", DateTime.Now);
            Log.InfoFormat("Using Blogger import file at {0}", diskPathToExportFile);

            XmlDocument sourceDocument = new XmlDocument();
            sourceDocument.Load(diskPathToExportFile);

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            ns.Add("app", "http://purl.org/atom/app#");

            XmlSerializer serializer = new XmlSerializer(typeof(Feed));
            Feed feed = (Feed)serializer.Deserialize(new StringReader(sourceDocument.OuterXml));

            foreach (Entry entry in feed.Entries)
            {
                entry.Comments = MatchComments(entry, feed);
            }

            Log.InfoFormat("blogger2jekyll.Blogger.ExportXmlParses conversion completed at {0}.", DateTime.Now);
            Log.InfoFormat("The blog {0} was converted.", feed.Title);
            Log.InfoFormat("{0} posts were found in the export file.", feed.Entries.Count);

            return feed;
        }

        /// <summary>
        /// Matches comments to the specified post, if they exist.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="feed">The feed.</param>
        /// <returns>A list of mathing <see cref="Comment"/> entries, if they exist.</returns>
        private List<Comment> MatchComments(Entry entry, Feed feed)
        {
            Debug.Assert(null != entry);
            Debug.Assert(null != feed);

            // TODO: implement
            // TODO: remove the entry from the entries list once it's matched

            return new List<Comment>();
        }
    }
}

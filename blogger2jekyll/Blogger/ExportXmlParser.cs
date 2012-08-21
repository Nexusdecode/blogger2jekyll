using System;
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

            Log.InfoFormat("blogger2jekyll.Blogger.ExportXmlParses conversion completed at {0}.", DateTime.Now);
            Log.InfoFormat("The blog {0} was converted.", feed.Title);
            Log.InfoFormat("{0} posts were found in the export file.", feed.Entries.Count);

            return feed;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

            ProcessComments(feed);
            ProcessPages(feed);
            ProcessSettings(feed);

            Log.InfoFormat("blogger2jekyll.Blogger.ExportXmlParses conversion completed at {0}.", DateTime.Now);
            Log.InfoFormat("The blog {0} was converted.", feed.Title);
            Log.InfoFormat("{0} posts were found in the export file.", feed.Posts.Count);

            return feed;
        }

        /// <summary>
        /// Matches page entries, if they exist.
        /// </summary>
        /// <param name="feed">The feed.</param>
        private void ProcessPages(Feed feed)
        {
            Debug.Assert(null != feed);
            Debug.Assert(null != feed.Posts);

            List<Entry> pages = feed.Posts.Where(entry => entry.Type == EntryType.Page).ToList();
            foreach (Entry page in pages)
            {
                feed.Pages.Add(page);
                feed.Posts.Remove(page);
            }
        }

        /// <summary>
        /// Matches settings entries, if they exist.
        /// </summary>
        /// <param name="feed">The feed.</param>
        private void ProcessSettings(Feed feed)
        {
            Debug.Assert(null != feed);
            Debug.Assert(null != feed.Posts);

            List<Entry> settings = feed.Posts.Where(entry => entry.Type == EntryType.Settings || entry.Type == EntryType.Layout).ToList();
            foreach (Entry page in settings)
            {
                feed.Settings.Add(page);
                feed.Posts.Remove(page);
            }
        }

        /// <summary>
        /// Matches comments to the specified post, if they exist.
        /// </summary>
        /// <param name="feed">The feed.</param>
        private void ProcessComments(Feed feed)
        {
            Debug.Assert(null != feed);
            Debug.Assert(null != feed.Posts);

            List<Entry> allPosts = feed.Posts.Where(entry => entry.Type == EntryType.Post).ToList();
            foreach (Entry postEntry in allPosts)
            {
                if (feed.Posts.Count == 0)
                {
                    // this shouldn't happen, but if it does, there's nothing to do
                    Log.Warn("No entries were available to match.");
                    return;
                }

                int ct = 0;

                // metadata will contain thr:in-reply-to tag; the ref of this tag is the id of the post
                List<Entry> allComments = feed.Posts.Where(entry => entry.Type == EntryType.Comment).ToList();
                foreach (Entry possibleMatch in allComments)
                {
                    if (null != possibleMatch.Metadata)
                    {
                        XmlElement commentNode = possibleMatch.Metadata.Where(node => node.LocalName == "in-reply-to").FirstOrDefault();
                        if (null != commentNode)
                        {
                            string relatedPostId = commentNode.GetAttribute("ref");
                            if (!string.IsNullOrEmpty(relatedPostId) && relatedPostId == postEntry.Id)
                            {
                                // it's a match!
                                postEntry.Comments.Add(possibleMatch);
                                feed.Posts.Remove(possibleMatch); // prune it
                                ct++;
                            }
                        }
                    }
                }

                Log.InfoFormat("{0} comments were matched to the post having id {1}", ct, postEntry.Id);
            }
        }
    }
}

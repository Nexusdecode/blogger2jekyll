using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using System.Web;
using blogger2jekyll.Blogger;
using blogger2jekyll.Extensions;
using log4net;

namespace blogger2jekyll.Jekyll
{
    /// <summary>
    /// A Jekyll output formatter that serializes posts using an XSLT transformation.
    /// </summary>
    public class XsltOutputBuilder
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Generates the Jekyll output from the specified <see cref="Feed"/> using XSLT.
        /// </summary>
        /// <param name="feed">The feed.</param>
        /// <param name="ouputRootPath">The ouput root path.</param>
        /// <param name="fileType">Type of the file.</param>
        public void GenerateOutput(Feed feed, string ouputRootPath = "_converted", string fileType = ".html")
        {
            feed.CheckNull("feed");
            ouputRootPath.CheckNullOrEmpty("ouputRootPath");

            ProcessPosts(feed.Entries, ouputRootPath, fileType);
        }

        /// <summary>
        /// Processes the posts (<see cref="Entry"/> instances).
        /// </summary>
        /// <param name="entries">The entries.</param>
        /// <param name="ouputRootPath">The ouput root path.</param>
        /// <param name="fileType">Type of the file.</param>
        private void ProcessPosts(IEnumerable<Entry> entries, string ouputRootPath, string fileType)
        {
            Debug.Assert(null != entries);
            Debug.Assert(!string.IsNullOrEmpty(ouputRootPath));
            Debug.Assert(!string.IsNullOrEmpty(fileType));

            fileType = fileType.TrimStart(new [] {'.'});
            fileType = string.Concat(".", fileType);

            // NOTE: posts will be written to /%outputrootpath%/_posts

            string postPath = string.Format("{0}/{1}", ouputRootPath, "_posts");
            ClearOutputDirectory(postPath);

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("Jekyll/Xslt/post.html.xslt");

            StringBuilder sb;
            Type postType = typeof(Entry);
            XmlSerializer serializer = new XmlSerializer(postType);
            XmlReader reader;
            XmlWriter writer;

            XsltArgumentList parameters = new XsltArgumentList();
            parameters.AddParam("fileType", string.Empty, fileType);

            int ct = 0;
            foreach(Entry post in entries.Where(p => p.Type == EntryType.Post))
            {
                sb = new StringBuilder();
                using (MemoryStream memStream = new MemoryStream())
                {
                    serializer.Serialize(memStream, post);
#if DEBUG
                    using (StringWriter dbgWriter = new StringWriter())
                    {
                        serializer.Serialize(dbgWriter, post);
                        Debug.WriteLine(dbgWriter.ToString());
                    }
#endif
                    memStream.Position = 0;

                    XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Auto };
                    reader = XmlReader.Create(memStream);
                    writer = XmlWriter.Create(sb, settings);
                    if (null != writer)
                    {


                        xslt.Transform(reader, parameters, writer);
                        writer.Close();
                    }
                    reader.Close();

                    string postOutputPath = string.Format("{0}/{1}{2}", postPath, post.Permalink, fileType);
                    string xml = sb.ToString();

                    Console.WriteLine(xml);
                    File.WriteAllText(postOutputPath, HttpUtility.HtmlDecode(xml));

                    ct++;
                }
            }
        }

        /// <summary>
        /// Clears the output directory.
        /// </summary>
        /// <param name="postPath">The post path.</param>
        private void ClearOutputDirectory(string postPath)
        {
            Debug.Assert(!string.IsNullOrEmpty(postPath));

            if (!Directory.Exists(postPath))
            {
                Directory.CreateDirectory(postPath);
            }
            else
            {
                // clears old files
                foreach (string filename in Directory.GetFiles(postPath))
                {
                    File.Delete(filename);
                }
            }
        }
    }
}
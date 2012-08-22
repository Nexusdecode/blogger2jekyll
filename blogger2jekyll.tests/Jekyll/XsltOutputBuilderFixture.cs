using System.IO;
using System.Linq;
using blogger2jekyll.Blogger;
using blogger2jekyll.Jekyll;
using blogger2jekyll.tests.Blogger;
using NUnit.Framework;

namespace blogger2jekyll.tests.Jekyll
{
    [TestFixture]
    public class XsltOutputBuilderFixture
    {
        [Test]
        public void OutputPosts()
        {
            ExportXmlParser parser = new ExportXmlParser();
            Feed feed = parser.Parse(ExportXmlParserFixture.PathToExportFile);

            Assert.IsNotNull(feed);

            XsltOutputBuilder converter = new XsltOutputBuilder();
            converter.GenerateOutput(feed);

            Assert.AreEqual(feed.Posts.Where(post => post.Type == EntryType.Post).Count(), Directory.GetFiles("_converted/_posts").Count());
        }
    }
}

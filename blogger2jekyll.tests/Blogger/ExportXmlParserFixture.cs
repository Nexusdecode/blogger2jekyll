using System;
using System.Linq;
using blogger2jekyll.Blogger;
using NUnit.Framework;

namespace blogger2jekyll.tests.Blogger
{
    [TestFixture]
    public class ExportXmlParserFixture
    {
        public const string PathToExportFile = "stub/blog-08-19-2012.xml";

        [Test]
        public void Parse()
        {
            ExportXmlParser parser = new ExportXmlParser();
            Feed feed = parser.Parse(PathToExportFile);
            
            Assert.IsNotNull(feed);
            Assert.AreEqual("tag:blogger.com,1999:blog-6103943824397639239.archive", feed.Id);
            Assert.AreEqual(DateTime.Parse("2012-08-19T10:35:18.624-04:00"), feed.Updated);
            Assert.AreEqual("Kristopher Cargile", feed.Title);
           
            Assert.IsNotNull(feed.Links);
            Assert.AreEqual(4, feed.Links.Count);
            Assert.AreEqual("http://schemas.google.com/g/2005#feed", feed.Links.First().Rel);
            Assert.AreEqual("application/atom+xml", feed.Links.First().Type);
            Assert.AreEqual("http://www.kriscargile.com/feeds/archive", feed.Links.First().Href);

            Assert.IsNotNull(feed.Author);
            Assert.AreEqual("Kristopher Cargile", feed.Author.Name);
            Assert.AreEqual("http://www.blogger.com/profile/15499066457899479832", feed.Author.Uri);
            Assert.AreEqual("noreply@blogger.com", feed.Author.Email);

            Assert.IsNotNull(feed.Generator);
            Assert.AreEqual(7.00, feed.Generator.Version);
            Assert.AreEqual("http://www.blogger.com", feed.Generator.Uri);
            Assert.AreEqual("Blogger", feed.Generator.Name);

            Assert.IsNotNull(feed.Entries);
            Assert.AreEqual(213, feed.Entries.Count);

            // spot check a known entry -- it looks like this:

            //<entry>
            //  <id>tag:blogger.com,1999:blog-6103943824397639239.post-7528698379412928294</id>
            //  <published>2011-11-08T21:13:00.001-05:00</published>
            //  <updated>2011-11-09T00:11:14.428-05:00</updated>
            //  <app:control xmlns:app='http://purl.org/atom/app#'>
            //    <app:draft>yes</app:draft>
            //  </app:control>
            //  <category scheme='http://schemas.google.com/g/2005#kind' term='http://schemas.google.com/blogger/2008/kind#post'/>
            //  <category scheme='http://www.blogger.com/atom/ns#' term='Git'/>
            //  <category scheme='http://www.blogger.com/atom/ns#' term='DVCS'/>
            //  <category scheme='http://www.blogger.com/atom/ns#' term='Kiln'/>
            //  <category scheme='http://www.blogger.com/atom/ns#' term='VCS'/>
            //  <category scheme='http://www.blogger.com/atom/ns#' term='linux'/>
            //  <category scheme='http://www.blogger.com/atom/ns#' term='Github'/>
            //  <category scheme='http://www.blogger.com/atom/ns#' term='Hg'/>
            //  <category scheme='http://www.blogger.com/atom/ns#' term='Mercurial'/>
            //  <title type='text'>Converting a Mercurial Repository to Git (Not) on Windows</title>
            //  <content type='html'>Over at &lt;a href="http://www.hipaa.com/" target="_blank"&gt;HIPAA.com&lt;/a&gt;, we've had a bit of a whirlwind tour of version control systems. Our software is built using a bunch of different technologies. Our team is geographically disperse and comprised of several different disciplines, often using different platforms. Not surprisingly, we found that Subversion was a common thread throughout the team. Some quick setup and a handful of low-tech build scripts, and we were off to the races. Life was good.&lt;br /&gt;&lt;br /&gt;As we neared the launch of our training site, however, the pace picked up substantially. Our LMS repository grew quickly, and multiple last minute releases meant dealing with a mess of merging and counterproductive code freezes. Suddenly SVN had become a major bottleneck, especially for folks on the team who found themselves merging code they didn't really understand. Life had suddenly become difficult.&lt;br /&gt;&lt;br /&gt;Meanwhile, &lt;a href="http://dougrohm.com/" target="_blank"&gt;Doug Rohm&lt;/a&gt; was badgering me about a DVCS he'd started using called Mercurial. He kept telling me how fast it was and the ease with which one could branch and merge, and that it would basically solve all of life's problems. I'd heard of it but honestly didn't know much about it, and I was busy.This all sounded like utter bullshit anyways, so I punked it off.&lt;br /&gt;&lt;br /&gt;Incidentally, we had also taken to backlogging new features and collecting bug reports in Fogbugz, and Fog Creek was about to launch a new product called &lt;a href="http://www.fogcreek.com/kiln/" target="_blank"&gt;K&lt;span id="goog_851447654"&gt;&lt;/span&gt;&lt;span id="goog_851447655"&gt;&lt;/span&gt;iln&lt;/a&gt;. Kiln, as it turns out, was a Mercurial implementation with tight Fogbugz integration, complete with a Subversion conversion tool. Within a few days, we had completely switched over.&amp;nbsp;Kiln, like pretty much everything else that comes out of Fog Creek, is fantastic. It integrates seamlessly with Fogbugz and the web-based administration tools are top-notch. But Mercurial itself is something of a DVCS bastard. Once again we were running into roadblocks, this time because of limited tooling support.&lt;br /&gt;&lt;br /&gt;And thusly, we arrived at Git. All the benefits of Mercurial but with ubiquity. I assumed that–because Mercurial is so closely related to Git–the transition would be fairly simple, and I was sadly mistaken. After two solid days of research and countless trial-and-error, I finally had it working, but not without some serious pain. If you're using Windows, you may have your work cut out for you.&lt;br /&gt;&lt;br /&gt;You'll eventually discover that there are four generally accepted, sparsely documented options:&lt;br /&gt;&lt;ol&gt;&lt;li&gt;Don't bother.&lt;/li&gt;&lt;li&gt;Use the &lt;a href="https://bitbucket.org/durin42/hg-git" target="_blank"&gt;Hg-Git Mercurial plugin&lt;/a&gt;&amp;nbsp;(also see&amp;nbsp;&lt;a href="https://github.com/blog/439-hg-git-mercurial-plugin" target="_blank"&gt;this page&lt;/a&gt;).&lt;/li&gt;&lt;li&gt;Use &lt;a href="http://repo.or.cz/w/fast-export.git" target="_blank"&gt;fast-export&lt;/a&gt;&amp;nbsp;(&lt;a href="http://repo.or.cz/w/hg2git.git/" target="_blank"&gt;hg2git&lt;/a&gt;)&amp;nbsp;directly, via &lt;a href="http://cygwin.com/index.html" target="_blank"&gt;Cygwin&lt;/a&gt;, via&amp;nbsp;mysysgit, or&amp;nbsp;a combination of all three.&lt;/li&gt;&lt;li&gt;Forget Windows. Use fast-export on Linux.&lt;/li&gt;&lt;/ol&gt;All other things being equal and with the benefit of hindsight, option number one may very well have been the best choice. If you don't have a very specific reason to switch, seriously consider taking this path. After all, you can congratulate yourself for a job well done and go have a beer &lt;i&gt;right now&lt;/i&gt;.&lt;br /&gt;&lt;br /&gt;Option number two, using Hg-Git, was a dead-end because I could never get dulwich to work correctly on my Windows machine. Apparently there &lt;a href="https://bugs.launchpad.net/dulwich/+bug/512084" target="_blank"&gt;isn't a Windows installer widely available for dulwich&lt;/a&gt;, and using the pure install method died consistently. You could theoretically compile the source yourself using Visual Studio, but this is potentially a very deep rabbit hole. I abandoned this one in pretty short order (unfortunately before I realized that &lt;a href="http://stackoverflow.com/questions/2360944/how-do-i-correctly-install-dulwich-to-get-hg-git-working-on-windows" target="_blank"&gt;TortoiseHg ships with a working dulwich distribution&lt;/a&gt;,&amp;nbsp;potentially a much simpler alternative.)&lt;br /&gt;&lt;br /&gt;That leaves fast-export, which eventually worked out for me in a couple of different ways:&lt;br /&gt;&lt;ul&gt;&lt;li&gt;Because it was already installed, I initially tried to do this using mysysgit (aka Git Bash), the shell that comes with the Windows Git binaries. It worked well for some smaller repositories, but consistently died due to a STATUS_ACCESS_VIOLATION exception on larger repositories with complex branching histories. Again, I abandoned this before doing too much research, but it seems to be a &lt;a href="http://code.google.com/p/msysgit/issues/detail?id=190" target="_blank"&gt;somewhat common issue&lt;/a&gt;.&lt;/li&gt;&lt;li&gt;Using Cygwin I was able to convert a few additional repositories, but the largest still failed with a&amp;nbsp;STATUS_ACCESS_VIOLATION exception and a fairly useless stackdump.&lt;/li&gt;&lt;li&gt;I finally gave up, logged into AWS, and fired up a free-tier Amazon Linux VM. Ten minutes later, I was done.&lt;/li&gt;&lt;/ul&gt;Doing this the Linux way is incredibly simple when you use a disposable VM. The video below demonstrates how to do this using AWS (any reputable vendor should do) by following these steps:&lt;br /&gt;&lt;br /&gt;Fire up VM&lt;br /&gt;Set up certs&lt;br /&gt;Install Hg&lt;br /&gt;Install Git&lt;br /&gt;Install fast-export&lt;br /&gt;Clone Hg&lt;br /&gt;Convert&lt;br /&gt;Rewrite history&lt;br /&gt;Push with tags&lt;br /&gt;Terminate VM&lt;br /&gt;&lt;br /&gt;&lt;br /&gt;&lt;a href="http://hedonismbot.wordpress.com/2008/10/16/hg-fast-export-convert-mercurial-repositories-to-git-repositories/"&gt;http://hedonismbot.wordpress.com/2008/10/16/hg-fast-export-convert-mercurial-repositories-to-git-repositories/&lt;/a&gt;&lt;br /&gt;&lt;a href="http://www.cyberciti.biz/faq/run-execute-sh-shell-script/"&gt;http://www.cyberciti.biz/faq/run-execute-sh-shell-script/&lt;/a&gt;&lt;br /&gt;&lt;a href="http://stackoverflow.com/questions/1389307/convert-a-mercurial-repository-to-git"&gt;http://stackoverflow.com/questions/1389307/convert-a-mercurial-repository-to-git&lt;/a&gt;</content>
            //  <link rel='edit' type='application/atom+xml' href='http://www.blogger.com/feeds/6103943824397639239/posts/default/7528698379412928294'/>
            //  <link rel='self' type='application/atom+xml' href='http://www.blogger.com/feeds/6103943824397639239/posts/default/7528698379412928294'/>
            //  <author>
            //    <name>Kristopher Cargile</name>
            //    <uri>http://www.blogger.com/profile/15499066457899479832</uri>
            //    <email>kristophercargile@gmail.com</email>
            //    <gd:image rel='http://schemas.google.com/g/2005#thumbnail' width='16' height='16' src='http://img2.blogblog.com/img/b16-rounded.gif'/>
            //  </author>
            //  <thr:total>0</thr:total>
            //</entry>

            const string knownId = "tag:blogger.com,1999:blog-6103943824397639239.post-7528698379412928294";

            Entry entry = (from e in feed.Entries where e.Id == knownId select e).First();
            Assert.AreEqual(knownId, entry.Id);
            Assert.AreEqual(DateTime.Parse("2011-11-08T21:13:00.001-05:00"), entry.Published);
            Assert.AreEqual(DateTime.Parse("2011-11-09T00:11:14.428-05:00"), entry.Updated);
            Assert.IsNotNull(entry.Metadata);
            Assert.AreEqual(2, entry.Metadata.Length);
            Assert.IsNotNull(entry.Categories);
            Assert.AreEqual(9, entry.Categories.Count);
            Assert.AreEqual("Converting a Mercurial Repository to Git (Not) on Windows", entry.Title);
            Assert.AreEqual("html", entry.Content.Type);
            Assert.Greater(entry.Content.Value.Length, 0);
            Assert.AreEqual(2, entry.Links.Count);
            Assert.IsNotNull(entry.Author);
            Assert.False(entry.IsPublished);
            Assert.AreEqual(0, entry.CommentCount);

            Assert.Throws<ArgumentException>(() => parser.Parse(string.Empty));
        }
    }
}

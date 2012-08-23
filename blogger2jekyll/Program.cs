using System;
using System.Reflection;
using System.Linq;
using blogger2jekyll.Blogger;
using blogger2jekyll.Jekyll;
using log4net;

namespace blogger2jekyll
{
    /// <summary>
    /// blogger2jekyll command line driver.
    /// </summary>
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            if (args.Contains("/?"))
            {
                Console.WriteLine("\nUsage:\tblogger2jekyll /in:<inputpath> /out:<outputpath>, where");
                Console.WriteLine("\t<inputpath> is the path to your Blogger XML export file");
                Console.WriteLine("\t<outputpath> is the path where exported posts will be written (optional, defaults to _converted)");
            }

            string inputFile = args.Where(a => a.Contains("/in:")).FirstOrDefault();
            if (string.IsNullOrEmpty(inputFile))
            {
                Console.WriteLine("No input file specfied.");
                return;
            }

            ExportXmlParser parser = new ExportXmlParser();
            Feed feed = parser.Parse(inputFile.Split(':')[1]);
            if (null == feed)
            {
                Log.WarnFormat("Export file at {0} does not appear to contain any Blogger data.", inputFile);
                Console.WriteLine("Nothing to parse in the ouput file.");
                return;
            }

            string exportPath = string.Empty;
            string exportArgs = args.Where(a => a.Contains("/out:")).FirstOrDefault();
            if (!string.IsNullOrEmpty(exportArgs))
            {
                exportPath = exportArgs.Split(':')[1];
            }
            XsltOutputBuilder builder = new XsltOutputBuilder();
            builder.GenerateOutput(feed, exportPath);

            string completeMessage = string.Format("Conversion complete. {0} posts were exported to {1}.", feed.Posts.Count, exportPath);
            Log.Info(completeMessage);
            Console.WriteLine(completeMessage);
        }
    }
}
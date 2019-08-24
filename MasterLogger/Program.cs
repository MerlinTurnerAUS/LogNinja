using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MasterLoggerMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupWatchers();
        }

        private static void SetupWatchers()
        {
            // Read config file
            var doc = XDocument.Load("configureLogs.xml");
            string MasterLogFile = doc.Element("sources").Element("masterLog").Value;
            Console.WriteLine("MasterLog location: {0}", MasterLogFile);

            var sources = doc.Descendants("logSource");

            foreach (XElement logSource in sources)
            {
                Console.WriteLine("{0} {1} {2}", logSource.Element("type").Value, logSource.Element("location").Value, logSource.Element("format").Value);
                switch (logSource.Element("type").Value)
                {
                    case "txt":
                        Console.WriteLine("Text file");
                        LogFileHandler lfh = new LogFileHandler(logSource.Element("location").Value, logSource.Element("format").Value, MasterLogFile);
                        break;
                    case "xml":
                        Console.WriteLine("xml file");
                        break;
                }
            }
            
            Console.ReadKey();
        }
    }
}

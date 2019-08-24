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
            string MasterLogLocation = doc.Element("sources").Element("masterLog").Value;

            // Set up MasterLogFile
            MasterLogWriter.masterLogLocation = MasterLogLocation;
            Console.WriteLine("MasterLog location: {0}", MasterLogLocation);

            var sources = doc.Descendants("logSource");

            foreach (XElement logSource in sources)
            {
                
                switch (logSource.Element("type").Value)
                {
                    case "txt":
                        Console.WriteLine("Setting up Text Log file");
                        Console.WriteLine("{0} {1} {2}", logSource.Element("type").Value, logSource.Element("location").Value, logSource.Element("format").Value);
                        LogFileHandler lfh = new LogFileHandler(logSource.Element("location").Value, logSource.Element("format").Value, MasterLogLocation);
                        break;
                    case "dbTable":
                        Console.WriteLine("Setting up db Table logger");

                        dbTableHandler dbTH = new dbTableHandler(logSource.Element("connStr").Value,
                                                                    logSource.Element("query").Value,
                                                                    logSource.Element("mapping").Attribute("time").Value,
                                                                    logSource.Element("mapping").Attribute("output").Value,
                                                                    logSource.Element("mapping").Attribute("error").Value);
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

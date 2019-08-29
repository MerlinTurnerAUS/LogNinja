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
            var configFile = XDocument.Load("configureLogs.xml");
            string MasterLogLocation = configFile.Element("sources").Element("masterLog").Value;

            // Set up MasterLogFile
            MasterLogWriter masterLogger = new MasterLogWriter();
            masterLogger.masterLogLocation = MasterLogLocation;

            Console.WriteLine("MasterLog location: {0}", MasterLogLocation);

            var sources = configFile.Descendants("logSource");

            foreach (XElement logSource in sources)
            {
                
                switch (logSource.Element("type").Value)
                {
                    case "txt":
                        Console.WriteLine("Setting up Text Log file");
                        LogFileHandler lfh = new LogFileHandler(masterLogger, 
                                                                    logSource.Element("location").Value, 
                                                                    logSource.Element("formatString").Value);
                        break;
                    case "dbTable":
                        Console.WriteLine("Setting up db Table logger");

                        dbTableHandler dbTH = new dbTableHandler(masterLogger,
                                                                    logSource.Element("connStr").Value,
                                                                    logSource.Element("query").Value,
                                                                    logSource.Element("formatString").Value,
                                                                    logSource.Element("timeStamp").Value,
                                                                    logSource.Element("errorColumn").Value,
                                                                    logSource.Element("pollingInterval").Value);
                        break;
                    case "xml":
                        Console.WriteLine("Setting up xml file logger");
                        XMLHandler xmlH=new XMLHandler(masterLogger,
                                                                    logSource.Element("location").Value,
                                                                    logSource.Element("formatString").Value,
                                                                    logSource.Element("groupTag").Value,
                                                                    logSource.Element("timeStampTag").Value,
                                                                    logSource.Element("pollingInterval").Value);
                        break;
                    case "csv":
                        Console.WriteLine("Setting up csv file logger");
                        CSVFileHandler textHandler = new CSVFileHandler(masterLogger,
                                                                    logSource.Element("location").Value,
                                                                    logSource.Element("formatString").Value,
                                                                    logSource.Element("ignoreTitleRow").Value);
                        break;
                }
            }
            
            Console.ReadKey();
        }
    }
}

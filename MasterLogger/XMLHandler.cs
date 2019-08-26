using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Linq;
using System.IO;
using System.Timers;

namespace MasterLoggerMonitor
{
    public class XMLHandler
    {
        private MasterLogWriter mlw;
        private string formatStr;
        private string groupTagName;
        private string xmlFileLocation;
        private string timeStampTag;
        private string lastProcessedTime;

        public XMLHandler(MasterLogWriter masterLogger,
                                            string location,
                                            string formatString,
                                            string groupTag,
                                            string timeStamp,
                                            string pollingInterval)
        {
            mlw = masterLogger;
            xmlFileLocation = location;
            formatStr = formatString;
            timeStampTag = timeStamp;
            groupTagName = groupTag;
            InitialProcessXMLFile();
            //SpawnWatcher();
            Timer t = new Timer(Convert.ToDouble(pollingInterval));
            t.Elapsed += ProcessXMLOnChange;
            t.Enabled = true;
        }

        private void ProcessXMLOnChange(object sender, ElapsedEventArgs e)
        {
            var xmlLogfile = XDocument.Load(xmlFileLocation);
            var logEntries = (from x in xmlLogfile.Descendants(groupTagName)
                              where Convert.ToDateTime(x.Element(timeStampTag).Value) > Convert.ToDateTime(lastProcessedTime)
                              select x);
            foreach (XElement logEntry in logEntries)
            {
                int i = 0;
                string[] arguments = new string[logEntry.Elements().Count<XElement>()];
                foreach (XElement field in logEntry.Elements())
                {
                    arguments[i] = field.Value;
                    i++;
                }
                mlw.WriteEntry(string.Format(formatStr, arguments));
                lastProcessedTime = logEntry.Element(timeStampTag).Value;
            }
        }

  
private void InitialProcessXMLFile()
        {
            var xmlLogfile = XDocument.Load(xmlFileLocation);

            var logEntries = xmlLogfile.Descendants(groupTagName);

            foreach (XElement logEntry in logEntries)
            {
                int i = 0;
                string[] arguments = new string[logEntry.Elements().Count<XElement>()];
                foreach (XElement field in logEntry.Elements())
                {
                    arguments[i] = field.Value;
                    i++;
                }
                mlw.WriteEntry(string.Format(formatStr, arguments));
                lastProcessedTime = logEntry.Element(timeStampTag).Value;
            }
        }
    }
}

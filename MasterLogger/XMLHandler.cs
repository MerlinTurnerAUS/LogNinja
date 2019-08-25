using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Linq;

namespace MasterLoggerMonitor
{
    public class XMLHandler
    {
        private MasterLogWriter mlw;
        private string formatStr;
        private string groupTagName;
        
        public XMLHandler(MasterLogWriter masterLogger,
                                            string location,
                                            string formatString,
                                            string groupTag,
                                            string pollingInterval)
        {
            mlw = masterLogger;
            formatStr = formatString;
            groupTagName = groupTag;
            ProcessXMLFile(location, formatString);

        }

        private void ProcessXMLFile(string location, string formatString)
        {
            var xmlLogfile = XDocument.Load(location);

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
                mlw.WriteEntry(string.Format(formatString, arguments));
            }
        }
    }
}

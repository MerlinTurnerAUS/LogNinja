using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MasterLoggerMonitor
{
    public static class MasterLogWriter
    {
        public static string masterLogLocation { get; set; }
        public static void WriteEntry(string Timestamp, string source, string Level, string Output)
        {
            StreamWriter fsWriter = new StreamWriter(masterLogLocation, true);
            fsWriter.WriteLine("{0}, {1}, {2}, {3}",Timestamp,source,Level,Output);
            Console.WriteLine("{0}, {1}, {2}, {3}", Timestamp, source, Level, Output);
            fsWriter.Close();
        }
    }
}

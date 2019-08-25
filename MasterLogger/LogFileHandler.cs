using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;
using System.Threading;

namespace MasterLoggerMonitor
{
    class LogFileHandler
    {
        public string location { get; set; }
        public string[] format { get; set; }
        private MasterLogWriter masterLogger;

        
        public LogFileHandler(MasterLogWriter mlw, string fileLocation, string fileFormat, string masterLogFile)
        {
            location = fileLocation;
            format = fileFormat.Split(',');
            masterLogger = mlw;

            spawnWatcher();
        }

        private async Task spawnWatcher()
        {
            await Task.Run(() => SetUpWatcher());
        }

        private void SetUpWatcher()
        {
            FileInfo fi = new FileInfo(location);

            var lockMe = new object();
            using (var latch = new ManualResetEvent(true))
            using (var fsReader = new FileStream(location, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            using (var fsw = new FileSystemWatcher(fi.DirectoryName,fi.Name))
            {
                fsw.Changed += (s, e) =>
                {
                    lock (lockMe)
                    {
                        if (e.FullPath != location) return;
                        latch.Set();
                    }
                };
                using (var sr = new StreamReader(fsReader))
                    while (true)
                    {
                        latch.WaitOne();
                        lock (lockMe)
                        {
                            String line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                // Process line in log file
                                string[] cols = line.Split(',');

                                string Timestamp="";
                                string Level="";
                                string Output="";

                                // Loop through format array and find where the columns sit so we know what to map to what
                                for(int i=0; i <= format.GetUpperBound(0); i++)
                                {
                                    if (format[i] == "Time")
                                        Timestamp = cols[i];
                                }

                                for (int i = 0; i <= format.GetUpperBound(0); i++)
                                {
                                    if (format[i] == "Level")
                                        Level = cols[i];
                                }

                                for (int i = 0; i <= format.GetUpperBound(0); i++)
                                {
                                    if (format[i] == "Output")
                                        Output = cols[i];
                                }

                                masterLogger.WriteEntry(Timestamp, location, Level.Trim(), Output.Trim());
                            }
                            latch.Set();
                        }
                    }
            }
        }
    }
}


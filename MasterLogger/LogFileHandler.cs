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
    public class LogFileHandler
    {
        private string location;
        private string formatString;
        private MasterLogWriter masterLogger;

        
        public LogFileHandler(MasterLogWriter mlw, string fileLocation, string fileFormat)
        {
            location = fileLocation;
            formatString = fileFormat;
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

                                masterLogger.WriteEntry(string.Format(formatString,cols));
                            }
                            latch.Set();
                        }
                    }
            }
        }
    }
}


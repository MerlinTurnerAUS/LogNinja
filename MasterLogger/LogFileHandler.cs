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
        public string format { get; set; }
        public string masterLog { get; set; }

        public LogFileHandler(string fileLocation, string fileFormat, string masterLogFile)
        {
            location = fileLocation;
            format = fileFormat;
            masterLog = masterLogFile;

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
                                Console.Out.WriteLine(line);
                                StreamWriter fsWriter = new StreamWriter(masterLog, true);
                                fsWriter.WriteLine(line);
                                fsWriter.Close();
                            }
                            latch.Set();
                        }
                    }
            }
        }
    }
}


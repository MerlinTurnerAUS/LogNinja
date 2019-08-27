using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace MasterLoggerMonitor
{
    class TextFileHandler
    {
        private MasterLogWriter mlw;
        private string location;
        private string formatString;
        private bool ignoreFirstLine=false;

        public TextFileHandler(MasterLogWriter masterLogWrtr, string fileLocation, string formatStr, string ignoreTitleRow)
        {
            mlw = masterLogWrtr;
            location = fileLocation;
            formatString = formatStr;
            if (ignoreTitleRow.ToLower() == "yes")
                ignoreFirstLine = true;

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
            using (var fsw = new FileSystemWatcher(fi.DirectoryName, fi.Name))
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
                                object[] args = new object[cols.Length + 1];
                                args[0] = DateTime.Now;
                                cols.CopyTo(args, 1);
                                if (ignoreFirstLine)
                                    ignoreFirstLine = false;
                                else
                                    mlw.WriteEntry(string.Format(formatString, args));
                            }
                            latch.Set();
                        }
                    }
            }
        }
    }
}

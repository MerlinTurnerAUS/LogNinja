using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.ServiceProcess;
using System.Xml.Linq;
using Microsoft.AspNet.SignalR.Hubs;
using System.IO;
using System.Threading;
using System.Timers;

namespace Models
{

    public class LogScanner
    {
        private IHubCallerConnectionContext<dynamic> CallerContext;

        public void SendToSignalRClient(IHubCallerConnectionContext<dynamic> Clients)
        {
            CallerContext = Clients;

            spawnWatcher();
        }


        private async Task spawnWatcher()
        {
            await Task.Run(() => SetUpWatcher());

        }

        private async Task SetUpWatcher()
        {
            FileInfo fi = new FileInfo(@"C:\Temp\MasterLog\MasterLog.log");

            var lockMe = new object();
            using (var latch = new ManualResetEvent(true))
            using (var fsReader = new FileStream(fi.FullName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            using (var fsw = new FileSystemWatcher(fi.DirectoryName, fi.Name))
            {
                fsw.Changed += (s, e) =>
                {
                    lock (lockMe)
                    {
                        if (e.FullPath != fi.FullName) return;
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

                                LogEntryData logEntry = new LogEntryData();
                                logEntry.timeStamp = cols[0];
                                logEntry.source = cols[1];
                                logEntry.status = cols[2];
                                logEntry.entryText = cols[3];
                                CallerContext.Caller.addLogEntry(logEntry); 
                            }
                            latch.Set();
                        }
                    }
            }
        }

    }
}
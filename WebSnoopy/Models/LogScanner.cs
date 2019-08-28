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

namespace Models
{

    public class LogScanner
    {

        public void SendToSignalRClient(IHubCallerConnectionContext<dynamic> Clients)
        {

            LogEntryData logEntry = new LogEntryData();
            logEntry.PCName = "merl";
            logEntry.ServiceName = "merl";
            logEntry.Location = "merl";
            logEntry.ConnStr = "merl";
            logEntry.Location = "merl";
            logEntry.Status = "Running";
            Clients.Caller.addLogEntry(logEntry);
            Clients.Caller.addLogEntry(logEntry);
            Clients.Caller.addLogEntry(logEntry);
            Clients.Caller.addLogEntry(logEntry);

            spawnWatcher(Clients);
        }


        private async Task spawnWatcher(IHubCallerConnectionContext<dynamic> Clients)
        {
            await Task.Run(() => SetUpWatcher(Clients));

        }

        private async Task SetUpWatcher(IHubCallerConnectionContext<dynamic> Clients)
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
                                logEntry.PCName = cols[0];
                                logEntry.ServiceName = cols[1];
                                logEntry.Location = cols[2];
                                logEntry.ConnStr = cols[3];
                                logEntry.Location = cols[4];
                                logEntry.Status = "Running";
                                Clients.Caller.addLogEntry(logEntry); 
                            }
                            latch.Set();
                        }
                    }
            }
        }

    }
}
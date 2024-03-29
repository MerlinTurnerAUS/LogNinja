﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.Abstractions.TestingHelpers;
using MasterLoggerMonitor;

namespace MonitorTests
{
    [TestClass]
    public class LogFileHandlerTests
    {
        [TestMethod]
        public void LogFileHandlerInitialTest()
        {
            File.Delete(@"C:\Temp\MasterLog\MasterLog.log");
            MasterLogWriter mlw = new MasterLogWriter();
            mlw.masterLogLocation = @"C:\Temp\MasterLog\MasterLog.log";

            LogFileHandler lfh = new LogFileHandler(mlw, @"C:\Temp\logs\app.log", @"{0:yyyy-MM-dd HH:mm:ss.fff}, C:\Temp\xml\log.xml, {1}, {2}");
            System.Threading.Thread.Sleep(1000);

            var txt = File.ReadAllText(@"C:\Temp\MasterLog\MasterLog.log");
            string[] lines = txt.Split('\n');
            Console.WriteLine("Number of lines in mock file: {0}", lines.Length);
            Assert.IsTrue(lines.Length > 0);
            string[] fields = lines[0].Split(',');
            //Assert.AreEqual("Item no:aa1 Description:inventory purchase Cost: $230 Paid: Yes Due Date: 12/08/2019 Notes: Paid via credit card", fields[3].Trim());
            foreach (string line in lines)
                Console.WriteLine(line);

        }
    }
}

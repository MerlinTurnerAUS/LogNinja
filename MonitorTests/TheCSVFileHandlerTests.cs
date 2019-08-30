using System;
using System.IO.Abstractions.TestingHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterLoggerMonitor;
using System.IO;

namespace MonitorTests
{
    [TestClass]
    public class TheCSVFileHandlerTests
    {
        [TestMethod]
        public void CSVFileHandlerInitialTest()
        {
            File.Delete(@"C:\Temp\MasterLog\MasterLog.log");
            MasterLogWriter mlw = new MasterLogWriter();
            mlw.masterLogLocation = @"C:\Temp\MasterLog\MasterLog.log";

            CSVFileHandler csvHandler = new CSVFileHandler(mlw, @"C:\Temp\csv\payments.csv", @"{0:yyyy-MM-dd HH:mm:ss.fff}, C:\Temp\csv\payments.csv, {6}, Item no:{1} Description:{2} Cost: {3} Paid: {4} Due Date: {5} Notes: {7}", "yes");
            System.Threading.Thread.Sleep(1000);

            var txt = File.ReadAllText(@"C:\Temp\MasterLog\MasterLog.log");
            string[] lines = txt.Split('\n');
            Console.WriteLine("Number of lines in mock file: {0}", lines.Length);
            Assert.IsTrue(lines.Length > 0);
            string[] fields = lines[0].Split(',');
            Assert.AreEqual("Item no:aa1 Description:inventory purchase Cost: $230 Paid: Yes Due Date: 12/08/2019 Notes: Paid via credit card", fields[3].Trim());
            foreach (string line in lines)
                Console.WriteLine(line);


        }
    }
}

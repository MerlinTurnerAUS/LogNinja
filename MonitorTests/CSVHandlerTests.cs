using System;
using System.IO.Abstractions.TestingHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterLoggerMonitor;

namespace MonitorTests
{
    [TestClass]
    public class CSVHandlerTests
    {
        [TestMethod]
        public void CSVFileHandlerInitialTest()
        {
            // Prepare mock file system for test
            string mockFileName = @"C:\Temp\Test.txt";
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("");

            mockFileSystem.AddFile(mockFileName, mockInputFile);

            // Instantiate test subject with mock file system
            MasterLogWriter mlw = new MasterLogWriter(mockFileSystem);
            mlw.masterLogLocation = mockFileName;

            CSVFileHandler csvHandler = new CSVFileHandler(mlw, @"C:\Temp\csv\payments.csv", @"{0:yyyy-MM-dd HH:mm:ss.fff}, C:\Temp\csv\payments.csv, {6}, Item no:{1} Description:{2} Cost: {3} Paid: {4} Due Date: {5} Notes: {7}", "yes");
            MockFileData mockOutputFile = mockFileSystem.GetFile(mockFileName);
            string[] outputLines = mockOutputFile.TextContents.SplitLines();
            Console.WriteLine("Number of lines in mock file: {0}", outputLines.Length);
            Assert.IsTrue(outputLines.Length > 0);

        }
    }
}

using System;
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
            // Prepare mock file system for test
            string mockFileName = @"C:\Temp\Test.txt";
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("");

            mockFileSystem.AddFile(mockFileName, mockInputFile);

            // Instantiate test subject with mock file system
            MasterLogWriter mlw = new MasterLogWriter(mockFileSystem);
            mlw.masterLogLocation = mockFileName;

            LogFileHandler lfh = new LogFileHandler(mlw, @"C:\Temp\logs\app.log", @"{0:yyyy-MM-dd HH:mm:ss.fff}, C:\Temp\xml\log.xml, {1}, {2}");

            MockFileData mockOutputFile = mockFileSystem.GetFile(mockFileName);
            string[] outputLines = mockOutputFile.TextContents.SplitLines();
            Console.WriteLine("Number of lines in mock file: {0}", outputLines.Length);
            Assert.IsTrue(outputLines.Length > 0);
        }
    }
}

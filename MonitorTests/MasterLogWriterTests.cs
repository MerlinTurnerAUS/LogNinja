using System;
using System.Collections;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterLoggerMonitor;

namespace MonitorTests
{
    [TestClass]
    public class MasterLogWriterTests
    {
        [TestMethod]
        public void MasterLogWriter_WriteToEmptyLogTest()
        {
            // Prepare mock file system for test
            string mockFileName = @"C:\Temp\Test.txt";
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("");

            mockFileSystem.AddFile(mockFileName, mockInputFile);

            DateTime nowStamp = DateTime.Now;

            // Instantiate test subject with mock file system
            MasterLogWriter mlw = new MasterLogWriter(mockFileSystem);

            // The action being tested
            mlw.masterLogLocation = mockFileName;
            mlw.WriteEntry(nowStamp.ToString("yyyy-MM-dd HH:mm:ss.fff"), "UnitTest", "Test", "Test output");

            // Testing results
            MockFileData mockOutputFile = mockFileSystem.GetFile(mockFileName);
            string[] outputLines = mockOutputFile.TextContents.SplitLines();
            Console.WriteLine("Number of lines in mock file: {0}", outputLines.Length);
            Assert.IsTrue(outputLines.Length == 1);
            Console.WriteLine(outputLines[0]);
            Assert.AreEqual(outputLines[0], string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}, UnitTest, Test, Test output", nowStamp));
        }

        [TestMethod]
        public void MasterLogWriter_WriteLogTest()
        {
            // Prepare mock file system for test
            string mockFileName = @"C:\temp\in.txt";
            var mockFileSystem = new MockFileSystem();

            var mockInputFile = new MockFileData("line1\nline2\nline3\n");

            mockFileSystem.AddFile(mockFileName, mockInputFile);

            DateTime nowStamp = DateTime.Now;

            // Instantiate test subject with mock file system
            MasterLogWriter mlw = new MasterLogWriter(mockFileSystem);

            // The action being tested
            mlw.masterLogLocation = mockFileName;
            mlw.WriteEntry(nowStamp.ToString("yyyy-MM-dd HH:mm:ss.fff"), "UnitTest", "Test", "Test output");

            // Testing results
            MockFileData mockOutputFile = mockFileSystem.GetFile(mockFileName);
            string[] outputLines = mockOutputFile.TextContents.SplitLines();
            Console.WriteLine("Number of lines in mock file: {0}", outputLines.Length);
            Assert.AreEqual(outputLines[0], "line1");
            Assert.AreEqual(outputLines[1], "line2");
            Assert.AreEqual(outputLines[2], "line3");
            Assert.IsTrue(outputLines.Length == 4);
            Assert.AreEqual(outputLines[3], string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}, UnitTest, Test, Test output", nowStamp));
        }
    }
}

using System;
using System.Linq;
using System.IO.Abstractions.TestingHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterLoggerMonitor;
using System.Xml.Linq;
using System.Xml;

namespace MonitorTests
{
    [TestClass]
    public class XMLHandlerTests
    {
        [TestMethod]
        public void XMLHandlerInitialiseTest()
        {
            // Prepare mock file system for test
            string mockFileName = @"C:\Temp\Test.txt";
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("");

            mockFileSystem.AddFile(mockFileName, mockInputFile);

            // Instantiate test subject with mock file system
            MasterLogWriter mlw = new MasterLogWriter(mockFileSystem);
            mlw.masterLogLocation = mockFileName;

            XMLHandler xmlH = new XMLHandler(mlw, @"C:\Temp\xml\log.xml", @"{4:yyyy-MM-dd HH:mm:ss.fff}, C:\Temp\xml\log.xml, {3}, {1} | {2}", "action", "timestamp", "5000");
            MockFileData mockOutputFile = mockFileSystem.GetFile(mockFileName);
            string[] outputLines = mockOutputFile.TextContents.SplitLines();
            Console.WriteLine("Number of lines in mock file: {0}", outputLines.Length);
            Assert.IsTrue(outputLines.Length > 0);
        }

        [TestMethod]
        public void XMLHandlerUpdatedTest()
        {
            // Prepare mock file system for test
            string mockFileName = @"C:\Temp\Test.txt";
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("");

            mockFileSystem.AddFile(mockFileName, mockInputFile);

            // Instantiate test subject with mock file system
            MasterLogWriter mlw = new MasterLogWriter(mockFileSystem);
            mlw.masterLogLocation = mockFileName;

            XMLHandler xmlH = new XMLHandler(mlw, @"C:\Temp\xml\log.xml", @"{4:yyyy-MM-dd HH:mm:ss.fff}, C:\Temp\xml\log.xml, {3}, {1} | {2}", "action", "timestamp", "5000");

            string xmlFile = @"C:\Temp\xml\log.xml";

            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            XDocument document = XDocument.Load(xmlFile);
            document.Element("actions").Add(new XElement("action",
                                                new XElement("ID", 10),
                                                new XElement("name", "TestName"),
                                                new XElement("description", "TestDescription"),
                                                new XElement("level", "INFO"),
                                                new XElement("timestamp", timeStamp)));
            document.Save(xmlFile);

            System.Threading.Thread.Sleep(5000);

            MockFileData mockOutputFile = mockFileSystem.GetFile(mockFileName);
            string[] outputLines = mockOutputFile.TextContents.SplitLines();
            Console.WriteLine("Number of lines in mock file: {0}", outputLines.Length);
            Assert.IsTrue(outputLines.Length > 0);
            string lastLine = outputLines[outputLines.Length-1];
            Assert.AreEqual(string.Format(@"{0:yyyy-MM-dd HH:mm:ss.fff}, C:\Temp\xml\log.xml, INFO, TestName | TestDescription", timeStamp),lastLine);
        }
    }
}
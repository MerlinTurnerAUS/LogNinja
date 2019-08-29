using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterLoggerMonitor;
using System.IO.Abstractions.TestingHelpers;

namespace MonitorTests
{
    [TestClass]
    public class DBHandlerTests
    {
        [TestMethod]
        public void DBHandlerInitialTest()
        {
            // Prepare mock file system for test
            string mockFileName = @"C:\Temp\Test.txt";
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("");

            mockFileSystem.AddFile(mockFileName, mockInputFile);

            // Instantiate test subject with mock file system
            MasterLogWriter mlw = new MasterLogWriter(mockFileSystem);
            mlw.masterLogLocation = mockFileName;

            dbTableHandler dbTH = new dbTableHandler(mlw, 
                                                    @"server=localhost\SQLExpress;database=Portal;integrated security=true",
                                                    "SELECT * FROM Documents WHERE DateModified > @DateModified ORDER BY DateModified", 
                                                    "{7:yyyy-MM-dd HH:mm:ss.fff}, DB:Portal, {4}, '{1}' last changed by user '{8}'",
                                                    "DateModified",
                                                    "Error",
                                                    "5000");

            MockFileData mockOutputFile = mockFileSystem.GetFile(mockFileName);
            string[] outputLines = mockOutputFile.TextContents.SplitLines();
            Console.WriteLine("Number of lines in mock file: {0}", outputLines.Length);
            Assert.IsTrue(outputLines.Length > 0);
            Assert.AreEqual(@"2019-07-10 09:11:38.000, DB:Portal, INFO, 'Coded special document' last changed by user 'jenny'", outputLines[0]);
        }

        [TestMethod]
        public void DBHandlerUpdateTest()
        {
            // Prepare mock file system for test
            string mockFileName = @"C:\Temp\Test.txt";
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("");

            mockFileSystem.AddFile(mockFileName, mockInputFile);

            // Instantiate test subject with mock file system
            MasterLogWriter mlw = new MasterLogWriter(mockFileSystem);
            mlw.masterLogLocation = mockFileName;

            dbTableHandler dbTH = new dbTableHandler(mlw, 
                                                    @"server=localhost\SQLExpress;database=Portal;integrated security=true",
                                                    "SELECT * FROM Documents WHERE DateModified > @DateModified ORDER BY DateModified",
                                                    "{7:yyyy-MM-dd HH:mm:ss.fff}, DB:Portal, {4}, '{1}' last changed by user '{8}'",
                                                    "DateModified",
                                                    "Error",
                                                    "5000");


            MockFileData mockOutputFile = mockFileSystem.GetFile(mockFileName);
            string[] outputLines = mockOutputFile.TextContents.SplitLines();
            Console.WriteLine("Number of lines in mock file: {0}", outputLines.Length);
            Assert.IsTrue(outputLines.Length > 0);
            Assert.AreEqual(@"2019-07-10 09:11:38.000, DB:Portal, INFO, 'Coded special document' last changed by user 'jenny'", outputLines[0]);


        }


    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterLoggerMonitor;

namespace MonitorTests
{
    [TestClass]
    public class XMLHandlerTests
    {
        [TestMethod]
        public void TestTransform()
        {
            XMLHandler xmlH = new XMLHandler(@"C:\Temp\xml\log.xml");

        }
    }
}

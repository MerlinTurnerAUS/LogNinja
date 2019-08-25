using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace MasterLoggerMonitor
{
    public class MasterLogWriter
    {
        readonly IFileSystem fileSystem;

        // Create MasterLogWriter with the given fileSystem implementation
        // For mocking file system in Unit Tests
        public MasterLogWriter(IFileSystem fs)
        {
            this.fileSystem = fs;
        }

        public MasterLogWriter() : this(new FileSystem()) //use default implementation which calls System.IO
        { }

        public string masterLogLocation { get; set; }
        public void WriteEntry(string Timestamp, string source, string Level, string Output)
        {

            StreamWriter fsWriter = fileSystem.File.AppendText(masterLogLocation);
            fsWriter.WriteLine("{0}, {1}, {2}, {3}",Timestamp,source,Level,Output);
            Console.WriteLine("{0}, {1}, {2}, {3}", Timestamp, source, Level, Output);
            fsWriter.Close();
        }
    }
}

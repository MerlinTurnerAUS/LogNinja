using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Models
{
    public class LogEntryData
    {
        public string timeStamp { get; set; }
        public string source { get; set; }
        public string status { get; set; }
        public string entryText { get; set; }

    }
}

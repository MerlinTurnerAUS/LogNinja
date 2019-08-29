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
        private string _status;
        private string _timeStamp;

        public string timeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        public string source { get; set; }

        public string status
        {
            get { return _status; }
            set
            {
                _status = value;
                if (value.ToLower().Contains("error"))
                    isError = true;
                else
                    isError = false;
            }
        }

        public string entryText { get; set; }

        public bool isError { get; set; }

    }
}

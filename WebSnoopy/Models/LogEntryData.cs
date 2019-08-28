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
        private string pcname;
        private string connstr;
        public string PCName
        {
            get { return pcname; }
            set
            {
                pcname = value;
                if (value.ToLower().Substring(0, 2) == "vm")
                {
                    this.Location = "Virtual";
                }
                else
                {
                    if (MachineLocations.ContainsKey(value.ToLower()))
                        this.Location = MachineLocations[value.ToLower()];
                    else
                        this.Location = "Not known";
                }
            }
        }

        public string ServiceName { get; set; }
        public string DB { get; set; }
        public string ConnStr
        {
            get { return connstr; }
            set
            {
                connstr = value;
                DB = "unknown";
                if (value != null)
                {
                    foreach (string kvp in Platforms.Keys)
                    {
                        if (value.Contains(kvp))
                        {
                            this.DB = Platforms[kvp];
                        }
                    }
                }
            }
        }

        public string Status { get; set; }

        public string Location { get; set; }

        private Dictionary<string, string> MachineLocations = new Dictionary<string, string>();
        private Dictionary<string, string> Platforms = new Dictionary<string, string>() { { "10.0.10.49", "DEV" }, { "10.0.10.46", "TEST" }, { "10.0.10.42", "PROD" }, { "10.0.30.54", "TEST2019" }};

        public LogEntryData()
        {
            string PCsString = ConfigurationManager.AppSettings["PCs"];
            string[] PCs = PCsString.Split(',');
            
            foreach (string PCkvp in PCs)
                MachineLocations.Add(PCkvp.Substring(0, PCkvp.IndexOf(":")), PCkvp.Substring(PCkvp.IndexOf(":") + 1));

        }
    }
}

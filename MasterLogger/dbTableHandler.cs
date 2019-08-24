using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Timers;

namespace MasterLoggerMonitor
{
    class dbTableHandler
    {
        public string connStr { get; set; }
        public string selectQuery { get; set; }
        public string timeColumn { get; set; }
        public string outputString { get; set; }
        public string errorColumn { get; set; }
        public int LastProcessedID { get; set; }

        public dbTableHandler(string connectionString, string query,string time, string outString, string errColumn)
        {
            connStr = connectionString;
            selectQuery = query;
            timeColumn = time;
            outputString = outString;
            errorColumn = errColumn;
            LastProcessedID = 0;

            // Get all rows currently in table
            InterogateTable();

            // Set up timer to check table every interval
            Timer timer = new Timer(5000);
            timer.Elapsed += OnTimerTick;
            timer.Enabled = true;
        }

        private void InterogateTable()
        {
            DataTable dt = DataGateway.GetTable(connStr, string.Format(selectQuery,LastProcessedID));
            foreach (DataRow row in dt.Rows)
            {
                string timeString;
                DateTime dtLastModified;
                string Output;
                string ErrString = "";
                string[] arguments = new string[dt.Columns.Count];

                dtLastModified = Convert.ToDateTime(row[timeColumn]);
                timeString = dtLastModified.ToString("yyyy-MM-dd HH:mm:ss,fff");

                for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                    arguments[iCol] = row[iCol].ToString();

                if (row[errorColumn].ToString() == "")
                {
                    ErrString = "INFO";
                    Output = string.Format(outputString, arguments);
                }
                else
                {
                    ErrString = "ERROR";
                    Output = string.Format("{0} in {1}", row[errorColumn], outputString);
                    Output = string.Format(Output, arguments);
                }
                MasterLogWriter.WriteEntry(timeString, connStr, ErrString, Output);

                Console.WriteLine(row.ToString());

                // Get last ID
                LastProcessedID = Convert.ToInt32(row[0]);

            }
        }

        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            InterogateTable();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Timers;

namespace MasterLoggerMonitor
{
    public class dbTableHandler
    {
        public string connStr { get; set; }
        public string selectQuery { get; set; }
        public string timeColumn { get; set; }
        public string outputString { get; set; }
        public string errorColumn { get; set; }
        public DateTime lastTimeProcessed { get; set; }
        private MasterLogWriter masterLogger;

        public dbTableHandler(MasterLogWriter mlw, string connectionString, string query,string time, string outString, string errColumn, string pollTime)
        {
            masterLogger = mlw;
            connStr = connectionString;
            selectQuery = query;
            timeColumn = time;
            outputString = outString;
            errorColumn = errColumn;
            lastTimeProcessed = DateTime.MinValue;

            // Get all rows currently in table
            InterogateTable();

            // Set up timer to check table every interval
            Timer timer = new Timer(Convert.ToInt32(pollTime));
            timer.Elapsed += OnTimerTick;
            timer.Enabled = true;
        }

        private void InterogateTable()
        {
            DataTable dt = DataGateway.GetRecordsSinceLastPoll(connStr, selectQuery, timeColumn, lastTimeProcessed);
            foreach (DataRow row in dt.Rows)
            {
                string timeString;
                DateTime dtLastModified;
                string Output;
                string ErrString = "";
                string[] arguments = new string[dt.Columns.Count];

                dtLastModified = Convert.ToDateTime(row[timeColumn]);
                timeString = dtLastModified.ToString("yyyy-MM-dd HH:mm:ss.fff");

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
                masterLogger.WriteEntry(timeString, connStr, ErrString, Output);

                // Get last Date Modified
                lastTimeProcessed = dtLastModified;
            }
        }

        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            InterogateTable();
        }
    }
}

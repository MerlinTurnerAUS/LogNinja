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

        public dbTableHandler(MasterLogWriter mlw, string connectionString, string query,string formatString,string timeStampColumn, string pollTime)
        {
            masterLogger = mlw;
            connStr = connectionString;
            selectQuery = query;
            timeColumn = timeStampColumn;
            outputString = formatString;
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
                string[] arguments = new string[dt.Columns.Count];

                dtLastModified = Convert.ToDateTime(row[timeColumn]);
                timeString = dtLastModified.ToString("yyyy-MM-dd HH:mm:ss.fff");

                for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                    arguments[iCol] = row[iCol].ToString();

                masterLogger.WriteEntry(string.Format(outputString, arguments));

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

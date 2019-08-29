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
        private string connStr;
        private string selectQuery;
        private string timeColumn;
        private string errColumn;
        private string outputString;
        private DateTime lastTimeProcessed;
        private MasterLogWriter masterLogger;

        public dbTableHandler(MasterLogWriter mlw, string connectionString, string query, string formatString, string timeStampColumn,string errorColumn, string pollTime)
        {
            masterLogger = mlw;
            connStr = connectionString;
            selectQuery = query;
            timeColumn = timeStampColumn;
            errColumn = errorColumn;
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
                DateTime dtLastModified;
                object[] arguments = new object[dt.Columns.Count];

                dtLastModified = Convert.ToDateTime(row[timeColumn]);

                if (row[errColumn].ToString() == "")
                    row[errColumn] = "INFO";
                else
                    row[errColumn] = "ERROR";

                for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                    arguments[iCol] = row[iCol];

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

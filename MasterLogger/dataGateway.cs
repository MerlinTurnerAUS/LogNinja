using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace MasterLoggerMonitor
{
    class DataGateway
    {
        public static DataTable GetTable(string ConnStr, string QueryString)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(QueryString, conn);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            conn.Close();

            return dt;
        }

        public static DataTable GetRecordsSinceLastPoll(string ConnStr, string QueryString, string timeColumn, DateTime LastModifiedDate)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(QueryString, conn);

            //Add Last Modified Date
            string paramName = string.Format("@{0}", timeColumn);

            if (LastModifiedDate == DateTime.MinValue)
                cmd.Parameters.AddWithValue(paramName, SqlDateTime.MinValue);
            else
                cmd.Parameters.AddWithValue(paramName, LastModifiedDate);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
            
            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            conn.Close();

            return dt;
        }


    }
}

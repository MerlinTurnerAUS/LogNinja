using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
    }
}

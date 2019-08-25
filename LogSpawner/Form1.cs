﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace LogSpawner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAppendLog_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\Temp\logs\app.log", true);
            sw.WriteLine("{0}, {1}, {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), chkLogError.Checked ? "[ERROR]" : "[DEBUG]", txtLogText.Text);
            sw.Close();
        }

        private void BtnDB_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"server=localhost\SQLExpress;database=Portal;integrated security=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT Documents (Name, Error, DateModified, ModifiedBy) VALUES(@Name, @Error, @DateModified, @ModifiedBy)", conn);
            cmd.Parameters.AddWithValue("@Name", txtDBName.Text);
            if(txtDBError.Text=="")
                cmd.Parameters.AddWithValue("@Error",DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@Error", txtDBError.Text);
            cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", txtUser.Text);
            cmd.ExecuteNonQuery();
            
            conn.Close();
        }
    }
}

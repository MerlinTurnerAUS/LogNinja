using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            sw.WriteLine("{0},{1}, {2}, {3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff"), chkLogError.Checked ? "[ERROR]" : "[DEBUG]", txtLogText.Text);
            sw.Close();
        }
    }
}

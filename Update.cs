using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nina_Booster
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Update Application!", "New Update Available!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathapp = Application.StartupPath;
            Process.Start(@"" + pathapp + "\\NinaUpdate.exe");
            Application.Exit();
        }
    }
}

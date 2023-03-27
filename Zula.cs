using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nina_Booster
{
    public partial class Zula : Form
    {
        public Zula()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string linkzula = textBox1.Text;
            string linkdoroste = linkzula + "/Game/config.ini";

        if (File.Exists(linkdoroste))
            { 
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("mypc@dl.sorenafile.ir", "Police2019@");
            client.DownloadFile(
                "ftp://dl@dl.sorenafile.ir/GamesFile/Zula/config.ini", @"" + linkzula + "/Game/config.ini");
                label8.Text = "Status : Changes applied successfully!";
            }
            else
            {
                label8.Text = "Status : The selected folder is not correct!";
            }
        }

        private void Zula_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 1000, WinAPI.BLEND);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nina_Booster
{
    public partial class Woltk : Form
    {
        public Woltk()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string linkzula = textBox1.Text;
            string linkdoroste = linkzula + "/_classic_/WTF/Config.wtf";

            if (File.Exists(linkdoroste))
            {
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential("mypc@dl.sorenafile.ir", "Police2019@");
                client.DownloadFile(
                    "ftp://dl@dl.sorenafile.ir/GamesFile/Woltk/Config.wtf", @"" + linkzula + "/_classic_/WTF/Config.wtf");
                label8.Text = "Status : Changes applied successfully!";
            }
            else
            {
                label8.Text = "Status : The selected folder is not correct!";
            }
        }

        private void Woltk_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 1000, WinAPI.BLEND);
        }
    }
}

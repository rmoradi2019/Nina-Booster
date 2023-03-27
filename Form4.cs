using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nina_Booster
{
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "My Ping : " + new Ping().Send("171.22.26.106").RoundtripTime.ToString() + "ms";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Stop Windows Update
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c net stop wuauserv";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            // Stop Windows Update 2
            System.Diagnostics.Process process1 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
            startInfo1.FileName = "cmd.exe";
            startInfo1.Arguments = "/c net stop bits";
            process1.StartInfo = startInfo1;
            process1.Start();
            process1.WaitForExit();
            // Stop Windows Update 3
            System.Diagnostics.Process process2 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
            startInfo2.FileName = "cmd.exe";
            startInfo2.Arguments = "/c net stop dcsvc";
            process2.StartInfo = startInfo2;
            process2.Start();
            process2.WaitForExit();
            // Stop Eset
            System.Diagnostics.Process process3 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo3 = new System.Diagnostics.ProcessStartInfo();
            startInfo3.FileName = "cmd.exe";
            startInfo3.Arguments = "/c net stop ekrn";
            process3.StartInfo = startInfo3;
            process3.Start();
            process3.WaitForExit();
            // Stop Chrome Update
            System.Diagnostics.Process process4 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo4 = new System.Diagnostics.ProcessStartInfo();
            startInfo4.FileName = "cmd.exe";
            startInfo4.Arguments = "/c net stop gupdate";
            process4.StartInfo = startInfo4;
            process4.Start();
            process4.WaitForExit();
            // Stop Chrome Update1
            System.Diagnostics.Process process5 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo5 = new System.Diagnostics.ProcessStartInfo();
            startInfo5.FileName = "cmd.exe";
            startInfo5.Arguments = "/c net stop gupdatem";
            process5.StartInfo = startInfo5;
            process5.Start();
            process5.WaitForExit();
            // Stop Windscribe Service
            System.Diagnostics.Process process6 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo6 = new System.Diagnostics.ProcessStartInfo();
            startInfo6.FileName = "cmd.exe";
            startInfo6.Arguments = "/c net stop WindscribeService";
            process6.StartInfo = startInfo6;
            process6.Start();
            process6.WaitForExit();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 1000, WinAPI.BLEND);
        }
    }
}

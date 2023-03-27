using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Collections;
using System.Diagnostics;
using System.Security;

namespace Nina_Booster
{
    public partial class Form5 : Form
    {
        private const string ADMIN_DOMAIN = "";
        private const string COMMAND_NAME = "Defrag.exe";
        private const string COMMAND_ARGUMENTS = "/C /D";
        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            

        }

        private SecureString StringToSecureString(string PlainString)
        {
            SecureString ReturnValue = new SecureString();
            foreach (char C in PlainString)
                ReturnValue.AppendChar(C);

            return ReturnValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo l_ObjPSI = new System.Diagnostics.ProcessStartInfo();
            l_ObjPSI.Arguments = COMMAND_ARGUMENTS;
            l_ObjPSI.CreateNoWindow = false;
            l_ObjPSI.Domain = ADMIN_DOMAIN;
            l_ObjPSI.ErrorDialog = true;
            l_ObjPSI.FileName = System.Environment.SystemDirectory + "\\" + COMMAND_NAME;
            l_ObjPSI.LoadUserProfile = true;
            l_ObjPSI.UseShellExecute = false;
            l_ObjPSI.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            l_ObjPSI.WorkingDirectory = System.Environment.SystemDirectory;

            System.Diagnostics.Process l_objDefragProcess
                   = new System.Diagnostics.Process();
            l_objDefragProcess.StartInfo = l_ObjPSI;
            l_objDefragProcess.Start();
            label1.Text = "Please Wait ... Optimize Started!";
            while (!l_objDefragProcess.HasExited)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(250);
            }

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 1000, WinAPI.BLEND);
        }
    }
    
}

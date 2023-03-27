using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;


namespace Nina_Booster
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DropShadow", true);

            key.SetValue("DefaultApplied", 1);

            label5.Text = "Enabled";

            key.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\DropShadow", true);
           
            key.SetValue("DefaultApplied", 0);

            label1.Text = "Disabled";

            key.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\TaskbarAnimations", true);

            key.SetValue("DefaultApplied", 0);

            label2.Text = "Disabled";

            key.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\TaskbarAnimations", true);

            key.SetValue("DefaultApplied", 1);

            label6.Text = "Enabled";

            key.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\AnimateMinMax", true);

            key.SetValue("DefaultApplied", 0);

            label3.Text = "Disabled";

            key.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\AnimateMinMax", true);

            key.SetValue("DefaultApplied", 1);

            label7.Text = "Enabled";

            key.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\MenuAnimation", true);

            key.SetValue("DefaultApplied", 0);

            label8.Text = "Disabled";

            key.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects\MenuAnimation", true);

            key.SetValue("DefaultApplied", 1);

            label9.Text = "Enabled";

            key.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown", "/r");
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 1000, WinAPI.BLEND);
        }
    }
}

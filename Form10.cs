using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nina_Booster
{
    public partial class Form10 : Form
    {

        private const string ADMIN_DOMAIN = "";
        private const string COMMAND_NAME = "cmd.exe";
        private const string COMMAND_ARGUMENTS = "reg add @'HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings' /v AutoConfigURL /t REG_SZ /d 'https://msasanmh.github.io/PAC/Canada.pac' /f";

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Form10()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 1000, WinAPI.BLEND);
            picdis.Visible = true;
            comboBox1.SelectedItem = "Canada";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Connected")
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"\" /f";
                startInfo.CreateNoWindow = true;
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                label2.Text = "Disconnected";
                picdis.Visible = true;
                picted.Visible = false;
                label3.Text = "Server : Not Selected";
                this.Close();
            }
            else
            {
                this.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Canada")
            {
                if (label2.Text == "Connected")
                {
                    MessageBox.Show("Please disconnect the vpn!", "VPN Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"https://msasanmh.github.io/PAC/Canada.pac\" /f";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    label2.Text = "Connected";
                    picdis.Visible = false;
                    picted.Visible = true;
                    label3.Text = "Server : Canada";
                }
                
            }
            else if (comboBox1.SelectedItem.ToString() == "France")
            {
                if (label2.Text == "Connected")
                {
                    MessageBox.Show("Please disconnect the vpn!", "VPN Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"https://msasanmh.github.io/PAC/France.pac\" /f";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    label2.Text = "Connected";
                    picdis.Visible = false;
                    picted.Visible = true;
                    label3.Text = "Server : France";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Germany")
            {
                if (label2.Text == "Connected")
                {
                    MessageBox.Show("Please disconnect the vpn!", "VPN Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"https://msasanmh.github.io/PAC/Germany.pac\" /f";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    label2.Text = "Connected";
                    picdis.Visible = false;
                    picted.Visible = true;
                    label3.Text = "Server : Germany";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "India")
            {
                if (label2.Text == "Connected")
                {
                    MessageBox.Show("Please disconnect the vpn!", "VPN Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"https://msasanmh.github.io/PAC/India.pac\" /f";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    label2.Text = "Connected";
                    picdis.Visible = false;
                    picted.Visible = true;
                    label3.Text = "Server : India";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Netherland")
            {
                if (label2.Text == "Connected")
                {
                    MessageBox.Show("Please disconnect the vpn!", "VPN Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"https://msasanmh.github.io/PAC/Netherland.pac\" /f";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    label2.Text = "Connected";
                    picdis.Visible = false;
                    picted.Visible = true;
                    label3.Text = "Server : Netherland";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Singapore")
            {
                if (label2.Text == "Connected")
                {
                    MessageBox.Show("Please disconnect the vpn!", "VPN Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"https://msasanmh.github.io/PAC/Singapore.pac\" /f";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    label2.Text = "Connected";
                    picdis.Visible = false;
                    picted.Visible = true;
                    label3.Text = "Server : Singapore";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "UK")
            {
                if (label2.Text == "Connected")
                {
                    MessageBox.Show("Please disconnect the vpn!", "VPN Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"https://msasanmh.github.io/PAC/UK.pac\" /f";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    label2.Text = "Connected";
                    picdis.Visible = false;
                    picted.Visible = true;
                    label3.Text = "Server : United Kingdom";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "US East")
            {
                if (label2.Text == "Connected")
                {
                    MessageBox.Show("Please disconnect the vpn!", "VPN Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"https://msasanmh.github.io/PAC/US-East.pac\" /f";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    label2.Text = "Connected";
                    picdis.Visible = false;
                    picted.Visible = true;
                    label3.Text = "Server : United State East";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "US West")
            {
                if (label2.Text == "Connected")
                {
                    MessageBox.Show("Please disconnect the vpn!", "VPN Connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"https://msasanmh.github.io/PAC/US-West.pac\" /f";
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    label2.Text = "Connected";
                    picdis.Visible = false;
                    picted.Visible = true;
                    label3.Text = "Server : United State West";
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please select a country!", "Select Country", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Please select a country!", "Select Country", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" /v AutoConfigURL /t REG_SZ /d \"\" /f";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            label2.Text = "Disconnected";
            picdis.Visible = true;
            picted.Visible = false;
            label3.Text = "Server : Not Selected";
        }
    }
}

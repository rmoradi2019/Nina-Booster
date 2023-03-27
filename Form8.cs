using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nina_Booster
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C start https://dl.sorenafile.ir/download/download.php?file=Files/Windows/vpngate-client.zip",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            Process.Start(psi);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 1000, WinAPI.BLEND);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("219.100.37.224  | Japan        | Ping : " + new Ping().Send("219.100.37.224").RoundtripTime.ToString() + "ms");
            listBox1.Items.Add("163.182.174.159 | USA          | Ping : " + new Ping().Send("163.182.174.159").RoundtripTime.ToString() + "ms");
            listBox1.Items.Add("219.100.37.113  | Japan        | Ping : " + new Ping().Send("219.100.37.113").RoundtripTime.ToString() + "ms");
            listBox1.Items.Add("219.100.37.214  | Japan        | Ping : " + new Ping().Send("219.100.37.214").RoundtripTime.ToString() + "ms");
            listBox1.Items.Add("219.100.37.155  | Japan        | Ping : " + new Ping().Send("219.100.37.155").RoundtripTime.ToString() + "ms");
            listBox1.Items.Add("150.95.29.30    | Singapore    | Ping : " + new Ping().Send("150.95.29.30").RoundtripTime.ToString() + "ms");
            listBox1.Items.Add("91.193.75.5     | Germany      | Ping : " + new Ping().Send("91.193.75.5").RoundtripTime.ToString() + "ms");
            listBox1.Items.Add("45.125.0.246    | Hong Kong    | Ping : " + new Ping().Send("45.125.0.246").RoundtripTime.ToString() + "ms");
            listBox1.Items.Add("103.123.10.231  | Bangladesh   | Ping : " + new Ping().Send("103.123.10.231").RoundtripTime.ToString() + "ms");
            listBox1.Items.Add("5.181.235.14    | Romania      | Ping : " + new Ping().Send("5.181.235.14").RoundtripTime.ToString() + "ms");
            listBox1.Items.Add("78.142.193.246  | Germany      | Ping : " + new Ping().Send("78.142.193.246").RoundtripTime.ToString() + "ms");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            label8.Visible = true;
            timer1.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label8.Visible = false;
            timer1.Enabled = false;
        }
    }
}

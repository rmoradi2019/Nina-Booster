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
using System.Runtime.InteropServices;

namespace Nina_Booster
{
    public partial class Form3 : Form
    {
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
        public Form3()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            WinAPI.AnimateWindow(this.Handle, 1000, WinAPI.BLEND);



            NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();


            var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                && x.OperationalStatus == OperationalStatus.Up
                                && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true ));
            



            IPInterfaceProperties ipProperties = activeAdapter.GetIPProperties();
            IPAddressCollection dnsAddresses = ipProperties.DnsAddresses;

            try
            {
                label2.Text = "Your DNS : " + dnsAddresses[0] + " | " + dnsAddresses[1];
            }
            catch (Exception)
            {

                label2.Text = "Your DNS : No active DNS found!";
            }
                

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = "Google Ping : " + new Ping().Send("8.8.8.8").RoundtripTime.ToString() + "ms";
            label6.Text = "Quad9 Ping : " + new Ping().Send("9.9.9.9").RoundtripTime.ToString() + "ms";
            label7.Text = "Open Ping : " + new Ping().Send("208.67.222.222").RoundtripTime.ToString() + "ms";
            label8.Text = "CloudF Ping : " + new Ping().Send("1.1.1.1").RoundtripTime.ToString() + "ms";
            label9.Text = "Comodo Ping : " + new Ping().Send("8.26.56.26").RoundtripTime.ToString() + "ms";
            label10.Text = "Shecan Ping : " + new Ping().Send("178.22.122.100").RoundtripTime.ToString() + "ms";
            label14.Text = "Alternate Ping : " + new Ping().Send("76.76.19.19").RoundtripTime.ToString() + "ms";
            label15.Text = "AdGuard Ping : " + new Ping().Send("176.103.130.130").RoundtripTime.ToString() + "ms";
            label16.Text = "Verisign Ping : " + new Ping().Send("64.6.64.6").RoundtripTime.ToString() + "ms";
            label18.Text = "Yandex Ping : " + new Ping().Send("77.88.8.8").RoundtripTime.ToString() + "ms";
            
        }

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "Google DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                
                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "8.8.8.8", "4.2.2.4" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }
                    
                }

                








            }
            else if(listBox1.SelectedItem.ToString() == "Quad9")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;


                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "9.9.9.9", "149.112.112.112" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }
            }
            else if (listBox1.SelectedItem.ToString() == "Open DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "208.67.222.222", "208.67.220.220" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }
            else if (listBox1.SelectedItem.ToString() == "Cloudflare")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "1.1.1.1", "1.0.0.1" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }
            else if (listBox1.SelectedItem.ToString() == "Comodo DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "8.26.56.26", "8.20.247.20" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }
            else if (listBox1.SelectedItem.ToString() == "Shecan DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "178.22.122.100", "185.51.200.2" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }
            
            else if (listBox1.SelectedItem.ToString() == "Alternate DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "76.76.19.19", "76.223.122.150" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }
            else if (listBox1.SelectedItem.ToString() == "AdGuard DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "176.103.130.130", "176.103.130.131" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }
            else if (listBox1.SelectedItem.ToString() == "Verisign")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "64.6.64.6", "64.6.65.6" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }
            
            else if (listBox1.SelectedItem.ToString() == "Yandex DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "77.88.8.8", "77.88.8.1" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }

            else if (listBox1.SelectedItem.ToString() == "Arab DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "86.98.81.52", "217.165.186.107" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }

            else if (listBox1.SelectedItem.ToString() == "Germany DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "85.215.186.215", "185.158.251.19" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }

            else if (listBox1.SelectedItem.ToString() == "France DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "195.101.47.6", "81.255.110.158" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }

            else if (listBox1.SelectedItem.ToString() == "USA DNS")
            {
                timer2.Enabled = true;
                label11.Visible = true;
                label12.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

                var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                    && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                    && x.OperationalStatus == OperationalStatus.Up
                                    && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();

                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                string[] Dns = { "23.216.53.91", "70.35.200.241" };
                                objdns["DNSServerSearchOrder"] = Dns;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }

                }

            }


        }

        private ManagementScope PrepareScope(string machineName, ConnectionOptions options, string v)
        {
            throw new NotImplementedException();
        }

        private ConnectionOptions PrepareOptions()
        {
            throw new NotImplementedException();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            


            progressBar1.Value += 1;
            label11.Text = progressBar1.Value + "%";
            if (progressBar1.Value == 100)
            {
                timer2.Enabled = false;
                label12.Text = "DNS is set";
                progressBar1.Visible = false;
                label11.Visible = false;
                label12.ForeColor = Color.Green;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {


            string dnsnew1 = textBox1.Text;
            string dnsnew2 = textBox2.Text;

            timer2.Enabled = true;
            label11.Visible = true;
            label12.Visible = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;

            NetworkInterface[] networks = NetworkInterface.GetAllNetworkInterfaces();

            var activeAdapter = networks.First(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                && x.OperationalStatus == OperationalStatus.Up
                                && (x.Name.StartsWith("Ethernet") || x.Name.StartsWith("Wi-Fi") || x.Name.StartsWith("Local") == true));

            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    if (objMO["Description"].ToString().Equals(activeAdapter.Description))
                    {
                        ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        if (objdns != null)
                        {
                            string[] Dns = { dnsnew1, dnsnew2 };
                            objdns["DNSServerSearchOrder"] = Dns;
                            objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                    }
                }

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}

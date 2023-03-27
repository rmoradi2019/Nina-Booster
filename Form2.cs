using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Globalization;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Nina_Booster
{
    public partial class Form2 : Form
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
        private bool CheckConnectionW()
        {
            Ping png = new Ping();
            PingReply pr = png.Send("google.com");
            bool Connected = false;
            if (pr.Status == IPStatus.Success)
                Connected = true;

            return Connected;
        }
        private bool CheckConnectionIR()
        {
            Ping pngr = new Ping();
            PingReply prr = pngr.Send("google.com");
            bool Connected = false;
            if (prr.Status == IPStatus.Success)
                Connected = true;

            return Connected;
        }
        public Form2()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ping pngrr = new Ping();
            PingReply prrr = pngrr.Send("google.com");
            label2.Text = "Iran Ping : " + new Ping().Send("171.22.26.106").RoundtripTime.ToString() + "ms";
            label1.Text = "Google Ping : " + new Ping().Send("www.google.com").RoundtripTime.ToString() + "ms";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            new Form3().ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            new Form4().ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            new Form5().ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            new Form6().ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon!", "Now is not available!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
            new Form8().ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C start https://sorenafile.ir/",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            Process.Start(psi);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

            //get setting
            var MyIni = new IniFile("config.ini");
            var GM = MyIni.Read("Graphic_Mode", "setting");
            var PC = MyIni.Read("Ping_Check", "setting");

            if (GM == "0")
            {
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                pictureBox1.Visible = false;
                pictureBox12.Visible = false;
            }
            else if (GM == "1")
            {
                this.FormBorderStyle = FormBorderStyle.None;
                WinAPI.AnimateWindow(this.Handle, 1000, WinAPI.BLEND);
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            }

            if (PC == "0")
            {
                label1.Visible = false;
                label2.Visible = false;
            }
            else if (PC == "1")
            {
                label1.Visible = true;
                label2.Visible = true;
            }

            string getpath1 = Path.GetTempPath();
            string path1 = @"" + getpath1 + "4e488add3e38a468518c381a11d7a544.txt";
            string textFile1 = path1;
            string text1 = File.ReadAllText(textFile1);
            // text1 out put : 20221214
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();


            string mnn1;
            if (int.Parse(mn) < 10)
            {
                mnn1 = "0" + mn;




            }
            else
            {
                mnn1 = mn;




            }

            string all = "" + yy + "" + mnn1 + "" + dy + "";

            int timealan = int.Parse(all);
            int timeasli = int.Parse(text1);

            
            string addsal = text1.Substring(0, 4);
            string addmah = text1.Substring(4, 2);
            string addroz = text1.Substring(6, 2);

            DateTime dateTime = DateTime.MinValue;
            String sDate1 = DateTime.Now.ToString();
            DateTime datevalue1 = (Convert.ToDateTime(sDate.ToString()));

            String addroz1 = datevalue1.Day.ToString();
            String addmah11 = datevalue1.Month.ToString();
            String addsal1 = datevalue1.Year.ToString();

            string mnn11;
            if (int.Parse(addmah11) < 10)
            {
                mnn11 = "0" + addmah11;




            }
            else
            {
                mnn11 = addmah11;




            }




            System.DateTime firstDate = new System.DateTime(int.Parse(addsal), int.Parse(addmah), int.Parse(addroz)); //az file begire

            
            System.DateTime secondDate = new System.DateTime(int.Parse(addsal1), int.Parse(mnn11), int.Parse(addroz1));
            System.TimeSpan diff = secondDate.Subtract(firstDate);
            System.TimeSpan diff1 = secondDate - firstDate;



            String diff2 = (secondDate - firstDate).TotalDays.ToString(); //output 1 rooz gozashte



            int roozebaghimoonde = 31 - int.Parse(diff2); //output : 29



            string getpath5 = Path.GetTempPath();


            label11.Text = "License Time : " + roozebaghimoonde + "Day";



            //Check For Update 
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("mypc@dl.sorenafile.ir", "Police2019@");
            client.DownloadFile(
                "ftp://dl@dl.sorenafile.ir/NinaBooster/version.txt", @"" + getpath5 + "version.txt");
            string pathversion = @"" + getpath5 + "version.txt";
            string versionnew = File.ReadAllText(pathversion);

            string removed1 = versionnew.Remove(1, 1);
            string removed2 = removed1.Remove(2, 1);

            int versionnew1 = int.Parse(removed2);

            string versionold = label8.Text;

            string removed11 = versionold.Remove(0, 1); //1.0.9
            string removed22 = removed11.Remove(1, 1); //10.9
            string removed33 = removed22.Remove(2, 1); //109

            int versionupdate = int.Parse(removed33);

            int updatedareyana = versionnew1 - versionupdate;

            if (updatedareyana == 0)
            {
                // Hichi Nashe
            }
            else
            {
                
                new Update().ShowDialog();
            }

            

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            
            new Form9().ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            
            new ChangeLog().ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            new Form10().ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            new Setting().ShowDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi12 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C start https://music.sorenafile.ir/",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            Process.Start(psi12);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi13 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C start https://play.sorenafile.ir/",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            Process.Start(psi13);
        }
    }
}

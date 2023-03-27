using System.Globalization;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using static System.Windows.Forms.AxHost;

namespace Nina_Booster
{
    public partial class Form1 : Form
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
        private bool CheckConnection()
        {
            
            Ping png = new Ping();
            PingReply pr = png.Send("171.22.26.106");
            bool Connected = false;
            if (pr.Status == IPStatus.Success)
                Connected = true; 

            return Connected;
        }
        

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
          
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            bool isAdmin;
            try
            {
                //get the currently logged in user
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            

            if (isAdmin == false)
            {
              DialogResult result = MessageBox.Show("To run the program correctly, run the software as Administrator", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

            

            string getpath = Path.GetTempPath();
            string path = @"" + getpath + "4e488add3e38a468518c381a11d7a544.txt"; //20221214

            if (File.Exists(path))
            {
                String sDate = DateTime.Now.ToString();
                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

                String dy = datevalue.Day.ToString();
                String mn = datevalue.Month.ToString();
                String yy = datevalue.Year.ToString();

                string all = "" + yy + "" + mn + "" + dy + "";
                string text1 = File.ReadAllText(path);
                string addsal = text1.Substring(0, 4);
                string addmah = text1.Substring(4, 2);
                string addroz = text1.Substring(6, 2);

                DateTime dateTime = DateTime.MinValue;





                String sDate1 = DateTime.Now.ToString();
                DateTime datevalue1 = (Convert.ToDateTime(sDate.ToString()));

                String dy1 = datevalue.Day.ToString();
                String mn1 = datevalue.Month.ToString();
                String yy1 = datevalue.Year.ToString();
                string mnn1;
                if (int.Parse(mn1) < 10)
                {
                     mnn1 = "0" + mn1;
                    


                    
                }
                else
                {
                     mnn1 = mn1;
                    


                    
                }




                System.DateTime firstDate = new System.DateTime(int.Parse(addsal), int.Parse(addmah), int.Parse(addroz)); //az file begire
                System.DateTime secondDate = new System.DateTime(int.Parse(yy1), int.Parse(mnn1), int.Parse(dy1));
                System.TimeSpan diff = secondDate.Subtract(firstDate);
                System.TimeSpan diff1 = secondDate - firstDate;



                String diff2 = (secondDate - firstDate).TotalDays.ToString(); //output 1 rooz gozashte

                //label1.Text = diff2.ToString(); 


                if (File.Exists(path))
                {
                    //string text1 = File.ReadAllText(path);
                    //int timealan = int.Parse(all); // 20221215
                    //int timeasli = int.Parse(text1); // int 20221214

                    //int roozhayegozashte = timealan - timeasli; // int 1   

                    int roozebaghimoonde = 31 - int.Parse(diff2); // 31 - 1 = 30
                    string text = File.ReadAllText(path);
                    int textt = int.Parse(text); //20221214
                    if (roozebaghimoonde > 0)
                    {
                        timer1.Enabled = true;
                    }
                    else if (roozebaghimoonde == 0)
                    {
                        File.Delete(path);
                        this.Hide();
                        new Login().ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                        new Login().ShowDialog();
                    }
                }
                else
                {
                    this.Hide();
                    new Login().ShowDialog();
                }

            }
            else
            {
                this.Hide();
                new Login().ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CheckConnection())
                {
                    this.Hide();
                    timer1.Enabled = false;
                    new Form2().Show();
                }
                else
                {
                    label1.Text = "Connection Error!";
                }
            }
            catch (Exception)
            {
                DialogResult result1 = MessageBox.Show("Internet not connected", "No Internet", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result1 == DialogResult.Retry)
                {
                    Application.Restart();
                }
                else if (result1 == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
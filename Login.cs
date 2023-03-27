using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Net;

namespace Nina_Booster
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C start https://sorenafile.ir/product/nina-booster",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            Process.Start(psi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get License Of User
            string license = textBox1.Text;

            // Check License Is Available 
            var request = (FtpWebRequest)WebRequest.Create("ftp://dl@dl.sorenafile.ir/Nina/" + license + ".txt");
            request.Credentials = new NetworkCredential("mypc@dl.sorenafile.ir", "Police2019@");
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //delete license of server 
                var request1 = (FtpWebRequest)WebRequest.Create("ftp://dl@dl.sorenafile.ir/Nina/" + license + ".txt");
                request1.Credentials = new NetworkCredential("mypc@dl.sorenafile.ir", "Police2019@");
                request1.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response1 = (FtpWebResponse)request1.GetResponse();
                //create license file in temp
                string getpath = Path.GetTempPath();
                //string path = @"" + getpath + "e3ffa3010532dfb269b9a6e87d4f03c7.txt";
                string pathyy = @"" + getpath + "4e488add3e38a468518c381a11d7a544.txt";
                if (File.Exists(pathyy))
                {
                    
                    //File.Delete(path);
                    File.Delete(pathyy);
                    // Create License Time File
                    //using (FileStream fs = File.Create(pathyy))
                    //{
                        // Add some text to file    
                     //   Byte[] title = new UTF8Encoding(true).GetBytes("31");
                     //   fs.Write(title, 0, title.Length);
                        
                   // }
                    // Create Date File
                    using (FileStream fs = File.Create(pathyy))
                    {
                        String sDate = DateTime.Now.ToString();
                        DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

                        String dy = datevalue.Day.ToString();
                        String mn = datevalue.Month.ToString();
                        String yy = datevalue.Year.ToString();

                        string mnn;
                        string all;
                        string dyy;
                        if (int.Parse(mn) < 10 && int.Parse(dy) < 10)
                        {
                            mnn = "0" + mn;
                            dyy = "0" + dy;
                            all = "" + yy + "" + mnn + "" + dyy + "";


                            Byte[] title = new UTF8Encoding(true).GetBytes(all);
                            fs.Write(title, 0, title.Length);
                            Application.Restart();
                        }
                        else if (int.Parse(mn) < 10)
                        {
                            mnn = "0" + mn;
                            all = "" + yy + "" + mnn + "" + dy + "";


                            Byte[] title = new UTF8Encoding(true).GetBytes(all);
                            fs.Write(title, 0, title.Length);
                            Application.Restart();
                        }
                        else if (int.Parse(dy) < 10)
                        {
                            dyy = "0" + dy;
                            all = "" + yy + "" + mn + "" + dyy + "";


                            Byte[] title = new UTF8Encoding(true).GetBytes(all);
                            fs.Write(title, 0, title.Length);
                            Application.Restart();
                        }
                        else
                        {
                            mnn = mn;
                            dyy = dy;
                            all = "" + yy + "" + mnn + "" + dyy + "";


                            Byte[] title = new UTF8Encoding(true).GetBytes(all);
                            fs.Write(title, 0, title.Length);
                            Application.Restart();
                        }
                        


                        

                    }


                }
                else
                {
                    // Create License Time File
                    //using (FileStream fs = File.Create(path))
                   // {
                            
                      //  Byte[] title = new UTF8Encoding(true).GetBytes("31");
                      //  fs.Write(title, 0, title.Length);
                        
                   // }
                    // Create Date File
                    using (FileStream fs = File.Create(pathyy))
                    {
                        String sDate = DateTime.Now.ToString();
                        DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

                        String dy = datevalue.Day.ToString();
                        String mn = datevalue.Month.ToString();
                        String yy = datevalue.Year.ToString();

                        string mnn;
                        string all;
                        string dyy;
                        if (int.Parse(mn) < 10 && int.Parse(dy) < 10)
                        {
                            mnn = "0" + mn;
                            dyy = "0" + dy;
                            all = "" + yy + "" + mnn + "" + dyy + "";


                            Byte[] title = new UTF8Encoding(true).GetBytes(all);
                            fs.Write(title, 0, title.Length);
                            Application.Restart();
                        }
                        else if (int.Parse(mn) < 10)
                        {
                            mnn = "0" + mn;
                            all = "" + yy + "" + mnn + "" + dy + "";


                            Byte[] title = new UTF8Encoding(true).GetBytes(all);
                            fs.Write(title, 0, title.Length);
                            Application.Restart();
                        }
                        else if (int.Parse(dy) < 10)
                        {
                            dyy = "0" + dy;
                            all = "" + yy + "" + mn + "" + dyy + "";


                            Byte[] title = new UTF8Encoding(true).GetBytes(all);
                            fs.Write(title, 0, title.Length);
                            Application.Restart();
                        }
                        else
                        {
                            mnn = mn;
                            dyy = dy;
                            all = "" + yy + "" + mnn + "" + dyy + "";


                            Byte[] title = new UTF8Encoding(true).GetBytes(all);
                            fs.Write(title, 0, title.Length);
                            Application.Restart();
                        }
                    }
                }

                label3.Visible = false;
                
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    label3.Visible = true;
                }
            }



            
            

        }
    }
}

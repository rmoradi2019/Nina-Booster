using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nina_Booster
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            //get setting
            var MyIni = new IniFile("config.ini");
            var GM = MyIni.Read("Graphic_Mode", "setting");
            var PC = MyIni.Read("Ping_Check", "setting");

            if (GM == "1")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            
            if(PC=="1")
            {
                radioButton6.Checked = true;
                radioButton5.Checked = false;
            }
            else
            {
                radioButton6.Checked = false;
                radioButton5.Checked = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var MyIni = new IniFile("config.ini");
            if (radioButton1.Checked) 
            {
                MyIni.Write("Graphic_Mode", "0", "setting");
            }
            else if(radioButton2.Checked)
            {
                MyIni.Write("Graphic_Mode", "1", "setting");
            }

            if(radioButton6.Checked)
            {
                MyIni.Write("Ping_Check", "1", "setting");
            }
            else if (radioButton5.Checked)
            {
                MyIni.Write("Ping_Check", "0", "setting");
            }
            button1.Text = "Applied";
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}

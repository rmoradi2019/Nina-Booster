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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 1000, WinAPI.BLEND);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            new Zula().ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            
            new MTA().ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            new Woltk().ShowDialog();
        }
    }
}

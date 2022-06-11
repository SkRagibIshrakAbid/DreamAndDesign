using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomePage
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            homeDefault1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            aboutUs1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            homeDefault1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;
            login1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Type something to search!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Session.search = textBox1.Text;
                searchPanel1.BringToFront();
            }
            
        }
        private void button14_Click(object sender, EventArgs e)
        {
            //feedback1.BringToFront();
            MessageBox.Show("Need to login first to provide feedback!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    static class Session
    {
        public static string sName = "zzz";
        public static string sGender;
        public static string s_rName;
        public static string search;
    }
}

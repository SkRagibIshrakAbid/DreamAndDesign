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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button4.Text = "       " + Session.sName;
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
            ownerProfile1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Session.sName = "zzz";
            this.Hide();
            ((Form3)this.TopLevelControl).Hide();
            Form1 f6 = new Form1();
            f6.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            feedback1.BringToFront();
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
    }
}

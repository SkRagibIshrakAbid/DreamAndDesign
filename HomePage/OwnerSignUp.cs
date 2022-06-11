using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace HomePage
{
    public partial class OwnerSignUp : UserControl
    {
        public OwnerSignUp()
        {
            InitializeComponent();
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox1.Focus();
                errorProvider4.SetError(this.textBox4, "You can't leave this empty");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "You can't leave this empty");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox1.Focus();
                errorProvider2.SetError(this.textBox2, "You can't leave this empty");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox1.Focus();
                errorProvider3.SetError(this.textBox3, "You can't leave this empty");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "You can't leave this empty");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) == true)
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "You can't leave this empty");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) == true)
            {
                textBox7.Focus();
                errorProvider7.SetError(this.textBox7, "You can't leave this empty");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "INSERT INTO O_LOGIN VALUES (@name,@uname,@password,@dob,@phone,@address,@email,@gender,@img)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@uname", textBox2.Text);
            cmd.Parameters.AddWithValue("@password", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone", textBox5.Text);
            cmd.Parameters.AddWithValue("@address", textBox6.Text);
            cmd.Parameters.AddWithValue("@email", textBox7.Text);
            cmd.Parameters.AddWithValue("@gender", Session.sGender);
            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@img", new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[])));
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                MessageBox.Show("Registered");
                Session.sName = textBox2.Text;
                ((Form1)this.TopLevelControl).Hide();
                Form3 f3 = new Form3();
                f3.Show();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Session.sGender = "male";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Session.sGender = "female";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "JPG File (*.jpg) | *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }
    }
}

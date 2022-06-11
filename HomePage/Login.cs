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

namespace HomePage
{
    public partial class Login : UserControl
    {
        //Cs Conection String
        //string cs = "";
        
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            if (status == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "You can't keep this box empty!");
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
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "You can't keep this box empty!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            if (string.IsNullOrEmpty(textBox1.Text) == false && string.IsNullOrEmpty(textBox2.Text) == false)
            {
                string ucheck = textBox1.Text;
                if (ucheck[0] == 'D')
                {
                    SqlConnection conn = new SqlConnection(cs);
                    string query = "select * from D_LOGIN where Name = @user and Password = @pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Session.sName = textBox1.Text;
                        ((Form1)this.TopLevelControl).Hide();
                        Form2 f2 = new Form2();
                        f2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }
                else if (ucheck[0] == 'O')
                {
                    SqlConnection conn = new SqlConnection(cs);
                    string query = "select * from O_LOGIN where UserName = @user and Password = @pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Session.sName = textBox1.Text;
                        ((Form1)this.TopLevelControl).Hide();
                        Form3 f3 = new Form3();
                        f3.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }
                else if (ucheck[0] == 'A')
                {
                    SqlConnection conn = new SqlConnection(cs);
                    string query = "select * from A_LOGIN where UserName = @user and Password = @pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Session.sName = textBox1.Text;
                        ((Form1)this.TopLevelControl).Hide();
                        Form4 f4 = new Form4();
                        f4.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                }

            }
            else
            {
                MessageBox.Show("Please fill both boxes!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        SignUpCatagory ns = new SignUpCatagory();
        int lflag = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (lflag == 0)
            {
                this.Controls.Add(ns);
                ns.BringToFront();
                lflag = 1;
            }
            else
            {
                ns.Show();
            }
        }

    }
    }

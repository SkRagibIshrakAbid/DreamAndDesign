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
    public partial class DecoratorSignUp : UserControl
    {
        public DecoratorSignUp()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        

        public object ErrorProvider1 { get; private set; }



        

        private void button1_Click(object sender, EventArgs e)
        {


            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "INSERT INTO D_LOGIN VALUES (@name,@email,@pass,@phone,@gender,@dob,@exp,@img,@C_name,@Address)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@email", textBox5.Text);
            cmd.Parameters.AddWithValue("@pass", textBox4.Text);
            cmd.Parameters.AddWithValue("@phone", textBox3.Text);
            cmd.Parameters.AddWithValue("@gender", Session.sGender);
            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@exp", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@img", new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[])));
            cmd.Parameters.AddWithValue("@C_name", textBox6.Text);
            cmd.Parameters.AddWithValue("@Address", richTextBox1.Text);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                MessageBox.Show("Registered");
                Session.sName = textBox6.Text;
                ((Form1)this.TopLevelControl).Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!this.textBox5.Text.Contains('@') || !this.textBox5.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "JPG File (*.jpg) | *.jpg";


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);

            }
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox4.UseSystemPasswordChar = false;
                    textBox2.UseSystemPasswordChar = false;

                    break;
                default:
                    textBox4.UseSystemPasswordChar = true;
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string user_name = textBox1.Text;
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Enter your Name..!!");
            }
            else if (user_name[0] != 'D' && user_name[1] != '_')
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Username must start with 'D_'");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true || validate_emailaddress.IsMatch(textBox5.Text) != true)
            {

                MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox5.Focus();

            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{5,10}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider3.SetError(this.textBox4, "Please Enter your Password..!!");
            }

            // else
            // {

            //    errorProvider3.Clear();
            // }


            // if (string.IsNullOrWhiteSpace(textBox4.Text))
            // {
            //   throw new Exception("Password should not be empty");
            //  }



            else if (!hasLowerChar.IsMatch(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider3.SetError(this.textBox4, "Password should contain At least one lower case letter");
                //MessageBox.Show("Password should contain At least one lower case letter", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 

            }
            else if (!hasUpperChar.IsMatch(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider3.SetError(this.textBox4, "Password should contain At least one upper case letter");
                //MessageBox.Show("Password should contain At least one upper case letter", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (!hasMiniMaxChars.IsMatch(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider3.SetError(this.textBox4, "Password should not be less than or greater than 8 characters");
                //MessageBox.Show("Password should not be less than or greater than 8 characters", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (!hasNumber.IsMatch(textBox4.Text))

            {
                textBox4.Focus();
                errorProvider3.SetError(this.textBox4, "Password should contain At least one numeric value");
                //MessageBox.Show("Password should contain At least one numeric value", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            else if (!hasSymbols.IsMatch(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider3.SetError(this.textBox4, "Password should contain At least one special case characters");
                //MessageBox.Show("Password should contain At least one special case characters", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                errorProvider3.Clear();
            }
        }

        

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (textBox4.Text.Equals(textBox2.Text))
            {
                errorProvider4.Clear();

            }
            else
            {
                textBox2.Focus();
                errorProvider4.SetError(this.textBox2, "Enter same password in both!!");
                //MessageBox.Show("Enter same password in both", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }



        }



        private static Regex email_validation()
        {
            string pattern = @"[a-z0-9][.-_][a-z0-9]+[@][a-z]+[.][a-z]{2,3}";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }

        static Regex validate_emailaddress = email_validation();

        private void textBox3_Leave(object sender, EventArgs e)
        {
            // var num = new Regex(@"[0-9]+");
            //if (string.IsNullOrEmpty(textBox1.Text) == true)
            // {
            //   textBox3.Focus();
            //  errorProvider5.SetError(this.textBox1, "Please Enter your Name..!!");
            // }



            // else if (!num.IsMatch(textBox3.Text) || textBox3.Text.Length >= 11)
            // { 
            //  errorProvider5.SetError(this.textBox3, "Enter the Valid Phone number");
            // textBox3.Focus();
            //}

            // else

            // {
            //  errorProvider5.Clear();
            //  }

            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider5.SetError(this.textBox3, "Please Enter your Number..!!");
            }
            else
            {
                errorProvider5.Clear();
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Session.sGender = "male";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Session.sGender = "female";

        }
    }
}

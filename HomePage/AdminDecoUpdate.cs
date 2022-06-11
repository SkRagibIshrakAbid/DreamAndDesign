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
using System.IO;

namespace HomePage
{
    public partial class AdminDecoUpdate : UserControl
    {
        public AdminDecoUpdate()
        {
            InitializeComponent();
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from D_LOGIN";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            ///Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[7];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
            //
            
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
            string query = "update D_LOGIN set Email=@email,Password=@pass,Phone_number=@phone,Gender=@gender,Dob=@dob,Experience=@exp,Image=@img,C_name=@C_name,Address=@Address where Name=@name";

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
                MessageBox.Show("Updated");
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
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string gender = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            if (gender == "male")
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton3.Checked = true;
            }
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[7].Value);
        }

    }
}

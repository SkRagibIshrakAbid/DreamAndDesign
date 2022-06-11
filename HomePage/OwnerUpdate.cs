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
    public partial class OwnerUpdate : UserControl
    {
        public OwnerUpdate()
        {
            InitializeComponent();
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
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

        private void button4_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from O_LOGIN where UserName='" + Session.sName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            ///Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[8];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
            //
            textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[0].Cells[3].Value.ToString());
            textBox5.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();

            string gender = dataGridView1.Rows[0].Cells[7].Value.ToString();
            if (gender == "male")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.Rows[0].Cells[8].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "update O_LOGIN set Name=@name,Password=@password,Dob=@dob,Phone=@phone,Address=@address,Email=@email,Gender=@gender,Image=@img where UserName=@uname";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@uname", Session.sName);
            cmd.Parameters.AddWithValue("@password", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone", textBox5.Text);
            cmd.Parameters.AddWithValue("@address", textBox6.Text);
            cmd.Parameters.AddWithValue("@email", textBox7.Text);
            cmd.Parameters.AddWithValue("@gender", Session.sGender);////Error Here
            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@img", new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[])));
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                MessageBox.Show("Updated");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Session.sGender = "male";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Session.sGender = "female";
        }
    }
}

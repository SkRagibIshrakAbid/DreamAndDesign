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
using System.IO;

namespace HomePage
{
    public partial class DecoAddPanel : UserControl
    {
        public DecoAddPanel()
        {
            InitializeComponent();
            //grid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "INSERT INTO DecoAdd VALUES (@name,@price,@type,@desc,@img,@uname)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@price", textBox2.Text);
            cmd.Parameters.AddWithValue("@type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@desc", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@img", new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[])));
            cmd.Parameters.AddWithValue("@uname", Session.sName);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                MessageBox.Show("Add posted!");
                //Berthota
                string css = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(css);
                string queryy = "select * from DecoAdd where postedby='" + Session.sName + "'";
                SqlDataAdapter sda = new SqlDataAdapter(queryy, con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;

                ///Image Column
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

                //AUTOSIZE
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //Image Height
                dataGridView1.RowTemplate.Height = 50;
                //
                textBox1.Clear();
                textBox2.Clear();
                richTextBox1.Clear();
                comboBox1.ResetText();

                pictureBox1.Image = Properties.Resources._48019412_invalid_red_stamp_text_on_white;
            }
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

        private void button7_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from DecoAdd where postedby='" + Session.sName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            ///Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "update DecoAdd set price=@price, type=@type, description=@rich, image=@img where postedby=@uname and name=@name";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@price", textBox2.Text);
            cmd.Parameters.AddWithValue("@type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@rich", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@img", new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[])));
            cmd.Parameters.AddWithValue("@uname", Session.sName);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a == 1)
            {
                MessageBox.Show("Add modified!");
                //Berthota
                string css = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(css);
                string queryy = "select * from DecoAdd where postedby='" + Session.sName + "'";
                SqlDataAdapter sda = new SqlDataAdapter(queryy, con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;

                ///Image Column
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

                //AUTOSIZE
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //Image Height
                dataGridView1.RowTemplate.Height = 50;
                //
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.ResetText();

                richTextBox1.Clear();
                pictureBox1.Image = Properties.Resources._48019412_invalid_red_stamp_text_on_white;
            }
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[4].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "delete from DecoAdd where postedby=@uname and name=@name";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@price", textBox2.Text);
            cmd.Parameters.AddWithValue("@type", comboBox1.Text);
            //cmd.Parameters.AddWithValue("@rich", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@img", new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[])));
            cmd.Parameters.AddWithValue("@uname", Session.sName);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a == 1)
            {
                MessageBox.Show("Add Deleted!");
                //Berthota
                string css = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(css);
                string queryy = "select * from DecoAdd where postedby='" + Session.sName + "'";
                SqlDataAdapter sda = new SqlDataAdapter(queryy, con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;

                ///Image Column
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)dataGridView1.Columns[4];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

                //AUTOSIZE
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //Image Height
                dataGridView1.RowTemplate.Height = 50;
                //
                textBox1.Clear();
                textBox2.Clear();
                richTextBox1.Clear();
                comboBox1.ResetText();

                pictureBox1.Image = Properties.Resources._48019412_invalid_red_stamp_text_on_white;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
            comboBox1.ResetText();
            pictureBox1.Image = Properties.Resources._48019412_invalid_red_stamp_text_on_white;
        }
    }
}

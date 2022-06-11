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
    public partial class ViewOrders : UserControl
    {
        public ViewOrders()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Orderlist where postedby='"+Session.sName+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            ///Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "INSERT INTO AcceptedOrder VALUES (@Oname,@name,@price,@type,@desc,@img,@postuname)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@price", textBox2.Text);
            cmd.Parameters.AddWithValue("@type", textBox3.Text);
            cmd.Parameters.AddWithValue("@desc", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@img", new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[])));
            cmd.Parameters.AddWithValue("@Oname", textBox4.Text);
            cmd.Parameters.AddWithValue("@postuname", Session.sName);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                MessageBox.Show("Order accepted!");
                string css = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection connn = new SqlConnection(css);
                string queryyy = "delete from Orderlist where postedby=@uuname and name=@nname";
                SqlCommand cmdd = new SqlCommand(queryyy, connn);
                cmdd.Parameters.AddWithValue("@nname", textBox1.Text);
                cmdd.Parameters.AddWithValue("@uuname", Session.sName);
                connn.Open();
                int a = cmdd.ExecuteNonQuery();
                if (a == 1)
                {
                    string csss = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                    SqlConnection con = new SqlConnection(csss);
                    string quer = "select * from Orderlist where postedby='" + Session.sName + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(quer, con);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;

                    ///Image Column
                    DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                    dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
                    dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

                    //AUTOSIZE
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //Image Height
                    dataGridView1.RowTemplate.Height = 50;

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "INSERT INTO RejectedOrder VALUES (@Oname,@name,@price,@type,@desc,@img,@postuname)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@price", textBox2.Text);
            cmd.Parameters.AddWithValue("@type", textBox3.Text);
            cmd.Parameters.AddWithValue("@desc", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@img", new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[])));
            cmd.Parameters.AddWithValue("@Oname", textBox4.Text);
            cmd.Parameters.AddWithValue("@postuname", Session.sName);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                MessageBox.Show("Order Rejected!");
                string css = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection connn = new SqlConnection(css);
                string queryyy = "delete from Orderlist where postedby=@uuname and name=@nname";
                SqlCommand cmdd = new SqlCommand(queryyy, connn);
                cmdd.Parameters.AddWithValue("@nname", textBox1.Text);
                cmdd.Parameters.AddWithValue("@uuname", Session.sName);
                connn.Open();
                int a = cmdd.ExecuteNonQuery();
                if (a == 1)
                {
                    string csss = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                    SqlConnection con = new SqlConnection(csss);
                    string quer = "select * from Orderlist where postedby='" + Session.sName + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(quer, con);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;

                    ///Image Column
                    DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                    dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
                    dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

                    //AUTOSIZE
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //Image Height
                    dataGridView1.RowTemplate.Height = 50;

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

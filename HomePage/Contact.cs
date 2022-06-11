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
using System.Data.OleDb;
using System.Diagnostics;
namespace HomePage
{
    public partial class Contact : UserControl
    {
        public Contact()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "INSERT INTO message VALUES (@sender,@reciever,@message,@time)";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@sender", Session.sName);
            cmd.Parameters.AddWithValue("@reciever", Session.s_rName);
            cmd.Parameters.AddWithValue("@message", textBox1.Text);
            cmd.Parameters.AddWithValue("@time", DateTime.Now);

            conn.Open();
            int r = cmd.ExecuteNonQuery();



            //adding to the listbox
            listBox1.Items.Add("Me :    " + textBox1.Text);
            textBox1.Text = "";
        }
    }
}

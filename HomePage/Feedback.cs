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
    public partial class Feedback : UserControl
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "INSERT INTO All_Feedback VALUES (@feedback,@uname)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@feedback", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@uname", Session.sName);

            conn.Open();
            int r = cmd.ExecuteNonQuery();
            if (r == 1)
            {
                MessageBox.Show("Feedback Submitted!");
            }
        }
    }
}

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
    public partial class ConversationPanel : Form
    {
        public ConversationPanel()
        {
            InitializeComponent();
        }

        private void ConversationPanel_Load(object sender, EventArgs e)
        {
            //string temp = "";
            

        }
        private void listMessage_SelectedIndexChanged(object sender, EventArgs e)

        {
            listBox1.Items.Clear();
            Session.s_rName = listMessage.SelectedItem.ToString();
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "SELECT M_ID, SENDER, RECIEVER, MESSAGE FROM MESSAGE WHERE (RECIEVER = '" + Session.sName + "' AND SENDER = '" + Session.s_rName + "') OR (RECIEVER = '" + Session.s_rName + "' AND SENDER = '" + Session.sName + "')";

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader result = cmd.ExecuteReader();

            while (result.Read())
            {
                // listMessage.Items.Add("Me: " + result.GetValue(1));
                listBox1.Items.Add(result.GetValue(1) + ": " + result.GetValue(3)); // reciever


            }

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

        private void button7_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "SELECT M_ID, SENDER, RECIEVER, MESSAGE FROM MESSAGE WHERE RECIEVER = '" + Session.sName + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader result = cmd.ExecuteReader();

            while (result.Read())
            {
                if (!listMessage.Items.Contains(result.GetValue(1).ToString()))
                {
                    // listMessage.Items.Add("Me: " + result.GetValue(1));
                    listMessage.Items.Add(result.GetValue(1)); // reciever

                }



            }

            conn.Close();
        }
    }
}

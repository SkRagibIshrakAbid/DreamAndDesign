using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomePage
{
    public partial class OwnerProfile : UserControl
    {
        public OwnerProfile()
        {
            InitializeComponent();
        }
        OAcceptReject oa = new OAcceptReject();
        int oaf = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (oaf == 0)
            {
                this.Controls.Add(oa);
                oa.BringToFront();
                oaf = 1;
            }
            else
            {
                oa.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        OwnerWantedPost ow = new OwnerWantedPost();
        int owf = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (owf == 0)
            {
                this.Controls.Add(ow);
                ow.BringToFront();
                owf = 1;
            }
            else
            {
                ow.Show();
            }
        }
        OwnerRequestFund orf = new OwnerRequestFund();
        int orff = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            if (orff == 0)
            {
                this.Controls.Add(orf);
                orf.BringToFront();
                orff = 1;
            }
            else
            {
                orf.Show();
            }
        }
        OwnerUpdate ou = new OwnerUpdate();
        int ouf = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (ouf == 0)
            {
                this.Controls.Add(ou);
                ou.BringToFront();
                ouf = 1;
            }
            else
            {
                ou.Show();
            }
        }
        MainConvoPanel mcp = new MainConvoPanel();
        int mcpf = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            if (mcpf == 0)
            {
                this.Controls.Add(mcp);
                mcp.BringToFront();
                mcpf = 1;
            }
            else
            {
                mcp.Show();
            }
        }
    }
}

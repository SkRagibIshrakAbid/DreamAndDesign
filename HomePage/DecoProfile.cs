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
    public partial class DecoProfile : UserControl
    {
        public DecoProfile()
        {
            InitializeComponent();
        }
        DecoProfileUpdate dds = new DecoProfileUpdate();
        int ddflag = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            if (ddflag == 0)
            {
                this.Controls.Add(dds);
                dds.BringToFront();
                ddflag = 1;
            }
            else
            {
                dds.Show();
            }
        }
        DecoAddPanel das = new DecoAddPanel();
        int dasflag = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (dasflag == 0)
            {
                this.Controls.Add(das);
                das.BringToFront();
                dasflag = 1;
            }
            else
            {
                das.Show();
            }
        }
        ViewOrders vo = new ViewOrders();
        int of = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (of == 0)
            {
                this.Controls.Add(vo);
                vo.BringToFront();
                of = 1;
            }
            else
            {
                vo.Show();
            }
        }
        ForDecoWantedPost dwp = new ForDecoWantedPost();
        int dwpf = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if (dwpf == 0)
            {
                this.Controls.Add(dwp);
                dwp.BringToFront();
                dwpf = 1;
            }
            else
            {
                dwp.Show();
            }
        }
        DecoRefundPanel drp = new DecoRefundPanel();
        int drpf = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            if (drpf == 0)
            {
                this.Controls.Add(drp);
                drp.BringToFront();
                drpf = 1;
            }
            else
            {
                drp.Show();
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

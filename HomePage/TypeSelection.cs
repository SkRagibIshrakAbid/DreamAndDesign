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
    public partial class TypeSelection : UserControl
    {
        public TypeSelection()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        ModernAdd ma = new ModernAdd();
        int mf = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (mf == 0)
            {
                this.Controls.Add(ma);
                ma.BringToFront();
                mf = 1;
            }
            else
            {
                ma.Show();
            }
        }
        NaturalAdd na = new NaturalAdd();
        int nf = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (nf == 0)
            {
                this.Controls.Add(na);
                na.BringToFront();
                nf = 1;
            }
            else
            {
                na.Show();
            }
        }
        VintageAdd va = new VintageAdd();
        int vf = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (vf == 0)
            {
                this.Controls.Add(va);
                va.BringToFront();
                vf = 1;
            }
            else
            {
                ma.Show();
            }
        }
    }
}

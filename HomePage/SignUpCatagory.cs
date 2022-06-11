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
    public partial class SignUpCatagory : UserControl
    {
        public SignUpCatagory()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DecoratorSignUp ds = new DecoratorSignUp();
        int sflag = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            if (sflag == 0)
            {
                this.Controls.Add(ds);
                ds.BringToFront();
                sflag = 1;
            }
            else
            {
                ds.Show();
            }
        }
        OwnerSignUp dsds = new OwnerSignUp();
        int ssflag = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (ssflag == 0)
            {
                this.Controls.Add(dsds);
                dsds.BringToFront();
                ssflag = 1;
            }
            else
            {
                dsds.Show();
            }
        }
    }
}

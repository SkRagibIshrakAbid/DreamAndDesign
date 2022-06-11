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
    public partial class HomeDefault : UserControl
    {
        public HomeDefault()
        {
            InitializeComponent();
        }
        TypeSelection uc = new TypeSelection();
        int flag = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if(flag == 0)
            {
                this.Controls.Add(uc);
                uc.BringToFront();
                flag = 1;
            }
            else
            {
                uc.Show();
            }
                  
        }
    }
}

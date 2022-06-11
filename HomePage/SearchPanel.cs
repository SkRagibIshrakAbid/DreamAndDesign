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
    public partial class SearchPanel : UserControl
    {
        public SearchPanel()
        {
            InitializeComponent();
            Search s = new Search() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            s.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.panel1.Controls.Add(s);
            s.Show();
        }

    }
}

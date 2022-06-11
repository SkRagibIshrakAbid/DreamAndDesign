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
    public partial class MainConvoPanel : UserControl
    {
        public MainConvoPanel()
        {
            InitializeComponent();
            ConversationPanel cp = new ConversationPanel() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            cp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.panel1.Controls.Add(cp);
            cp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

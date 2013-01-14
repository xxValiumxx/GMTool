using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMTool
{
    public partial class frmLogin : Form
    {
        public Network network = new Network();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string response = network.HttpPost("http://www.status3gaming.com/gmtool/", "user=" + txtUsername.Text + "&pass=" + txtPassword.Text);
            MessageBox.Show(response, "Response", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
    }
}

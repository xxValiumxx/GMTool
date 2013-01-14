using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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

            if(response == "0"){
                MessageBox.Show("Failed Login", "Response", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (Regex.IsMatch(response, "[0-9A-Fa-f]{40}"))
            {
                //save the hash
                MessageBox.Show("You are a winnar!", "Response", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}

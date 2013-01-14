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
        private NotifyIcon  sysTrayIcon; 
        private ContextMenu sysTrayMenu;

        

        public frmLogin()
        {
            InitializeComponent();

            //Create Context Menu for system tray.
            sysTrayMenu = new ContextMenu();
            sysTrayMenu.MenuItems.Add("Check for new tickets...", OnRefresh);
            sysTrayMenu.MenuItems.Add("Quit", OnExit);

            sysTrayIcon = new NotifyIcon();
            sysTrayIcon.Text = "GM Tool";
            sysTrayIcon.Icon = Properties.Resources.Tray;
            
            // Add menu to tray icon and show it. 
            sysTrayIcon.ContextMenu = sysTrayMenu;
            sysTrayIcon.Visible = true;
            sysTrayIcon.BalloonTipClicked += new EventHandler(sysTrayIcon_BaloonTipClicked);
            sysTrayIcon.ShowBalloonTip(5000, "GM Tool", "Tray Monitor Active", ToolTipIcon.None);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            sysTrayIcon.ShowBalloonTip(5000, "GM Tool", "Checking for new tickets", ToolTipIcon.None);
        }

        void sysTrayIcon_BaloonTipClicked(Object sender, EventArgs e)
        {
            MessageBox.Show("you clicked the button");
        }

            
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string response = network.HttpPost("http://www.status3gaming.com/gmtool/", "user=" + txtUsername.Text + "&pass=" + txtPassword.Text);

            if(response == "0"){
                MessageBox.Show("Failed Login", "Response", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (Regex.IsMatch(response, "[0-9A-Fa-f]{40}"))
            {
                Program.SetHash(response);
                MessageBox.Show("Successfully Logged In", "Response", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Visible = false;
            }
        }

    }
}

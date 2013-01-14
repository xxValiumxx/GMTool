using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMTool
{
    static class Program
    {
        public static string hash = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        public static void SetHash(string hash)
        {
            Program.hash = hash;
        }

        public static string GetHash()
        {
            return Program.hash;
        }
    }
}

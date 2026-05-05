using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace game_shop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm login = new LoginForm();

            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }

        }
    }
}

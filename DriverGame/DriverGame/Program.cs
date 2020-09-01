using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DriverGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (DriverGame frm = new DriverGame())
            {
                frm.Show();
                frm.InitializeGraphics();
                Application.Run(frm);
                frm.SaveHighScores();
            }
        }
    }
}
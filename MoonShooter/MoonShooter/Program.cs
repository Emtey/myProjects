using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MoonShooter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (MoonShooter moonShooterGame = new MoonShooter())
                moonShooterGame.Run();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20180407_SpaceInvaders
{
    static class Program
    {
        public static bool win = false;

        public static string filename = "highscore.txt";

        public static int score = 0;
        public static int progress;
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSpaceInvaders());
        }
    }
}

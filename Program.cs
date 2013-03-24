using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IVAUDToolBox
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain main = new frmMain();
            if (args.Length > 0) main.toOpen = args[0];
            Application.Run(main); 
        }
    }
}

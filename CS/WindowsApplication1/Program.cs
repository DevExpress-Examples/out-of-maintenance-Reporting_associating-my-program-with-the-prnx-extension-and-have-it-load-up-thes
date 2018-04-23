using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsApplication1 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string FileToOpen = null;
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(args.Length > 0)
                FileToOpen = args[0];
            Application.Run(new Form1());
        }
    }
}
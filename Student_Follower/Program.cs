using Student_Follower.Forms.Teachers;
using System;
using System.Windows.Forms;

namespace Student_Follower
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //form1 Başlayacak..
        }
    }
}

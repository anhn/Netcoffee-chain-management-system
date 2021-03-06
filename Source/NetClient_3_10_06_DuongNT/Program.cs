using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
namespace NetCafeClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process pr = Process.GetCurrentProcess();
            string s = pr.ProcessName;
            if (Process.GetProcessesByName(s).Length > 1)
            {
                MessageBox.Show("Ứng dụng đang chạy!");
                Application.ExitThread();
                Application.Exit();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
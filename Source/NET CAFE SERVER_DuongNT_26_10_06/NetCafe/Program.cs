using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
namespace NetCafe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            // chi cho phep chay 1 lan
            Process pr = Process.GetCurrentProcess();
            string s = pr.ProcessName;
            if (Process.GetProcessesByName(s).Length > 1)
            {
                MessageBox.Show("Ứng dụng đang chạy!");
                Application.ExitThread();
                Application.Exit();
                //************************
                //Modified  by NghienPC
                Process.GetCurrentProcess().Kill();
                //************************
                return;
            }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FrmMain frmMain = new FrmMain();
                Application.Run(frmMain);
                frmMain.Dispose();                
                Application.ExitThread();
                //************************
                //Modified  by NghienPC
                Process.GetCurrentProcess().Kill();
                //************************
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Xuất hiện lỗi nghiêm trọng trong hệ thống! Chương trình sẽ tự động thoát ngay. Bạn hãy khởi động lại chương trình sau 1 phút !");
                //MessageBox.Show(ex.Message);
                Application.ExitThread();
                Application.Exit();
                //************************
                //Modified  by NghienPC
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
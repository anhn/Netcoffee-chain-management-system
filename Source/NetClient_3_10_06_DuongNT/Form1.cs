using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using SystemPack;
using System.Timers;
using System.IO;
namespace NetCafeClient
{
    public partial class FrmMain : Form
    {
        private FrmLockForm frmLockForm;
        private System.Timers.Timer tmConnect;
        private Form2 form2;
        private string strIP;
        private bool isShowLockForm = false;
        private bool lockFormShowing = false;
        
        public FrmMain()
        {
            InitializeComponent();
            //frmLockForm = new FrmLockForm();
            form2 = new Form2();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            systemControl1.DeleteIEHistory(); // xoa history
            systemControl1.DeleteIECookies(); // xoa cookies
            //systemControl1.DeleteIECache(); // xoa cache
            tmConnect = new System.Timers.Timer(3000);
            tmConnect.Elapsed += new ElapsedEventHandler(OnTmConnect);
            tmConnect.Enabled = true;
            //clientSocket1.Connect(strIP);            
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
            Top = 0;
            //Height = Screen.PrimaryScreen.Bounds.Height;
            //frmLockForm.Show();
            //MessageBox.Show("Hey");
            CheckLockForm.Enabled = true;
        }
        private void OnTmConnect(object sender, ElapsedEventArgs e)
        {
            if (!clientSocket1.Connected)
            {
                tmConnect.Enabled = false;
                if (!clientSocket1.Connect(""))
                    tmConnect.Enabled = true;
            }
        }
        private void clientSocket1_OnConnect(object sender)
        {

        }
        protected override System.Boolean ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if ((msg.Msg == 0x104) && (((int)
            msg.LParam) == 0x203e0001))
                return true;
            return false;
        }


        private void clientSocket1_OnReceive(object sender, Commands comd, uint lParam, string strParam)
        {

            /*
            if ((comd != Commands.Unlock) && (comd != Commands.TotalTime))
                MessageBox.Show("Nhan cmd = " + comd.ToString());*/
            if (comd == Commands.GetProcess)
            {
                string s = "";                
                ApplicationInform[] app = systemControl1.GetProcesses();
                //MessageBox.Show("size" + app.Length.ToString());
                for (int i = 0; i < app.Length; i++)
                    s += app[i].AppName + " "  + (char)128 + app[i].PID.ToString() + (char)(128);
                clientSocket1.Send(comd, 0, s);

            }
            else if (comd == Commands.DeleteProcess)
            {
                uint pid = lParam;
                systemControl1.KillProcess(pid);
            }
            else if (comd == Commands.GetClientName)
            {
                clientSocket1.Send(comd, 0, Dns.GetHostName());
                //MessageBox.Show("Sent hostname");
            }
            else if (comd == Commands.Lock) // lock
            {
                //MessageBox.Show("lock");
                systemControl1.LockInputSystems();
                isShowLockForm = true;
                //form2.Show();
                //form2 = new Form2();
                //frmLockForm.Show();

                
                //if (form2 != null)
                  //  form2.Invoke(new dele_ShowLockForm(ShowLockForm), true);
                 
                //frmLockForm.ShowDialog();
                //frmLockForm.Invoke(new dele_ShowLockForm(ShowLockForm), 1);
            }
            else if (comd == Commands.Unlock) // lock
            {
                
                //frmLockForm.Invoke(new dele_ShowLockForm(ShowLockForm), 0);
                //form2.Dispose();
                //frmLockForm.Hide();
                /*
                if (form2 != null)
                    form2.Invoke(new dele_ShowLockForm(ShowLockForm), false);
                 */
                //form2.Hide();
                isShowLockForm = false;
                systemControl1.UnlockInputSystems();
                
                //MessageBox.Show("unlock");
            }
            else if (comd == Commands.Shutdown) // lock
                WinController.WindowsController.ExitWindows(WinController.RestartOptions.PowerOff, true);
            else if (comd == Commands.Restart) // lock
                WinController.WindowsController.ExitWindows(WinController.RestartOptions.Reboot, true);
            else if (comd == Commands.Hibernate) // lock
                WinController.WindowsController.ExitWindows(WinController.RestartOptions.Hibernate, true);
            else if (comd == Commands.TotalTime)
            {
                //MessageBox.Show(data);
                int t = (int)lParam;
                int h = (t / 60);
                int m = t % 60;
                String s = h.ToString() + "h" + m.ToString() + "ph";
                dele_TimeChange Hi = new dele_TimeChange(TimeChange);
                textBox1.Invoke(Hi, s);
            }
            else if (comd == Commands.TotalPay)
            {
                textBox3.Invoke(new dele_PayChange(PayChange), lParam.ToString());
            }

        }
        private delegate void dele_ShowLockForm(bool sw);
        private void ShowLockForm(bool sw)
        {
            if (sw) form2.Show();
            else form2.Hide();
        }
        private delegate void dele_TimeChange(String s);
        private void TimeChange(String s)
        {
            textBox1.Text = s;
        }
        private delegate void dele_PayChange(String s);
        private void PayChange(String s)
        {
            textBox3.Text = s;
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CheckLockForm_Tick(object sender, EventArgs e)
        {
            CheckLockForm.Enabled = false;
            try
            {
                
                if (isShowLockForm && !lockFormShowing) // hien form
                {
                    lockFormShowing = true;
                    form2.Show();
                }
                else if (!isShowLockForm && lockFormShowing)
                {
                    lockFormShowing = false; // an form
                    form2.Hide();
                }

            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.ToString());
            }
            CheckLockForm.Enabled = true;
        }
        
        private void clientSocket1_OnDisconnect(object sender)
        {
            tmConnect.Enabled = true;            
        }
    }
}
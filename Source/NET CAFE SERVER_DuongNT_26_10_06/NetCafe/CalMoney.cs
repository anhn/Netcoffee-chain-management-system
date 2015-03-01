using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCafe
{
    public partial class FrmCalMoney : Form
    {
         public FrmCalMoney()
        {
            InitializeComponent();
            WinAPI.KillWinCaption(this.Handle);
        }
        public string StartTime
        {
            get {return lbTimeStart.Text;}
            set {lbTimeStart.Text = value;}
        }
        public string UsedTime
        {
            get { return lbTimeUsed.Text; }
            set { lbTimeUsed.Text = value; }
        }
        public string Money
        {
            get { return lbMoney.Text; }
            set { lbMoney.Text = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
             Close();
        }

        private void gradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinAPI.ReleaseCapture();
                WinAPI.SendMessage(this.Handle, WinAPI.WM_NCLBUTTONDOWN, WinAPI.HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             Close();
        }

        private void gradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
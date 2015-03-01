using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace NetCafe
{
    public partial class BossMan : Form
    {
        public BossMan()
        {
            InitializeComponent();
            WinAPI.KillWinCaption(this.Handle);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinAPI.ReleaseCapture();
                WinAPI.SendMessage(this.Handle, WinAPI.WM_NCLBUTTONDOWN, WinAPI.HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            linkLabel1.LinkColor = Color.RoyalBlue;
        }

        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            linkLabel1.LinkColor = Color.RoyalBlue;
        }

        private void linkLabel2_MouseHover(object sender, EventArgs e)
        {
            linkLabel2.LinkColor = Color.RoyalBlue;
        }

        private void linkLabel2_MouseLeave(object sender, EventArgs e)
        {
            linkLabel2.LinkColor = Color.RoyalBlue;
        }

        private void BossMan_Load(object sender, EventArgs e)
        {
            WinAPI.KillWinCaption(this.Handle);   
        }

        private void BossMan_Load_1(object sender, EventArgs e)
        {

        }

        private void BossMan_Load_2(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPasswordChange pw = new FrmPasswordChange();
            WinEffect.AnimateWindow(pw, 300, AnimateWindowStyle.AW_CENTER);
            pw.ShowDialog(true);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color cLeft = panel1.BackColor;
            Color cRight = SystemColors.GradientActiveCaption;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(panel1.Width + 100, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BossMan_Paint(object sender, PaintEventArgs e)
        {
            Color cLeft = this.BackColor;
            Color cRight = Color.White;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(this.Width + 100, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAccount frmAcc = new FrmAccount();
            WinEffect.AnimateWindow(frmAcc, 300, AnimateWindowStyle.AW_CENTER);
            frmAcc.ShowDialog(false);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        /*
        private void DrawGradient(Graphics g)
        {
            Color cLeft = this.BackColor;
            Color cRight = SystemColors.GradientActiveCaption;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point((int)(grpHelp.Width / 2), grpHelp.Height ), new Point((int)(grpHelp.Width / 2), 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            // Fill with gradient 
            g.FillRectangle(GBrush, rect);
        }*/


    }
}
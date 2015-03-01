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
    public partial class PriceTutorial : Form
    {
        public PriceTutorial()
        {
            InitializeComponent();
            WinAPI.KillWinCaption(this.Handle);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // mo form
            FrmAccount frmAcc = new FrmAccount();
            WinEffect.AnimateWindow(frmAcc, 300, AnimateWindowStyle.AW_CENTER);
            frmAcc.ShowDialog(false);
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            //linkLabel1.LinkColor = Color.LightSkyBlue;
        }

        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            //linkLabel1.LinkColor = Color.RoyalBlue;
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

        private void linkLabel2_MouseHover(object sender, EventArgs e)
        {
            //linkLabel2.LinkColor = Color.Red;
        }

        private void linkLabel2_MouseLeave(object sender, EventArgs e)
        {
            //linkLabel2.LinkColor = Color.Maroon;
        }

        private void UserMan_Load(object sender, EventArgs e)
        {
            WinAPI.KillWinCaption(this.Handle);
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color cLeft = Color.White;
            Color cRight = Color.RoyalBlue;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(panel1.Width + 100, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void UserMan_Paint(object sender, PaintEventArgs e)
        {
            Color cLeft = Color.White;
            Color cRight = Color.RoyalBlue;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(this.Width + 100, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPasswordChange pw = new FrmPasswordChange();
            WinEffect.AnimateWindow(pw, 300, AnimateWindowStyle.AW_CENTER);
            pw.ShowDialog(false);            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
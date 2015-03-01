using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using database;
using System.Drawing.Drawing2D;

namespace NetCafe
{
    public partial class FrmReportChoose : Form
    {
        //private FrmDailyReceiptReport frmDailyReceiptReport;
        
        private FrmTimeUserReport frmTimeUserReport;
        private bool isBoss;
        public FrmReportChoose()
        {
            InitializeComponent();
            WinAPI.KillWinCaption(this.Handle);
            //frmDailyReceiptReport = new FrmDailyReceiptReport();            
            frmTimeUserReport = new FrmTimeUserReport();
        }

        public void ShowDialog(bool b)
        {
            isBoss = b;
            frmMonthlyReceiptReport1.SetIsBoss(b);
            frmTimeUserReport1.SetIsBoss(b);
            base.ShowDialog();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btMonthly_Click(object sender, EventArgs e)
        {
            /* ***************************** Edit by Leo **********************************
            * ****************************************************************************/
            String strTemp = "..\\Data\\PostData\\" + "feeMonth";
            String core = DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString();
            strTemp += core;
            strTemp += ".dat";
            //DataTransfer.createMonthFeeFile(strTemp,core1,core2);
            /* ***************************** Edit by Leo **********************************
            * ****************************************************************************/
            //frmMonthlyReceiptReport.ShowDialog();
        }

        private void btTimeUsed_Click(object sender, EventArgs e)
        {
            //frmTimeUserReport.ShowDialog();
        }

        private void FrmReportChoose_Load(object sender, EventArgs e)
        {
            WinAPI.KillWinCaption(this.Handle);

            //tpDay.Controls.Add(frm);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Color cLeft = panel2.BackColor;
            Color cRight = SystemColors.GradientActiveCaption;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(panel2.Width + 100, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, panel2.Width, panel2.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinAPI.ReleaseCapture();
                WinAPI.SendMessage(this.Handle, WinAPI.WM_NCLBUTTONDOWN, WinAPI.HT_CAPTION, 0);
            }
        }

        private void frmTimeUserReport1_OnClose(object sender)
        {
            Close();
        }

        private void frmMonthlyReceiptReport1_OnClose(object sender)
        {
            Close();
        }

        private void frmTimeUserReport1_Load(object sender, EventArgs e)
        {

        }

    }
}
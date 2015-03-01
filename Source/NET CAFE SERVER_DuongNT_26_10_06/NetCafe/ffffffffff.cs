using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCafe
{
    public partial class ffffffffff : Form
    {
         private int AlgorithmPayByHour;
         private int AlgorithmPayByMinute;
         private int AlgorithmRoundBy;
         private int AlgorithmPayMin;

        public ffffffffff()
        {
            InitializeComponent();
            WinAPI.KillWinCaption(this.Handle);
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void ffffffffff_Load(object sender, EventArgs e)
        {
            WinAPI.KillWinCaption(this.Handle);
            richTextBox1.LoadFile("fff.rtf");
        }
        private void save()
        {
            AlgorithmPayByHour= Algorithm.PayByHour;
            AlgorithmPayByMinute= Algorithm.PayByMinute;
            AlgorithmRoundBy = Algorithm.RoundBy;
            AlgorithmPayMin = Algorithm.PayMin;
        }

        private void reset()
        {
            Algorithm.PayByHour = AlgorithmPayByHour;
            Algorithm.PayByMinute = AlgorithmPayByMinute;
            Algorithm.RoundBy = AlgorithmRoundBy;
            Algorithm.PayMin = AlgorithmPayMin;
        }
        private void calculateFee()
        {
            Algorithm.PayType = 0;
            //if (radioButton2.Checked) Algorithm.PayType = 1;
            try
            {
                //if (radioButton3.Checked)
                //{
                    //Algorithm.PayByHour = Int32.Parse(textBox1.Text);
                    //Algorithm.PayByMinute = Algorithm.PayByHour / 60;
                //}
                //else
                //{
                    //Algorithm.PayByMinute = Int32.Parse(textBox2.Text);
                    //Algorithm.PayByHour = Algorithm.PayByMinute * 60;
                //}
                //Algorithm.RoundBy = Int32.Parse(textBox4.Text);
                //Algorithm.PayMin = Int32.Parse(textBox5.Text);
                //Algorithm.CalcPay();
            }
            catch (Exception ex)
            { 
            }

        }
    }
}
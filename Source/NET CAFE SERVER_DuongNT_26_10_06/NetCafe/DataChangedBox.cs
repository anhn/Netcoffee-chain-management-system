using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCafe
{
    public partial class FrmDataChangedBox : Form
    {
        private int _saleOff;
        public FrmDataChangedBox()
        {
            InitializeComponent();
            WinAPI.KillWinCaption(this.Handle);
        }
 
        public int ShowDialog(string dateFrom, string dateTo, string price)
        {
            label3.Text = "Đợt khuyến mại " + DateTime.Parse(dateFrom).ToShortDateString() + " - " + DateTime.Parse(dateTo).ToShortDateString();
            textBox1.Text = price;
            base.ShowDialog();
            return _saleOff;
        }

        private void gradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _saleOff = Int32.Parse(textBox1.Text);
            this.Close();
        }

        private bool checkValid(int para)
        {
            if (para >= 0 & para <= 100) return true;
            else return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkValid(Int32.Parse(textBox1.Text)) == false)
            {
                MessageBox.Show("Bạn phải nhập giá trị số >=0 và <=100 trong ô này !");
                textBox1.Focus();
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
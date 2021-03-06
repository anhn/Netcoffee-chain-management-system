using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using database;
//using MDB;

namespace NetCafe
{
    public partial class FrmUserChoose : Form
    {

        private FrmPasswordChange frmPasswordChange;
        private FrmAccount frmAccount;
        private bool _allRight = false;
        public FrmUserChoose()
        {
            InitializeComponent();
            frmPasswordChange = new FrmPasswordChange();
            frmAccount = new FrmAccount();
        }

        public void ShowDialog(bool allRight)
        {
            _allRight = allRight;
            base.ShowDialog();
        }



        private void FrmUserChoose_Load(object sender, EventArgs e)
        {
            //if (_allRight == true)
            //{
            //    this.button4.Visible = true;
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmPasswordChange.ShowDialog(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmAccount.ShowDialog(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPasswordChange.ShowDialog(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmAccount.ShowDialog(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_allRight == true)
            {
                this.button4.Visible = true;
            }
            else
                MessageBox.Show("Bạn không có đủ quyền để truy cập chức năng này!");
            this.button3.Visible = false;
            this.button6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button4.Visible = false;
            this.button3.Visible = true;
            this.button6.Visible = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
        
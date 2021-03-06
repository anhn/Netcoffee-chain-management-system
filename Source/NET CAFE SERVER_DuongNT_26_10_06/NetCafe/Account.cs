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
    public partial class FrmAccount : Form
    {
        /* *************** Edited by Leo ************************
         * *****************************************************/
        bool _allRight = true;
        /* *************** End Edited by Leo ********************
         * *****************************************************/
         public FrmAccount()
        {
            InitializeComponent();
            WinAPI.KillWinCaption(this.Handle);
        }
        private bool isLoading = false;
        /* *************** Edited by Leo ************************
         * *****************************************************/
        private void FrmAccount_Load(object sender, EventArgs e)
        {
            isLoading = true;
            WinAPI.KillWinCaption(this.Handle);
            UserInfo myUser = new UserInfo(1);
            myUser.loadInfo();
            this.textBox4.Text= myUser.nickname;
            this.textBox5.Text = myUser.password;
            this.textBox6.Text = myUser.fullname;
            this.textBox7.Text = myUser.address;
            this.textBox8.Text = myUser.phone;
            this.Refresh();
            isLoading = false;
        }


        /* *************** Edited by Leo ************************
         * *****************************************************/
        public void ShowDialog(bool allRight)
        {
            _allRight = allRight;
            base.ShowDialog();
        }

        
       private void button4_Click(object sender, EventArgs e)
        {
            if (this.textBox5.Text == "" || this.textBox6.Text == "" || this.textBox7.Text == "")
                MessageBox.Show("Bạn phải nhập vào các ô chữ màu đỏ !", "Huong dan");
            else
            {
                DialogResult drt = MessageBox.Show("Bạn có muốn lưu thông tin mới lại không ?", "Xác nhận lưu mật khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drt == DialogResult.Yes)
                {
                    UserInfo myUser = new UserInfo(1);
                    myUser.nickname = this.textBox4.Text;
                    myUser.password = this.textBox5.Text;
                    myUser.fullname = this.textBox6.Text;
                    myUser.address = this.textBox7.Text;
                    myUser.phone = this.textBox8.Text;
                    myUser.editInfo();
                    if (_allRight == true)
                    {
                        DataTransfer.saveSystemEvent("Sửa thông tin cá nhân", "Thành công", "Quản trị hệ thống");
                    }
                    if (_allRight == false)
                    {
                        DataTransfer.saveSystemEvent("Sửa thông tin cá nhân", "Thành công", "Người quản lý mạng");
                    }
                }
                else
                {
                    if (_allRight == true)
                        DataTransfer.saveSystemEvent("Sửa thông tin cá nhân", "Thất bại", "Quản trị hệ thống");
                    if (_allRight == false)
                        DataTransfer.saveSystemEvent("Sửa thông tin cá nhân", "Thất bại", "Người quản lý mạng");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (button4.Enabled)
            {
                DialogResult drt = MessageBox.Show("Bạn có muốn lưu thông tin mới lại không ?", "Xác nhận lưu mật khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drt == DialogResult.Yes)
                {
                    if (this.textBox5.Text == "" || this.textBox6.Text == "" || this.textBox7.Text == "")
                    {
                        MessageBox.Show("Bạn phải nhập vào các ô chữ màu đỏ !", "Huong dan");
                        return;
                    }
                    UserInfo myUser = new UserInfo(1);
                    myUser.nickname = this.textBox4.Text;
                    myUser.password = this.textBox5.Text;
                    myUser.fullname = this.textBox6.Text;
                    myUser.address = this.textBox7.Text;
                    myUser.phone = this.textBox8.Text;
                    myUser.editInfo();
                    if (_allRight == true)
                    {
                        DataTransfer.saveSystemEvent("Sửa thông tin cá nhân", "Thành công", "Quản trị hệ thống");
                    }
                    if (_allRight == false)
                    {
                        DataTransfer.saveSystemEvent("Sửa thông tin cá nhân", "Thành công", "Người quản lý mạng");
                    }
                }
            }
            this.ResetText();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // chuyen sang gradient
            Color cLeft = panel2.BackColor;
            Color cRight = SystemColors.GradientActiveCaption;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(panel2.Width + 100, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, panel2.Width, panel2.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinAPI.ReleaseCapture();
                WinAPI.SendMessage(this.Handle, WinAPI.WM_NCLBUTTONDOWN, WinAPI.HT_CAPTION, 0);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Color cLeft = panel3.BackColor;
            Color cRight = Color.White;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, panel3.Height), new Point(0, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, panel3.Width, panel3.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                button4.Enabled = true;
        }

        /* *************** End Edited by Leo *******************9288088*****
         * *****************************************************/

     }
}
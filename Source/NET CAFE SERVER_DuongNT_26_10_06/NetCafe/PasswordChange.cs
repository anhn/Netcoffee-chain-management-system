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
    public partial class FrmPasswordChange : Form
    {
        
        bool _allRight = false;
        
        public FrmPasswordChange()
        {
            InitializeComponent();
            WinAPI.KillWinCaption(this.Handle);
        }

        private void FrmPasswordChange_Load(object sender, EventArgs e)
        {
            WinAPI.KillWinCaption(this.Handle);
            if (_allRight == true)
            {
                this.pictureBox1.Visible = false;
                this.pictureBox4.Visible = true;
                this.label1.Text = "Đổi mật khẩu chủ cửa hàng";
            }
            if (_allRight == false)
            {
                this.pictureBox1.Visible = true;
                this.pictureBox4.Visible = false;
                this.label1.Text = "Đổi mật khẩu người quản lý";
            }
            this.Refresh();
        }
        
        
        private bool checkTextbox()
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                return false;
            }
            else return true;
       }

        private bool checkRewritePass()
        {
            if (textBox2.Text != textBox3.Text)
            {
                return false;
            }
            else return true;
        }

        
        public void ShowDialog(bool allRight)
        {
            _allRight = allRight;
            base.ShowDialog();
        }

        private void tbChangePasswd_Click_1(object sender, EventArgs e)
        {
            if (checkPass() != 0)
            {
                if (checkPass() == 1)
                    MessageBox.Show("Bạn phải nhập đủ hết các trường nhập!", "Nhap thieu du lieu");
                if (checkPass() == 2)
                    MessageBox.Show("Mật khẩu xác nhận phải trùng với mật khẩu định đổi. Vui lòng nhập lại!", "Nhap sai mat khau moi");
            }
            else
            {
                if (_allRight == true)
                {
                    AdminInfo admin = new AdminInfo();
                    admin.loadInfo();
                    if (admin.checkPass(this.textBox1.Text) == false)
                    {
                        MessageBox.Show("Mật khẩu không đúng !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult drt = MessageBox.Show("Bạn có muốn lưu mật khẩu mới lại không ?", "Xác nhận lưu mật khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (drt == DialogResult.Yes)
                        {
                            admin.password = this.textBox2.Text;
                            admin.saveInfo();
                            DataTransfer.saveSystemEvent("Đổi mật khẩu", "Thành công", "Quản trị hệ thống");
                        }
                        else
                        {
                            DataTransfer.saveSystemEvent("Đổi mật khẩu", "Thất bại", "Quản trị hệ thống");
                        }
                    }
                }
                if (_allRight == false)
                {
                    UserInfo myUser = new UserInfo(1);
                    myUser.loadInfo();
                    if (myUser.password != this.textBox1.Text)
                    {
                        MessageBox.Show("Mật khẩu không đúng !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult drt = MessageBox.Show("Bạn có muốn lưu mật khẩu mới lại không ?", "Xác nhận lưu mật khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (drt == DialogResult.Yes)
                        {
                            myUser.password = this.textBox2.Text;
                            //myUser.saveInfo();
                            myUser.editInfo();
                            DataTransfer.saveSystemEvent("Đổi mật khẩu", "Thành công", "Người quản lý mạng");
                        }
                        else
                        {
                            DataTransfer.saveSystemEvent("Đổi mật khẩu", "Thất bại", "Người quản lý mạng");
                        }
                    }
                }
            }
        }
        /* *************** End Edited by Leo *******************9288088*****
         * *****************************************************/

            private int checkPass()
            {
                if(this.checkTextbox() == false) return 1;
                if (this.checkRewritePass() == false) return 2;
                return 0;
            }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.ResetText();
            this.textBox1.Text = "";
            this.textBox2.Text= "";
            this.textBox3.Text= "";
            this.Close();
        }
        private void DrawGradient(Graphics g)
        {
           
        }

        private void FrmPasswordChange_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawGradient(e.Graphics);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinAPI.ReleaseCapture();
                WinAPI.SendMessage(this.Handle, WinAPI.WM_NCLBUTTONDOWN, WinAPI.HT_CAPTION, 0);
            }
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Color cLeft = panel2.BackColor;
            Color cRight = SystemColors.GradientActiveCaption;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(panel2.Width + 100, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, panel2.Width, panel2.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void FrmPasswordChange_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
                Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbChangePasswd.Enabled = true;
        }
     }
}
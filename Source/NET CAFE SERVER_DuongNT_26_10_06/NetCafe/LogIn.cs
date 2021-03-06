using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using database;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Collections;

//using MDB;

namespace NetCafe
{
    public partial class FrmLogIn : Form
    {
        private bool clicked = false;
        private int pwdInputCount;
        //private bool _anh = false;
        private bool[] info;
        public FrmLogIn()
        {
            InitializeComponent();
            info = new bool[2];
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            UserInfo user = new UserInfo(1);
            user.loadInfo();
            //WinEffect.AnimateWindowC(panel3, 2000, AnimateWindowStyle.AW_BLEND);
            
            panel3.Visible = true;
            panel4.Visible = false;
            textBox1.Text = "";
            errorProvider1.SetError(textBox1, "");
            textBox1.Focus();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
            errorProvider1.SetError(textBox2, "");
            textBox2.Text = "";
            textBox2.Focus();            
        }

        /*private void button1_MouseMove(object sender, MouseEventArgs e)
        {

            if (this.label4.Visible==true) return;
            label2.Visible = true;
        }*/

        /*private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked) return;
            label3.Text = "Quản trị";
            label3.Visible = true;
            //textBox2.Visible = true;
            //button3.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (clicked) return;
            label2.Visible = false;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (clicked) return;
            label3.Visible = false;
            textBox2.Visible = false;
            button3.Visible = false;
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            /*MDB.AdminController ac = new MDB.AdminController();
            MDB.Database.AdminInfo admin;
            ac.CreateFile();
            ac.insert(0, "anh");
            admin = ac.readObject(0);
            if(this.textBox2.Text == admin._password) _anh = true;*/
            AdminInfo admin = new AdminInfo();
            admin.loadInfo();
            info[0] = admin.checkPass(this.textBox2.Text);
            info[1] = true;
            //MessageBox.Show(admin.password);
            //MessageBox.Show(_anh);
            if (!info[0])
            {
                pwdInputCount++; // nhap sai tang so lan len                
                textBox2.SelectAll();                
                //errorProvider1.SetError(textBox2, "Sai mật khẩu chủ cửa hàng!");
                if (pwdInputCount < 3)
                    MessageBox.Show("Bạn đã nhập sai mật khẩu. Xin vui lòng nhập lại!");
                else
                    MessageBox.Show("Bạn đã nhập sai mật khẩu quá nhiều lần. Chương trình sẽ tự động thoát");
            }
            else // nhap dung
            {
                panel5.Show();
                timer1.Enabled = true;
            }

            if (pwdInputCount >= 3)
                Close();
        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            try
            {
                UserInfo user = new UserInfo(1);
                user.loadInfo();
                label7.Text = "Người quản lý";
                label4.Text = label7.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Không tìm thấy file dữ liệu! Không thể đăng nhập vào hệ thống !");
            }
        }
        public bool[] ShowDialog()
        {
            pwdInputCount = 0;
            base.ShowDialog();            
            return info;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo(1);
            user.loadInfo();
            info[0] = (user.password ==this.textBox1.Text);
            info[1] = false;
            //MessageBox.Show(user.password);
            //MessageBox.Show(_anh);
            if (!info[0])
            {
                pwdInputCount++; // nhap sai tang so lan len
                textBox1.SelectAll();
                //errorProvider1.SetError(textBox1, "Sai mật khẩu người quản lý!");
                if (pwdInputCount < 3)
                    MessageBox.Show("Bạn đã nhập sai mật khẩu. Xin vui lòng nhập lại!");
                else
                    MessageBox.Show("Bạn đã nhập sai mật khẩu quá nhiều lần. Chương trình sẽ tự động thoát");
                
            }
            else // nhap dung
            {
                panel5.Show();
                timer1.Enabled = true;
            }

            if (pwdInputCount >= 3)
                Close();            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)13)
            {
                button3_Click(null, null);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button4_Click(null, null);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Enter(object sender, EventArgs e)
        {
            //label2.Visible = true;
        }

        private void linkLabel1_DoubleClick(object sender, EventArgs e)
        {
         
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Click");
            //helpProvider1.
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DrawGradient(Graphics g)
        {
            Color cLeft = this.BackColor;
            Color cRight = SystemColors.GradientActiveCaption;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(this.Width, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            // Fill with gradient 
            g.FillRectangle(GBrush, rect);
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            DrawGradient(e.Graphics);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
            //************************
            //Modified  by NghienPC
            Process.GetCurrentProcess().Kill();
        }

        private void button1_Leave(object sender, EventArgs e)
        {
         //   label2.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            panel3.Visible = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            DrawGradient(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= 100)
            {
                timer1.Enabled = false;
                Close();
                return;
            }

            progressBar1.Value = progressBar1.Value + 10;

        }
     }
}
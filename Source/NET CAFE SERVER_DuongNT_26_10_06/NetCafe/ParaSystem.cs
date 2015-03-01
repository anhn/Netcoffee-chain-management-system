using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using database;
using Microsoft.VisualBasic;
using System.IO;
using database;

namespace NetCafe
{
    
    public partial class FrmParaSystem : Form
    {
        public FrmParaSystem()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmParaSystem_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int size =-1;
            if (radioButton5.Checked == true) size =1;
            if (radioButton5.Checked == true) size =2;
            if (radioButton5.Checked == true) size =3;
            if (radioButton5.Checked == true) size =4;

            DataTransfer.saveSystemEvent("Sửa tham số hệ thống", "Thành công", "Quản trị hệ thống");
            DataLink a = new DataLink();
            a.filePath = "..\\Configure\\" + "fontsize.dat";
            a.insertToFirst(size.ToString());
        }
        
        private void button1_Click(object sender, EventArgs e)
        {                        
            string filePath = "..\\Data\\" + "syslog" + DateTime.Today.DayOfYear.ToString() + DateTime.Today.Year.ToString() + ".dat";
            
            try
            {
                
                if (File.Exists(filePath) == true)
                {
                    File.Delete(filePath);
                    MessageBox.Show("Đã xóa dữ liệu lịch sử truy cập !");
                }
              
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa dữ liệu lịch sử truy cập !");
        }


    }
}
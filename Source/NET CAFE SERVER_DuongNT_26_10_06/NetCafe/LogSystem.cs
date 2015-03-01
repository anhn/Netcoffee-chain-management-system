using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using database;
using System.IO;
using System.Drawing.Drawing2D;
namespace NetCafe
{
    public partial class FrmLogSystem : Form
    {
        public FrmLogSystem()
        {
            InitializeComponent();
            WinAPI.KillWinCaption(this.Handle);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLogSystem_Load(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value != null)
                loadSystemEvent();
            WinAPI.KillWinCaption(this.Handle);
       }

        public void ShowDialog(bool b)
        {
            tsDelDay.Enabled = b;
            tsDelMonth.Enabled = b;
            toolStripButton4.Enabled = b;
            base.ShowDialog();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadSystemEvent();
        }

        private void loadSystemEvent()
        {
            dataGridView1.Rows.Clear();
            String strTemp = "..\\Data\\" + "syslog";
            strTemp += Convert.ToDateTime(dateTimePicker1.Value.ToString()).DayOfYear.ToString() + Convert.ToDateTime(dateTimePicker1.Value.ToString()).Year.ToString();
            strTemp += ".dat";
            if (File.Exists(strTemp) == true)
            {
                Configure.setFileSystemPath(strTemp);
                string[] strArray = SystemInfo.getAllEvents();
                //string[] strArray = SystemInfo.getAllItemsBack();
                int count;
                for (count = 0; count < strArray.Length; count++)
                {
                    this.dataGridView1.Rows.Insert(0, 1);
                    //dataGridView1.Rows[0].Cells[0].Value = strArray[count].Split('-')[0];
                    dataGridView1.Rows[0].Cells[1].Value = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[1];
                    dataGridView1.Rows[0].Cells[2].Value = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[2];
                    dataGridView1.Rows[0].Cells[3].Value = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[3];
                    dataGridView1.Rows[0].Cells[4].Value = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[4];
                }
                //dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);
                this.Refresh();
            }
            //else
            //{
            //    MessageBox.Show("Không có nhật ký ngày " + Convert.ToDateTime(dateTimePicker1.Value.ToString()).ToShortDateString(),"Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //}
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Color cLeft = panel2.BackColor;
            Color cRight = SystemColors.GradientActiveCaption;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(panel2.Width + 100, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, panel2.Width, panel2.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color cLeft = panel1.BackColor;
            Color cRight = SystemColors.InactiveCaptionText;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(panel1.Width + 100, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
        }


        private bool confirmDelete(int para)
        {
            DialogResult drt = new DialogResult();
            switch(para)
            {
                case 1:
                    drt = MessageBox.Show("Bạn thực sự muốn xóa hết nhật ký trong ngày này?", "Xac nhan xoa bao cao", MessageBoxButtons.YesNo, MessageBoxIcon.Question); break;
                case 2:
                    drt = MessageBox.Show("Bạn thực sự muốn xóa hết nhật ký trong tháng này?", "Xac nhan xoa bao cao", MessageBoxButtons.YesNo, MessageBoxIcon.Question); break;
                case 3:
                    drt = MessageBox.Show("Bạn thực sự muốn xóa hết nhật ký từ trước đến nay?", "Xac nhan xoa bao cao", MessageBoxButtons.YesNo, MessageBoxIcon.Question); break;
            };
            if(drt == DialogResult.Yes) return true;
            else return false;
            
        }

        private bool deleteDiary(int para)
        {
            String strTemp = "..\\Data\\" + "syslog";
            switch(para)
            {
                case 1:
                    {
                        strTemp += Convert.ToDateTime(dateTimePicker1.Value.ToString()).DayOfYear.ToString() + Convert.ToDateTime(dateTimePicker1.Value.ToString()).Year.ToString(); 
                        strTemp += ".dat";
                        if(File.Exists(strTemp)==true)
                        {
                            File.Delete(strTemp);
                        }
                        DataTransfer.saveSystemEvent("Xóa nhật ký ngày", "Ngày " + dateTimePicker1.Value.ToString(), "Chủ quán");
                        break;
                    }
                case 2:
                    {
                        string month = Convert.ToDateTime(dateTimePicker1.Value.ToString()).Month.ToString();
                        string year = Convert.ToDateTime(dateTimePicker1.Value.ToString()).Year.ToString();
                        DateTime result;
                        for(int day=1; day<32; day++)
                        {
                            string date = month + Configure.SPLIT_ITEM_IN_RECORD + day.ToString() + Configure.SPLIT_ITEM_IN_RECORD + year;
                            if(DateTime.TryParse(date,out result)==true)
                            {
                                strTemp = "..\\Data\\" + "syslog";
                                strTemp += Convert.ToDateTime(date).DayOfYear.ToString() + year;
                                strTemp += ".dat";
                                if(File.Exists(strTemp)==true)
                                {
                                    File.Delete(strTemp);
                                }
                            }
                        }
                        DataTransfer.saveSystemEvent("Xóa nhật ký tháng", "Tháng " + month, "Chủ quán");
                        break;
                    }
                case 3:
                    {
                        DataTransfer.DelFiles("syslog", "..\\Data");
                        DataTransfer.saveSystemEvent("Xóa toàn bộ nhật ký ", "Thành công", "Chủ quán");
                        break; 
                    }
            };
            dataGridView1.Rows.Clear();
            return true;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (confirmDelete(1) == true)
                deleteDiary(1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            //if (MessageBox.Show("Bạn có thực sự muốn xóa?", "Canh bao", MessageBoxButtons.YesNo))
            {
                if (confirmDelete(2) == true)
                    deleteDiary(2);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (confirmDelete(3) == true)
                deleteDiary(3);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
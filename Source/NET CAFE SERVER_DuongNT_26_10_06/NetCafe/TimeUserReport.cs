using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using database;
using System.IO;
namespace NetCafe
{
    public delegate void OnMyFormClose(object sender);
    public partial class FrmTimeUserReport : UserControl
    {

        //private string[] strDataForGrid1 = { "SERVER", "16:19:16", "16:49:16", "30" };
        public FrmTimeUserReport()
        {
            InitializeComponent();
            //WinAPI.KillWinCaption(this.Handle);
        }

        public event OnMyFormClose OnClose;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void  SetIsBoss(bool b)
        {

            mo.Enabled = b;
            
        }
        private void loadReport()
        {
            this.dgvTime.Nodes.Clear();
            String strTemp;
            ///bool ct = (dateTimePicker1.Value.ToShortDateString() == DateTime.Today.Date.ToShortDateString());
            ///if (ct == true)
            ///{
                strTemp = "..\\Data\\" + "feelog";
                strTemp += Convert.ToDateTime(dateTimePicker1.Value.ToString()).DayOfYear.ToString() + Convert.ToDateTime(dateTimePicker1.Value.ToString()).Year.ToString();
                strTemp += ".dat";
                if (File.Exists(strTemp) == true)
                {
                    Configure.setFileFeePath(strTemp);
                    strTemp = "..\\Data\\PostData\\" + "postfee";
                    strTemp += Convert.ToDateTime(dateTimePicker1.Value.ToString()).DayOfYear.ToString() + Convert.ToDateTime(dateTimePicker1.Value.ToString()).Year.ToString();
                    strTemp += ".dat";
                    Configure.setPostFeeData(strTemp);
                    FeeInfo.filterData();
                    DataTransfer.fileName = strTemp;
                    DataTransfer.getLength();
                    string[] strArray = DataTransfer.getAllItems();
                    int count;
                    String strName = "";

                    for (count = 0; count < strArray.Length; count++)
                    {
                        if (strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[2] == " ")
                        {
                            AdvancedDataGridView.TreeGridNode node = dgvTime.Nodes.Add(strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[1], "", strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[4], strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[5]);
                            node.ImageIndex = 0;
                        }
                        else
                        {
                            String strStartTime = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[2];
                            String strTotalTime = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[4];
                            String strTotalFee = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[5];
                            if (dgvTime.Nodes.Count > 0)
                            {
                                AdvancedDataGridView.TreeGridNode node = dgvTime.Nodes[dgvTime.Nodes.Count - 1].Nodes.Add("", strStartTime, strTotalTime, strTotalFee);
                                node.ImageIndex = 1;
                            }
                        }
                    }
                    this.Refresh();
                }
                //else
                    //MessageBox.Show("Chưa có máy nào được tính tiền trong ngày !");

            ///}
            /*else
            {
                strTemp = "..\\Data\\PostData\\" + "postfee";
                strTemp += Convert.ToDateTime(dateTimePicker1.Value.ToString()).DayOfYear.ToString() + Convert.ToDateTime(dateTimePicker1.Value.ToString()).Year.ToString();
                strTemp += ".dat";
                if (File.Exists(strTemp) == true)
                {
                    DataTransfer.fileName = strTemp;
                    DataTransfer.getLength();
                    string[] strArray = DataTransfer.getAllItems();
                    int count;
                    //String strName = "";

                    for (count = 0; count < strArray.Length; count++)
                    {
                        if (strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[2] == " ")
                        {
                            AdvancedDataGridView.TreeGridNode node = dgvTime.Nodes.Add(strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[1], "", strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[4], strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[5]);
                            node.ImageIndex = 0;
                        }
                        else
                        {
                            String strStartTime = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[2];
                            String strTotalTime = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[4];
                            String strTotalFee = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[5];
                            AdvancedDataGridView.TreeGridNode node = dgvTime.Nodes[dgvTime.Nodes.Count - 1].Nodes.Add("", strStartTime, strTotalTime, strTotalFee);
                            node.ImageIndex = 1;
                        }
                    }
                    this.Refresh();
                }
                else
                {
                    //MessageBox.Show("Không có báo cáo ngày " + this.dateTimePicker1.Value.Date.ToString() + " !");
                }

            }*/

            //else
            //{
            //    MessageBox.Show("Không có báo cáo ngày " + this.dateTimePicker1.Value.Date.ToString() + " !");

            //}
        }

        private void FrmTimeUserReport_Load(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value != null)
                loadReport();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            loadReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OnClose(this);
            /*
            try
            {
                ((Form)Parent).Close();
            }
            catch (Exception) { }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String strTemp1 = "..\\Data\\PostData\\" + "postfee";
            strTemp1 += Convert.ToDateTime(dateTimePicker1.Value.ToString()).DayOfYear.ToString() + Convert.ToDateTime(dateTimePicker1.Value.ToString()).Year.ToString();
            strTemp1 += ".dat";
            String strTemp2 = "..\\Data\\" + "feelog";
            strTemp2 += Convert.ToDateTime(dateTimePicker1.Value.ToString()).DayOfYear.ToString() + Convert.ToDateTime(dateTimePicker1.Value.ToString()).Year.ToString();
            strTemp2 += ".dat";
            if (confirmDelete())
            {
                if (File.Exists(strTemp1) == true)
                    File.Delete(strTemp1);
                if (File.Exists(strTemp2) == true)
                {
                    File.Delete(strTemp2);
                    DataTransfer.saveSystemEvent("Xóa báo cáo ngày", "Ngày " + dateTimePicker1.Value.ToString() , "Chủ quán");
                    dgvTime.Nodes.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dgvTime.Nodes.Clear();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinAPI.ReleaseCapture();
                WinAPI.SendMessage(this.Handle, WinAPI.WM_NCLBUTTONDOWN, WinAPI.HT_CAPTION, 0);
            }
        }


        private bool confirmDelete()
        {
            DialogResult drt = new DialogResult();
            drt = MessageBox.Show("Bạn thực sự muốn xóa báo cáo doanh thu này ?", "Xac nhan xoa bao cao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drt == DialogResult.Yes) return true;
            else return false;
        }

        private void dgvTime_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(dgvTime.Nodes.Count==0)
                    this.dgvTime.Nodes.Add("", "", "", "");
                //this.dgvTime.cu = this.dgvTime.Nodes[0];
            }
            catch (Exception ex)
            { 
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            loadReport();
        }

    }
}
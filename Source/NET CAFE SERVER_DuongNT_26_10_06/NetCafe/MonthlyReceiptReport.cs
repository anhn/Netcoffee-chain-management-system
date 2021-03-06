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
    public delegate void OnFormClose(object sender);
    public partial class FrmMonthlyReceiptReport :UserControl
    {
        //private bool flag = false;
        public FrmMonthlyReceiptReport()
        {
            InitializeComponent();
            //WinAPI.KillWinCaption(this.Handle);
        }

        private void btClose_Click(object sender, EventArgs e)
        {

        }
        public event OnFormClose OnClose;
        private void FrmMonthlyReceiptReport_Load(object sender, EventArgs e)
        {
            String core1 = "";
            core1 = monthList.SelectedItem.ToString();
            String core2 = "";
            core2 = yearList.SelectedItem.ToString();
            loadSystemEvent(core1, core2);
            //loadSystemEvent(core1, core2);
        }
        public void SetIsBoss(bool b)
        {

            tsDelete.Enabled = b;

        }
        private void loadSystemEvent(String core1, String core2)
        {
            dgvMonth.Nodes.Clear();
            int total = 0;
            String strTemp = "..\\Data\\PostData\\" + "feeMonth";
            String core = "";
            core = core1 + core2;
            strTemp += core;
            strTemp += ".dat";
            if (File.Exists(strTemp) == true)
            {
                DataTransfer.fileName = strTemp;
                DataTransfer.getLength();
                string[] strArray = DataTransfer.getAllItems();
                int count;

                for (count = 0; count < strArray.Length; count++)
                {
                    if (strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[0] == " ")
                    {
                        AdvancedDataGridView.TreeGridNode node = dgvMonth.Nodes.Add(strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[1], strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[4], strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[5]);
                        node.ImageIndex = 0;
                        total += Convert.ToInt32(strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[5]);
                    }
                    else
                    {
                        String strStartTime = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[0];
                        String strTotalTime = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[4];
                        String strTotalFee = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[5];
                        AdvancedDataGridView.TreeGridNode node = dgvMonth.Nodes[dgvMonth.Nodes.Count - 1].Nodes.Add(strStartTime, strTotalTime, strTotalFee);
                        node.ImageIndex = 1;
                    }
                }
                this.labTotalMoney.Text = total.ToString() + " đồng ";

            }
            //else
            //{
                //MessageBox.Show("Không có báo cáo tháng này !");
            //}

        }

        private void monthList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String core1 = "";
            core1 = monthList.SelectedItem.ToString();
            String core2 = "";
            core2 = yearList.SelectedItem.ToString();
            if (core1 == DateTime.Today.Month.ToString() & core2 == DateTime.Today.Year.ToString())
                createMonthReport(core1, core2);
            loadSystemEvent(core1, core2);
        }

        private void yearList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String core1 = "";
            core1 = monthList.SelectedItem.ToString();
            String core2 = "";
            core2 = yearList.SelectedItem.ToString();
            loadSystemEvent(core1, core2);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String core1 = "";
            core1 = monthList.SelectedItem.ToString();
            String core2 = "";
            core2 = yearList.SelectedItem.ToString();
            String strTemp = "..\\Data\\PostData\\" + "feeMonth";
            String core = "";
            core = core1 + core2;
            strTemp += core;
            strTemp += ".dat";
            DataTransfer.createMonthFeeFile(strTemp,core1,core2);

            loadSystemEvent(monthList.Text, yearList.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvMonth.Nodes.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String core1 = "";
            core1 = monthList.SelectedItem.ToString();
            String core2 = "";
            core2 = yearList.SelectedItem.ToString();
            String strTemp = "..\\Data\\PostData\\" + "feeMonth";
            String core = "";
            core = core1 + core2;
            strTemp += core;
            strTemp += ".dat";
            DialogResult drt = MessageBox.Show("Bạn thực sự muốn xóa báo cáo tháng này ?", "Xác nhận xóa báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drt == DialogResult.Yes)
            {
                if (File.Exists(strTemp) == true)
                {
                    File.Delete(strTemp);
                    MessageBox.Show("Đã xóa thành công !");
                    dgvMonth.Nodes.Clear();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OnClose(this);
           /*
            try
            {
                ((Form)Parent.Parent.Parent).Close();
            } catch (Exception){}*/
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinAPI.ReleaseCapture();
                WinAPI.SendMessage(this.Handle, WinAPI.WM_NCLBUTTONDOWN, WinAPI.HT_CAPTION, 0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ((Form)Parent).Close();
            }
            catch (Exception) { }
        }


        private void tsDelete_Click(object sender, EventArgs e)
        {
            if (confirmDelete() == true)
            {
                deleteMonth();
                dgvMonth.Nodes.Clear();
            }
        }

        private bool confirmDelete()
        {
            DialogResult drt = new DialogResult();
            drt = MessageBox.Show("Bạn thực sự muốn xóa hết báo cáo tháng doanh thu này?", "Xac nhan xoa bao cao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drt == DialogResult.Yes) return true;
            else return false;
        }

        private bool deleteMonth()
        {
            String core1 = "";
            core1 = monthList.SelectedItem.ToString();
            String core2 = "";
            core2 = yearList.SelectedItem.ToString();
            String strTemp = "..\\Data\\PostData\\" + "feeMonth";
            String core = "";
            core = core1 + core2;
            strTemp += core;
            strTemp += ".dat";
            if (File.Exists(strTemp) == true)
            {
                File.Delete(strTemp);
                DateTime result;
                for (int day = 1; day < 32; day++)
                {
                    string date = core1 + Configure.SPLIT_ITEM_IN_RECORD + day.ToString() + Configure.SPLIT_ITEM_IN_RECORD + core2;
                    if (DateTime.TryParse(date, out result) == true)
                    {
                        strTemp = "...\\Data\\PostData\\" + "postfee";
                        strTemp += Convert.ToDateTime(date).DayOfYear.ToString() + core2;
                        strTemp += ".dat";
                        if (File.Exists(strTemp) == true)
                        {
                            File.Delete(strTemp);
                        }
                    }
                }
            }
            DataTransfer.saveSystemEvent("Xóa báo cáo tháng", "Tháng " + core1.ToString() + " năm " + core2.ToString(), "Chủ quán");
            return true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OnClose(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            String core1 = "";
            core1 = monthList.SelectedItem.ToString();
            String core2 = "";
            core2 = yearList.SelectedItem.ToString();
            createMonthReport(core1, core2);
            loadSystemEvent(monthList.Text, yearList.Text);
        }

        private void createMonthReport(string core1, string core2)
        {
            String strTemp = "..\\Data\\PostData\\" + "feeMonth";
            String core = "";
            core = core1 + core2;
            strTemp += core;
            strTemp += ".dat";
            DataTransfer.createMonthFeeFile(strTemp, core1, core2);
        }

        private void dgvMonth_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (dgvMonth.Nodes.Count == 0)
                        this.dgvMonth.Nodes.Add("", "", "");
                    //this.dgvTime.cu = this.dgvTime.Nodes[0];
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }

        }
        
    }
  
 
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using database;

namespace NetCafe
{
    public partial class FrmDailyReceiptReport : Form
    {
        public FrmDailyReceiptReport()
        {
            InitializeComponent();
            
        }

        private void FrmDailyReceiptReport_Load(object sender, EventArgs e)
        {
            string strTemp = "";
            strTemp = DateTime.Today.DayOfYear.ToString() + DateTime.Today.Year.ToString();
            //strTemp += ".txt";
            labDate.Text = DateTime.Today.Date.ToString();
            DataTransfer.fileName = "..\\Data\\" + "rptFeeReceipt" + strTemp + ".txt";
            DataTransfer.getLength();
            string[] strArray = DataTransfer.getAllItems();
            int count;
            for (count = 0; count < strArray.Length; count++)
            {
                this.dataGridView1.Rows.Insert(0, 1);
                //dataGridView1.Rows[0].Cells[0].Value = strArray[count].Split('-')[0];
                dataGridView1.Rows[0].Cells[0].Value = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[0];
                dataGridView1.Rows[0].Cells[1].Value = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[1];
                dataGridView1.Rows[0].Cells[2].Value = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[2];
                dataGridView1.Rows[0].Cells[3].Value = strArray[count].Split(Configure.SPLIT_ITEM_IN_RECORD)[3];
            }
            this.Refresh();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        /*
        public void Show()
        {
            
            Form.Show();
        }*/

    }
}
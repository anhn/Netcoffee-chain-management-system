using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace NetCafe
{
    public partial class FrmPriceWizard : Form
    {
        public FrmPriceWizard()
        {
            InitializeComponent();
            WinAPI.KillWinCaption(this.Handle);
            dgvPrice.RowCount = 24;
        }
        private bool isLoading;
        private void FrmPriceWizard_Load(object sender, EventArgs e)
        {
            
            isLoading = true;
            WinAPI.KillWinCaption(this.Handle);
            this.Height = 440;
            for (int i = 0; i < 24; i++)
            {
                dgvPrice.Rows[i].HeaderCell.Value = i.ToString() + ":00";                            
            }
            try
            {
                Algorithm.ReadInput();
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu bảng giá bị lỗi");
                //throw new Exception();
            }
            try
            {
                textBox1.Text = Algorithm.PayByHour.ToString();
                textBox2.Text = Algorithm.PayByMinute.ToString();
                //domainUpDown1.Text = Algorithm.Vat.ToString();
                textBox4.Text = Algorithm.RoundBy.ToString();
                textBox5.Text = Algorithm.PayMin.ToString();
            }
            catch (Exception) { }
            for (int i = 0; i < 24; ++i)
                for (int j = 0; j < 7; ++j)
                {
                    dgvPrice.Rows[i].Cells[j].Value = Algorithm.WeekPrice[i, j].ToString();
                    
                    int t = (int)((Algorithm.WeekPrice[i, j] - 1000) / 500);
                    if ((Algorithm.WeekPrice[i, j] - 1000) % 500 == 0) 
                    {
                    if (t >=0 && t < 9)                    
                        dgvPrice.Rows[i].Cells[j].Style.BackColor = arColors[t];
                    else  
                        dgvPrice.Rows[i].Cells[j].Style.BackColor = arColors[9]; 
                    }
                    
                }
            dataGridView1.Rows.Clear();
            try
            {
                for (int i = 0; i < Algorithm.Offs.Length; ++i)
                {
                    dataGridView1.Rows.Insert(i, 1);
                    dataGridView1.Rows[i].Cells[0].Value = Algorithm.Offs[i].begin;
                    dataGridView1.Rows[i].Cells[1].Value = Algorithm.Offs[i].end;
                    dataGridView1.Rows[i].Cells[2].Value = Algorithm.Offs[i].off.ToString();
                }
            }
            catch (Exception) { }
            //this.tabControl1.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            if (Algorithm.PayType == 0)
            {
                radioButton1.Checked = true;
                panel1.Visible = true;
            }
            else
            {
                radioButton2.Checked = true;
                panel2.Visible = true;
                //panel2.Left = 2;
                //panel2.Top = 50;
            }
            btOtherInform.Enabled = false;
            comboBox1.SelectedIndex = 4;
            comboBox2.SelectedIndex = 4;
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            ChangeHelp();
            isLoading = false;
        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btClose_Click_1(object sender, EventArgs e)
        {
            if (btOtherInform.Enabled)
                btOtherInform_Click(null, null);
            Close();
        }

        private void dgvPrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool saveInfo()
        {
            if (radioButton1.Checked) Algorithm.PayType = 0;
            if (radioButton2.Checked) Algorithm.PayType = 1;
            try
            {
                if (radioButton3.Checked)
                {
                    Algorithm.PayByHour = Int32.Parse(textBox1.Text);
                    Algorithm.PayByMinute = Algorithm.PayByHour/60;
                    //textBox2.Text = Algorithm.PayByMinute.ToString();
                }
                else
                {
                    Algorithm.PayByMinute = Int32.Parse(textBox2.Text);
                    Algorithm.PayByHour = Algorithm.PayByMinute*60;
                    //textBox1.Text = Algorithm.PayByHour.ToString();
                }
                //Algorithm.Vat = Int32.Parse(domainUpDown1.Text);
                Algorithm.RoundBy = Int32.Parse(textBox4.Text);
                Algorithm.PayMin = Int32.Parse(textBox5.Text);
            }
            catch (Exception e)
            {
                return false;
            }
            for (int i = 0; i < 24; ++i)
                for (int j = 0; j < 7; ++j)
                {
                    try
                    {
                        Algorithm.WeekPrice[i, j] = Int32.Parse(dgvPrice.Rows[i].Cells[j].Value.ToString());
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            try
            {
                Algorithm.Offs = new SaleOff[dataGridView1.Rows.Count];
            }
            catch (Exception) { }
            for (int i = 0; i < Algorithm.Offs.Length; ++i)
            {
                try
                {
                    Algorithm.Offs[i].begin = DateTime.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    Algorithm.Offs[i].end = DateTime.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    Algorithm.Offs[i].off = Int32.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    if (DateTime.Compare(Algorithm.Offs[i].begin, Algorithm.Offs[i].end) > 0)
                    {
                        ///dataGridView1.
                        return false;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            Algorithm.SaveInput();
            return true;
        }

        private void btOtherInform_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Bạn có muốn lưu thông tin mới lại không ?", "Xác nhận lưu thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                if (saveInfo())
                {
                    btOtherInform.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Dữ liệu nhập vào không đúng!");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Algorithm.PayType = 0;
            panel1.Visible = true;
            panel1.BringToFront();
            panel2.Visible = false;
            btOtherInform.Enabled = true;
            ChangeHelp1();
            
        }
        private void ChangeHelp1()
        {
            lbHelpCap.Text = "Thiết lập đơn giá";
            if (radioButton2.Checked)
                lbHelpCont.Text = lbGiatuan.Text;
            else
                lbHelpCont.Text = lbDongia.Text;
        }
        private void ChangeHelp2()
        {
            lbHelpCap.Text = "Thiết lập khuyến mại";            
            lbHelpCont.Text = lbBonus.Text;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            //panel2.Left = 2;
            //panel2.Top = 50;
            panel2.BringToFront();
            panel1.Visible = false;
            btOtherInform.Enabled = true;
            ChangeHelp1();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            try
            {
                int c = Int32.Parse(textBox1.Text);
                if (!ok(c))
                {
                    MessageBox.Show("Số tiền nhập vào không thể sử dụng để thanh toán!");
                    textBox1.Text = Algorithm.PayByHour.ToString();
                    textBox1.Focus();
                }
                else
                {
                    if (c >= 15000)
                        if (MessageBox.Show("Số quá lớn, đồng ý nhập?", "Xác nhận lưu thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            btOtherInform.Enabled = true;
                            textBox2.Text = ((int)Int32.Parse(textBox1.Text) / 60).ToString();
                        }
                        else
                        {
                            textBox1.Text = Algorithm.PayByHour.ToString();
                            textBox1.Focus();
                        }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                textBox1.Text = Algorithm.PayByHour.ToString();
                textBox1.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            try
            {
                int c = Int32.Parse(textBox2.Text);
                if (!ok(c*60))
                {
                    MessageBox.Show("Số tiền nhập vào không đúng!");
                    textBox2.Text = Algorithm.PayByMinute.ToString();
                    textBox2.Focus();
                }
                else
                {
                    if (c >= (15000/60))
                        if (MessageBox.Show("Số quá lớn, đồng ý nhập?", "Xác nhận lưu thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            btOtherInform.Enabled = true;
                            textBox1.Text = ((int)Int32.Parse(textBox2.Text) * 60).ToString();
                        }
                        else
                        {
                            textBox2.Text = Algorithm.PayByMinute.ToString();
                            textBox2.Focus();
                        }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                textBox2.Text = Algorithm.PayByMinute.ToString();
                textBox2.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            try
            {
                int c = Int32.Parse(textBox4.Text);
                if (!ok(c))
                {
                    MessageBox.Show("Dữ liệu nhập vào không đúng!");
                    textBox4.Text = Algorithm.RoundBy.ToString();
                    textBox4.Focus();
                }
                else
                {
                    if (c >= (10000))
                        if (MessageBox.Show("Số quá lớn, đồng ý nhập?", "Xác nhận lưu thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            btOtherInform.Enabled = true;
                        }
                        else
                        {
                            textBox4.Text = Algorithm.RoundBy.ToString();
                            textBox4.Focus();
                        }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                textBox4.Text = Algorithm.RoundBy.ToString();
                textBox4.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            try
            {
                int c = Int32.Parse(textBox5.Text);
                if (!ok(c))
                {
                    MessageBox.Show("Số tiền nhập vào không thể sử dụng để thanh toán!");
                    textBox5.Text = Algorithm.PayMin.ToString();
                    textBox5.Focus();
                }
                else
                {
                    if (c >= (10000))
                        if (MessageBox.Show("Số quá lớn, đồng ý nhập?", "Xác nhận lưu thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            btOtherInform.Enabled = true;
                        }
                        else
                        {
                            textBox5.Text = Algorithm.PayMin.ToString();
                            textBox5.Focus();
                        }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                textBox5.Text = Algorithm.PayMin.ToString();
                textBox5.Focus();
            }
        }

        private void dgvPrice_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoading) return;
            string s;
            if (e.ColumnIndex < 0) return;
            if (e.RowIndex < 0) return;
            try
            {
                s = (String)dgvPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (s.CompareTo("") == 0) return;
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                int c = Int32.Parse(s);
                if (!ok(c))
                {
                    MessageBox.Show("Số tiền nhập vào không thể sử dụng để thanh toán!");
                    dgvPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Algorithm.WeekPrice[e.RowIndex,e.ColumnIndex].ToString();
                }
                else
                {
                    try
                    {
                        int iRow = e.RowIndex;
                        int iCol = e.ColumnIndex;
                        if (c >= (10000))                            
                            if (MessageBox.Show("Số quá lớn, đồng ý nhập?", "Xác nhận lưu thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)                        
                            {
                                dgvPrice.Rows[iRow].Cells[iCol].Style.BackColor = arColors[(c - 1000) / 500];                                  
                            }
                            else
                            {
                                // khoi phuc lai gia tri cu
                                dgvPrice.Rows[iRow].Cells[iCol].Value = Algorithm.WeekPrice[iRow, iCol].ToString();
                            }
                        
                        
                    }
                    catch (Exception) { dgvPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = arColors[9]; }
                    btOtherInform.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                dgvPrice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Algorithm.WeekPrice[e.RowIndex, e.ColumnIndex].ToString();
            }
        }

        private void FrmPriceWizard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoading) return;
            if (e.ColumnIndex < 0) return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 2)
            {
                try
                {
                    string s = ((string)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (s == "") return;
                    int c = Int32.Parse(s);
                    if ((c <= 0))
                    {
                        MessageBox.Show("Dữ liệu nhập vào không đúng!");
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Algorithm.Offs[e.RowIndex].off.ToString();
                    }
                    else
                    {
                        btOtherInform.Enabled = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Dữ liệu nhập vào không đúng!");
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Algorithm.Offs[e.RowIndex].off.ToString();
                }
            }
            else
            {
                try
                {
                    DateTime d1 = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                    DateTime d2 = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                    if (DateTime.Compare(d1, d2) > 0)
                    {
                        MessageBox.Show("Dữ liệu nhập vào không đúng!");
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridView1.Rows[e.RowIndex].Cells[1-e.ColumnIndex].Value;
                    }
                    else
                    {
                        btOtherInform.Enabled = true;
                    }
                }
                catch(Exception)
                {
                    return;
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Color cLeft = panel3.BackColor;
            Color cRight = SystemColors.GradientActiveCaption;
            LinearGradientBrush GBrush = new LinearGradientBrush(new Point(0, 0), new Point(panel3.Width + 100, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, panel3.Width, panel3.Height);
            // Fill with gradient 
            e.Graphics.FillRectangle(GBrush, rect);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinAPI.ReleaseCapture();
                WinAPI.SendMessage(this.Handle, WinAPI.WM_NCLBUTTONDOWN, WinAPI.HT_CAPTION, 0);
            }
        }
        private void ChangeHelp()
        {
            if (tabControl1.SelectedIndex == 0)
                ChangeHelp1();
            else
                ChangeHelp2();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeHelp();
        }
        private Color[] arColors = {Color.LightBlue, Color.LightPink, Color.Salmon, Color.LightGreen, Color.LightYellow, Color.DodgerBlue, Color.LightCyan, Color.Gold, Color.LightGray, Color.White};
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!checkCb()) return;
            for (int i = 0; i < dgvPrice.SelectedCells.Count; i++)
            {
                int x = dgvPrice.SelectedCells[i].RowIndex;
                int y = dgvPrice.SelectedCells[i].ColumnIndex;
                dgvPrice.Rows[x].Cells[y].Value = Int32.Parse(comboBox1.Text);
                try
                {
                    dgvPrice.Rows[x].Cells[y].Style.BackColor = arColors[comboBox1.SelectedIndex];
                }
                catch (Exception) { dgvPrice.Rows[x].Cells[y].Style.BackColor = arColors[9]; }
            }
            btOtherInform.Enabled = true;
        }
        private bool checkCb()
        {
            bool ret = true;
            try
            {
                string s = (comboBox1.Text);
                if (s == "") return false;
                int c = Int32.Parse(s);
                if ((c <= 0))
                {
                    MessageBox.Show("Giá áp đặt phải lớn hơn 0!");
                    comboBox1.Text = "";
                    ret = false;
                }
                else
                {
                    //btOtherInform.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                comboBox1.Text = "";
                ret = false;
            }
            finally
            {
                comboBox1.Focus();
            }
            return ret;
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            try
            {
                string s = (comboBox1.Text);
                if (s == "") return;
                int c = Int32.Parse(s);
                if ((c <= 0))
                {
                    MessageBox.Show("Giá áp đặt phải lớn hơn 0!");
                    comboBox1.Text = "";
                }
                else
                {
                    //btOtherInform.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                comboBox1.Text = "";
            }
            finally
            {
                comboBox1.Focus();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            //textBox1.Text = ((int)Int32.Parse(textBox2.Text) * 60).ToString();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            //textBox2.Text = ((int)Int32.Parse(textBox1.Text) / 60).ToString();
        }

        private bool ok(int n)
        {
            if ((n >= 0) && (n % 100 == 0)) return true;
            else return false;
        }

        private void textBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            try
            {
                int c = Int32.Parse(textBox1.Text);
                if (c<0)
                {
                    MessageBox.Show("Đơn giá theo giờ phải lớn hơn 0!");
                    textBox1.Text = Algorithm.PayByHour.ToString();
                    textBox1.Focus();
                }
                else
                {
                    btOtherInform.Enabled = true;
                    textBox2.Text = ((int)Int32.Parse(textBox1.Text) / 60).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                textBox1.Text = Algorithm.PayByHour.ToString();
                textBox1.Focus();
            }
        }

        private void textBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            try
            {
                int c = Int32.Parse(textBox2.Text);
                if (c<0)
                {
                    MessageBox.Show("Đơn giá theo phút phải lớn hơn 0!");
                    textBox2.Text = Algorithm.PayByMinute.ToString();
                    textBox2.Focus();
                }
                else
                {
                    btOtherInform.Enabled = true;
                    textBox1.Text = ((int)Int32.Parse(textBox2.Text) * 60).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                textBox2.Text = Algorithm.PayByMinute.ToString();
                textBox2.Focus();
            }
        }

        private void textBox4_SelectedValueChanged(object sender, EventArgs e)
        {

            if (isLoading) return;
            try
            {
                int c = Int32.Parse(textBox4.Text);
                if (c<0)
                {
                    MessageBox.Show("Số tiền làm tròn phải lớn hơn 0!");
                    textBox4.Text = Algorithm.RoundBy.ToString();
                    textBox4.Focus();
                }
                else
                {
                    btOtherInform.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                textBox4.Text = Algorithm.RoundBy.ToString();
                textBox4.Focus();
            }
        }

        private void textBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            try
            {
                int c = Int32.Parse(textBox5.Text);
                if (c<0)
                {
                    MessageBox.Show("Số tiền tối thiểu phải lớn hơn 0!");
                    textBox5.Text = Algorithm.PayMin.ToString();
                    textBox5.Focus();
                }
                else
                {
                    btOtherInform.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                textBox5.Text = Algorithm.PayMin.ToString();
                textBox5.Focus();
            }
        }

        private bool cut(DateTime x1, DateTime x2, DateTime y1, DateTime y2)
        {
            if ((DateTime.Compare(y1.Date, x2.Date) <= 0) && (DateTime.Compare(x1.Date, y2.Date) <= 0)) return true;
            else return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isLoading) return;
            try
            {
                dataGridView1.ClearSelection();
                DateTime d1 = (DateTime)dateTimePicker1.Value;
                DateTime d2 = (DateTime)dateTimePicker2.Value;
                int off = Int32.Parse(comboBox2.Text);
                if ((DateTime.Compare(d1, d2.AddDays(1)) > 0))
                {
                    MessageBox.Show("Ngày bắt đầu khuyến mại phải nhỏ hơn ngày kết thúc!");
                    return;
                }
                else if((off < 0) || (off > 100))
                {
                    MessageBox.Show("Số phần trăm giảm giá phải nằm trong khoảng 0% đến 100%!");
                    return;
                }
                else
                {
                    for (int i = 0; i < dataGridView1.RowCount; ++i)
                    {
                        if (cut((DateTime)dataGridView1.Rows[i].Cells[0].Value, (DateTime)dataGridView1.Rows[i].Cells[1].Value, d1, d2))
                        {
                            MessageBox.Show("Đã có khuyến mại trong khoảng thời gian này");
                            dataGridView1.Rows[i].Selected = true;
                            return;
                        }
                    }
                    if (dataGridView1.RowCount == 0)
                        dataGridView1.Rows.Add(d1, d2, off.ToString());
                    else
                        dataGridView1.Rows.Insert(0, d1, d2, off.ToString());
                    btOtherInform.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                return;
            }
        }

        private void btKillApp_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridView1.SelectedCells.Count; ++i)
            //{
                //MessageBox.Show(i.ToString());
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
                btOtherInform.Enabled = true;
            //}
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (isLoading) return;
            try
            {
                string s = (comboBox1.Text);
                if (s == "") return;
                int c = Int32.Parse(s);
                if (!ok(c))
                {
                    MessageBox.Show("Dữ liệu nhập vào không đúng!");
                    comboBox1.Text = "";
                }
                else
                {
                    if (c >= 15000)
                        if (MessageBox.Show("Số quá lớn, đồng ý nhập?", "Xác nhận lưu thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            comboBox1.Text = "";
                        }
                    //btOtherInform.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                comboBox1.Text = "";
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            try{
                int off = Int32.Parse(comboBox2.Text);
                if ((off < 0) || (off > 100))
                {
                    MessageBox.Show("Dữ liệu nhập vào không đúng!");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng!");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PriceTutorial priceTur = new PriceTutorial();
            WinEffect.AnimateWindow(priceTur, 300, AnimateWindowStyle.AW_CENTER);  
            priceTur.ShowDialog(this);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PriceTutorial priceTur = new PriceTutorial();
            WinEffect.AnimateWindow(priceTur, 300, AnimateWindowStyle.AW_CENTER);
            priceTur.ShowDialog(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PriceTutorial priceTur = new PriceTutorial();
            WinEffect.AnimateWindow(priceTur, 300, AnimateWindowStyle.AW_CENTER);
            priceTur.ShowDialog(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Ban phai chi ra doi khuyen mai can thay doi trong bang duoi day");
                return;
            }
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Ban chi duoc thay doi du lieu cua 1 dot khuyen mai");
                return;
            }
            if (dataGridView1.SelectedRows.Count == 1)
            {
                FrmDataChangedBox dcb = new FrmDataChangedBox();
                int tempPrice = dcb.ShowDialog(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                dataGridView1.SelectedRows[0].Cells[2].Value = tempPrice.ToString();
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            changeStatus(checkBox1.Checked);
        }

        private void changeStatus(bool isEnable)
        {
            if (isEnable)
            {
                comboBox1.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                button1.Enabled = false;
            }
        }

    }
}
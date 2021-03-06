using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using database;
using System.IO;

namespace NetCafe
{
    
    public partial class FrmMain : Form
    {        
        private bool[] continueMain;
        private bool allRight;
        private int sizeFont;
        private bool isInitialized = false;
        private FrmReportChoose frmReport;
        private FrmHelpForm frmHelp;
        private FrmLogSystem frmLog;
        private FrmParaSystem frmParamSystem;
        private FrmPriceWizard frmPriceManage;
        //private FrmUserChoose frmUserChoose;
        private FrmFlash frmFlash;
        private FrmLogIn frmLogin;
        private FrmAbout frmAbout;
        private FrmSwitchUser frmSwitchUser;
        private ClientHistory clientHistory;                
        public void SetFontSize() // dat lai font chu khac
        {
            int fs = 10;
            switch (sizeFont)
            {
                case 1: 
                    fs = 6;
                    break;
                case 2 :
                    fs = 10;
                    break;
                case 3 :
                    fs = 14;
                    break;
                case 4:
                    fs = 18;
                    break;                
            }

            System.Drawing.Font refFont = listView1.Font;

            System.Drawing.Font myFont = new Font(refFont.FontFamily, fs,FontStyle.Bold);
            
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Font = myFont;
            }
           /*
            btHibernate.Font = myFont;
            btKillApp.Font = myFont;
            btLock.Font = myFont;
            btTurnOff.Font = myFont;
            btLock.Font = myFont;
            */
        }
        public FrmMain()
        {
            InitializeComponent();
            allRight = false;
            continueMain = new bool[2];
            //DateTime dd = DateTime.Parse("12/2/2006");
            //MessageBox.Show(dd.ToShortDateString());
            frmFlash = new FrmFlash();
            frmFlash.ShowDialog();
            frmLogin = new FrmLogIn();            
            continueMain = frmLogin.ShowDialog();
            allRight = continueMain[1];
           
            if (!continueMain[0])
            {
                //MessageBox.Show("Không đúng mật khẩu. Chương trình sẽ tự động thoát!");
                this.Close();
            }
            else
            {
                /* *********************** Edited by Leo **********************************
                 * ***********************************************************************/
                //MessageBox.Show("Chào mừng đến với Microsft NetCafe 2006!");
                if (allRight == false)
                {
                    this.Text = "MS NET CAFE - PHIEN LAM VIEC CUA NGUOI QUAN LY MANG";
                    DataTransfer.saveSystemEvent("Đăng nhập", "Thành công", "Người quản lý mạng");
                    turnOffRight();
                    //this.btSetConfig.Enabled = false;
                }
                if (allRight == true)
                {
                    this.Text = "MS NET CAFE - PHIEN LAM VIEC CUA CHU CUA HANG";
                    DataTransfer.saveSystemEvent("Đăng nhập", "Thành công", "Chủ cửa hàng");
                }
                /* ***********************End Edited by Leo **********************************
                * ***********************************************************************/
            }
            
            /**/
            frmHelp = new FrmHelpForm();
            frmReport = new FrmReportChoose();
            frmLog = new FrmLogSystem();
            frmParamSystem = new FrmParaSystem();
            frmPriceManage = new FrmPriceWizard();
            //frmUserChoose = new FrmUserChoose();

            if (allRight == false)
            {
                //this.btPrice.Enabled = false;
                turnOffRight();
                //this.btSetConfig.Enabled = false;
            }
        }

       private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btReport_Click(object sender, EventArgs e)
        {
            
            frmReport.ShowDialog(allRight);
            //FrmTimeUserReport report = new FrmTimeUserReport();
            //report.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            clientHistory = new ClientHistory();
            // thiet lap du lieu tam thoi
            //dgvComMan.RowCount = 0;
            timer1.Enabled = true;
            serverSocket1.OpenPort();
            StreamReader reader = new StreamReader(new FileStream("..\\Configure\\" + "fontsize.dat",FileMode.Open));
            cbFontSize.SelectedIndex = 1;
            sizeFont = 2;
            //sizeFont = Convert.ToInt16(reader.ReadLine());
            reader.Close();
            SetFontSize();
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            //frmHelp.ShowDialog();
            try
            {
                Help.ShowHelp(this, "Help.chm", HelpNavigator.TableOfContents);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy file trợ giúp !");
            }
            
        }

        private void btLog_Click(object sender, EventArgs e)
        {
            //DataTransfer.saveFeeEvent(true, "anh", "12/2/2006", "4pm", "30", "2000");
            WinEffect.AnimateWindow(frmLog, 300, AnimateWindowStyle.AW_CENTER);
            frmLog.ShowDialog(allRight);
        }

        private void btSetConfig_Click(object sender, EventArgs e)
        {
            frmParamSystem.ShowDialog();
            //MessageBox.Show();
            StreamReader reader = new StreamReader(new FileStream("..\\Configure\\" + "fontsize.dat", FileMode.Open));
            sizeFont = Convert.ToInt16(reader.ReadLine());
            reader.Close();
            SetFontSize();
        }

        private void btPrice_Click(object sender, EventArgs e)
        {
            WinEffect.AnimateWindow(frmPriceManage, 300, AnimateWindowStyle.AW_CENTER);
            frmPriceManage.ShowDialog();
        }

        private void btUserMan_Click(object sender, EventArgs e)
        {
            //frmAccount.ShowDialog();
            /* **********************************
             * Edited by DuongNT
             * 
             * 0902006
             * **********************************/
            if (!allRight)
            {
                UserMan um = new UserMan();
                WinEffect.AnimateWindow(um, 300, AnimateWindowStyle.AW_CENTER);
                um.ShowDialog();
            }
            else
            {
                BossMan bm = new BossMan();
                WinEffect.AnimateWindow(bm, 300, AnimateWindowStyle.AW_CENTER);
                bm.ShowDialog();
            }
            //frmUserChoose.ShowDialog(allRight);
            /* **********************************
             * End Edited by DuongNT
             * 0902006
             * **********************************/

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                    return;
                // lay thong tin cua thang Client

                int clID = Int32.Parse(listView1.SelectedItems[0].Name);
                ClientInfo cli = serverSocket1.GetClientByHash(clID);
                ClientInformDetails cl = clientHistory.Retrieve(cli.IP);
                grpClientName.Text = cli.ClientName;

                if (cli.Status == 0)
                {
                    int tmp = serverSocket1.GetTicks() - cli.Ticks;
                    lbUsedMins.Text = (tmp + cli.oldTime).ToString(); // lay so phut
                    ////lbUsedMins.Text = (tmp + cli.oldTime).ToString(); // lay so phut
                    try
                    {
                        //lbMoney.Text = (Algorithm.CalcPay(tmp, cli.Start, DateTime.Now) + clientHistory.Retrieve(cli.IP).money).ToString();
                        // tin tien
                        if (cli.feeStatus == 0)
                        {
                            lbMoney.Text = "0 đồng";
                            //lbMoney.Text = (cl.money + cli.money).ToString() + " đồng";
                            changeToSatus(0, 0);
                        }
                        else
                        {
                            lbMoney.Text = (cli.money + cli.oldMoney).ToString() + " đồng";
                            ////lbMoney.Text = (cli.oldMoney + cli.money).ToString() + " đồng";
                            changeToSatus(0, 1);
                        }
                    }
                    catch (Exception) { }
                }
                else
                {
                    if (cli.feeStatus == 0)
                    {
                        lbUsedMins.Text = "0";
                        lbMoney.Text = "0 đồng";
                        changeToSatus(1, 0);
                    }
                    else
                    {
                        //if (cli != null)
                        //{
                            int tmp = serverSocket1.GetTicks() - cli.Ticks;
                            ////lbUsedMins.Text = (tmp + cl.time).ToString();
                            lbUsedMins.Text = (tmp + cli.oldTime).ToString();
                            ////lbMoney.Text = (cl.money + cli.money).ToString() + " đồng";
                            lbMoney.Text = (cli.oldMoney + cli.money).ToString() + " đồng";
                        //}
                        //else
                        //{
                        //    lbUsedMins.Text = cl.time.ToString();
                        //    lbMoney.Text = cl.money.ToString() + " đồng";
                        //}
                        changeToSatus(1, 1);
                    }
                }                
                if ((cl.money == 0) && (cl.time == 0))
                {
                    cl.start = cli.Start;
                }
                if (cli.Status == 1 && cli.feeStatus ==1)
                    lbTimeStart.Text = "Chưa tính tiền";
                else
                    lbTimeStart.Text = cl.start.ToLongTimeString();
            

                pnClientInform.Show();
                if ((cli.Status == 1 || (cli.Status==0 && cli.feeStatus==0)))
                {
                    //                btLock.Text = "Mở khóa";
                    mniControlUseMachine.Text = "Sử dụng máy";
                    //btCaculateFee.ImageIndex = 0;
                }
                else if(cli.Status ==0 && cli.feeStatus ==1)
                {
                    //btLock.Text = "Khóa máy";
                    //btHibernate.Text = "Tính tiền";
                    mniControlUseMachine.Text = "Tính tiền";
                    //btCaculateFee.ImageIndex = 1;
                }
                SetBtStatus(true);

                serverSocket1.Send(clID, Commands.GetProcess, 0, "");
            }
            catch (Exception ea)
            {
                //   MessageBox.Show(ea.ToString());
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult drs = MessageBox.Show("Bạn có muốn chuyển sang phiên làm việc của người dùng khác không?","Chuyen che do nguoi dung",MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (drs == DialogResult.No) return;
            frmSwitchUser = new FrmSwitchUser();
            WinEffect.AnimateWindow(frmSwitchUser, 300, AnimateWindowStyle.AW_CENTER);  
            continueMain = frmSwitchUser.ShowDialog();
            // neu khong thay doi gi
            if (!frmSwitchUser.IsModified) return;
            allRight = continueMain[1];
            if (!continueMain[0])
            {
                //MessageBox.Show("Chuyển chế độ người dùng thất bại !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                turnOffRight();
                if (allRight == true)
                {
                    DataTransfer.saveSystemEvent("Chuyển chế độ người dùng", "Thất bại", "Không chuyển được sang chế độ quản trị hệ thống");
                }
                if (allRight == false)
                {
                    DataTransfer.saveSystemEvent("Chuyển chế độ người dùng", "Thất bại", "Không chuyển được sang chế độ người quản lý mạng");
                }
            }
            else
            {
                if (allRight == true)
                {
                    this.Text = "MS NET CAFE - PHIEN LAM VIEC CUA CHU CUA HANG";
                    turnOnRight();
                    DataTransfer.saveSystemEvent("Chuyển chế độ người dùng", "Thành công", "Đã chuyển sang phiên làm việc của quản trị hệ thống");

                }
                if (allRight == false)
                {
                    this.Text = "MS NET CAFE - PHIEN LAM VIEC CUA NGUOI QUAN LY MANG";
                    turnOffRight();
                    DataTransfer.saveSystemEvent("Chuyển chế độ người dùng", "Thành công", "Đã chuyển sang phiên làm việc của người quản lý mạng");
                }
                /* **************************End Edited by Leo *********************
                 * *************************************************************/
            }
        }

            /* **********************************
             * Edited by Leo
             * 0802006
             * **********************************/
        private void turnOnRight()
        {
            this.btPrice.Enabled = true;
            this.mniViewPrice.Enabled = true;
            //this.btSetConfig.Enabled = true;
        }

        private void turnOffRight()
        {
            this.btPrice.Enabled = false;
            this.mniViewPrice.Enabled = false;
            //this.btSetConfig.Enabled = false;
        }
        /* **********************************
        * End Edited by Leo
        * 0802006
        * **********************************/

        private void lstApplications_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private delegate void dele_addclient(ListViewItem n);
        private void addclient(ListViewItem n)
        {
            if (label4.Visible == true) label4.Visible = false;
            listView1.Items.Add(n);
        }
        private delegate void dele_ListviewChangeItem(int hs, int imgId);
        private void listviewChangeItem(int hs, int imgId)
        {
            listView1.Items[hs.ToString()].ImageIndex = imgId;
        }
        private delegate void dele_remclient(int hs);
        private void remclient(int hs)
        {
            if (listView1.Items.Find(hs.ToString(), false).Length > 0)
            listView1.Items.RemoveByKey(hs.ToString());
            if (listView1.Items.Count == 0)
            {
                label4.Visible = true;
                label4.Text = "Mạng đã bị tắt hoặc gặp sự cố! Bạn vui lòng đợi 5 phút ...";
            }
        }
        private delegate void dele_editclient(int h, string data);
        private void editclient(int h, string data)
        {            
            listView1.Items[h.ToString()].Text = data;
        }

        private void serverSocket1_OnClientConnect(object sender, int h)
        {
            ListViewItem n = new ListViewItem("", 0);
            ClientInfo cli = serverSocket1.GetClientByHash(h);
            /*
             * Modified by: NghienPC
             * lastupdate : 3/10/2006
             */
            ClientInformDetails cl = clientHistory.Mydify(cli.IP, cli.Start);
            n.ImageIndex = 0;
            if (cl != null)
            {                
                cli.isReconnect = true;                
                cli.feeStatus = cl.oldFeeStatus; // thiet lap lai trang thai
                cli.Status = cl.clientStatus;
                cli.oldMoney = cl.money; // thiet lap lai tien
                cli.oldTime = cl.time;  // thiet lap lai thoi gian

                if (cli.oldMoney <= Algorithm.PayMin && cli.isReconnect)
                    cl.money = 0;                    
                //MessageBox.Show("Hey: " + cl.clientStatus.ToString() + ": " + cl.oldFeeStatus.ToString());
                if (cli.feeStatus == 0 && cli.Status == 0)
                {
                    n.ImageIndex = 2;
                }
                if (cli.feeStatus == 1 && cli.Status == 0)
                {
                    n.ImageIndex = 0;
                }
                if (cli.Status == 1)
                {
                    n.ImageIndex = 1;
                }
            }
            else
            {
                cli.feeStatus = 0;
                cli.Status = 1;
                cli.isReconnect = false;
            }
            
            /*
             * end
             */
            n.Name = h.ToString();
            //serverSocket1.Send(h, Commands.Unlock, "");
            //Thread.Sleep(200);
            //MessageBox.Show("aaa");
            
            listView1.Invoke(new dele_addclient(addclient), n);
            dgvComMan.Invoke(new dele_insertDgvRow(insertDgvRow), cli);
            listView1.Invoke(new dele_editclient(editclient), h, cli.ClientName);
            serverSocket1.Send(h, Commands.GetClientName, 0, "");
        }


        //-------------------------------------------------------------------
        // va ham nay nua
        private void serverSocket1_OnClientDisconnect(object sender, int hs)
        {
            //            listView1_SelectedIndexChanged(null, null);            
            try
            {
                if (serverSocket1 == null) return;
                ClientInfo cli = serverSocket1.GetClientByHash(hs);
                if (cli == null) return;
                ClientInformDetails cl = clientHistory.Retrieve(cli.IP);
                if (cl != null)
                {
                    cl.time += cli.realTicks;
                    cl.money += cli.money;
                    cl.clientStatus = cli.Status; // luu giu lai trang thai
                    cl.oldFeeStatus = cli.feeStatus;
                    //MessageBox.Show(cl.clientStatus.ToString() + ": " + cl.oldFeeStatus.ToString());
                    if (cl.NeedClear)
                        clientHistory.Remove(cl.clientIp);
                }

                if (dgvComMan == null) return;
                if (listView1 == null) return;
                dgvComMan.Invoke(new dele_insertDgvRowDisc(insertDgvRowDisc), cli, cl);
                listView1.Invoke(new dele_remclient(remclient), hs);
            }
            catch (Exception)
            {
            }
        }
        

        private delegate void dele_insertDgvRow(ClientInfo cli);
        private void insertDgvRow(ClientInfo cli)
        {
            DislayClienStatus(cli);
            dgvComMan.Rows[0].Cells[2].Value = DateTime.Now.ToShortTimeString();
            dgvComMan.Rows[0].Cells[3].Value = "Kết nối";
            if (cli.isReconnect == true)
            {
                dgvComMan.Rows[0].Cells[4].Value = "Tiếp tục phiên bị ngắt";
            }
            else
            {
                dgvComMan.Rows[0].Cells[4].Value = "Bắt đầu phiên mới ";
            }
        }
        private void DislayClienStatus(ClientInfo cli)
        {
            //string s = dgvComMan.Rows[0].Cells[0].Value.ToString();
            if (isInitialized)
                dgvComMan.Rows.Insert(0, 1);// chen them mot dong moi
            else
                dgvComMan.Rows.Add(1);
            if (!isInitialized) isInitialized = true;

            DateTime date = DateTime.Today;
            dgvComMan.Rows[0].Cells[0].Value = date.Day + "/" + date.Month + "/" + date.Year;
            //dgvComMan.Rows[0].Cells[2].Value = cli.Start.ToLongTimeString(); // gio bat dau
            dgvComMan.Rows[0].Cells[2].Value = DateTime.Now.ToShortTimeString();
            dgvComMan.Rows[0].Cells[1].Value = cli.ClientName; // ten may
        }

        private delegate void dele_insertDgvRowDisc(ClientInfo cli, ClientInformDetails cl);
        private void insertDgvRowDisc(ClientInfo cli, ClientInformDetails cl)
        {            
            DislayClienStatus(cli);
            dgvComMan.Rows[0].Cells[3].Value = "Ngắt kết nối";
            //if (cl != null)
                //dgvComMan.Rows[0].Cells[4].Value = "Tiền: " + (cl.money + cli.money).ToString() + " đồng, phút sử dụng: " + cl.time.ToString();
            if (cl != null)
                dgvComMan.Rows[0].Cells[4].Value = "Thời gian: " + cl.time.ToString() + ". Thành tiền: " + (cl.money).ToString();
        }
        private delegate void dele_addApp(ListViewItem n);
        private void addApp(ListViewItem n)
        {
            lblApp.Text = "Số ứng dụng đang chạy: " + lvApplications.Items.Count.ToString();
            lvApplications.Items.Add(n);
            //lvApplications.Refresh();
        }
        private delegate void dele_clearApp();
        private void clearApp()
        {
            lblApp.Text = "Số ứng dụng đang chạy: " + lvApplications.Items.Count.ToString();
            lvApplications.Items.Clear();
        }
        private delegate void dele_UpdateApp(String s);
        private void UpdateApp(String s)
        {
            
            int si = -1;
            string[] des; // tach thanh cac xau
            char[] chs = { (char)128 };

            des = s.Split(chs, StringSplitOptions.RemoveEmptyEntries);            
            // luu lai selected item
            if (lvApplications.SelectedItems.Count != 0)
                si = lvApplications.SelectedItems[0].Index;
            lvApplications.Items.Clear();
            for (int i = 0; i < (uint)(des.Length); i += 2)
            {
                ListViewItem lvi = new ListViewItem("1", 0);
                lvi.Text = des[i];
                lvi.Name = des[i + 1]; // lay ID                            
                lvApplications.Items.Add(lvi);
            }
             // gan lai selected item
            if ((si != -1) && (si < lvApplications.Items.Count))
                lvApplications.Items[si].Selected = true;
            lblApp.Text = "Số ứng dụng đang chạy: " + lvApplications.Items.Count.ToString();
            
        }

        private void serverSocket1_OnClientWrite(object sender, int h, Commands comd, uint lParam, string strParam)
        {
            //    MessageBox.Show( comd.ToString() + strParam);
            if (comd == Commands.GetClientName) // lay ten máy
            {
                //MessageBox.Show("May client: "+data);

                //serverSocket1.GetClientByHash(0                
                ClientInfo cli = serverSocket1.GetClientByHash(h);
                //cli.Status = cli.feeStatus;
                if (cli.Status == 1)
                {
                    serverSocket1.Send(h, Commands.Lock, 0, "");
                    //                    cli.Status = 1;
                    //                    cli.feeStatus = 0;
                    listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 1);
                }
                else
                    if (cli.Status == 0 && cli.feeStatus == 0)
                    {
                        //cli.feeStatus = 1;
                        //cli.Ticks = serverSocket1.GetTicks();
                        listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 2);
                    }
                    else if (cli.Status == 0 && cli.feeStatus == 1)
                    {

                        cli.feeStatus = 1;
                        cli.Ticks = serverSocket1.GetTicks();
                        listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 0);
                    }

                //serverSocket1.Send(h, Commands.Unlock, "");

                //listView1.Items[h.ToString()].ImageIndex = 1;                

               
                dgvComMan.Rows[0].Cells[1].Value = cli.ClientName;
                listView1.Invoke(new dele_editclient(editclient), h, cli.ClientName);
                //MessageBox.Show("Lock Kết nối");

            }
            else if (comd == Commands.GetProcess)
            {
                lvApplications.Invoke(new dele_UpdateApp(UpdateApp), strParam);
            }

            //else if (comd != Commands.OK) 
            //MessageBox.Show(comd.ToString() + "|" + data);

        }
        
        private void cmdLock_Click(object sender, EventArgs e)
        {
            int h = Int32.Parse(listView1.SelectedItems[0].Name);
            serverSocket1.Send(h, Commands.Restart, 0, "");
        }

        private void startCalFee(ref ClientInfo cli )
        {
            DialogResult rs = MessageBox.Show("Bắt đầu sử dụng máy " + cli.ClientName, "Su dung may", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (rs == DialogResult.OK)
            {
                listView1_SelectedIndexChanged(null, null);
                cli.feeStatus = 1;
                cli.Start = DateTime.Now;
                //cli.Status = 0;
                cli.Ticks = serverSocket1.GetTicks();
                //*DislayClienStatus(cli);
                lockOrUnlock(0);
                DislayClienStatus(cli);
                dgvComMan.Rows[0].Cells[3].Value = "Bắt đầu sử dụng";
                dgvComMan.Rows[0].Cells[4].Value = "Bắt đầu tính tiền cho máy";
            }
        }

        private void stopCalFee(ref ClientInfo cli)
        {
            cli.feeStatus = 0;
            string mon = lbMoney.Text.Split(' ')[0];
            FrmCalMoney frmCalMoney = new FrmCalMoney();
            frmCalMoney.StartTime = cli.Start.ToLongTimeString();
            int c = serverSocket1.GetTicks() - cli.Ticks + cli.oldTime;
            int hours = c / 60;
            int min = c % 60;
            string tg = hours.ToString() + " giờ " + min.ToString() + " phút";
            frmCalMoney.UsedTime = tg;
            frmCalMoney.Money = mon;
            // --------------------- edited by leo -----------------------------
            try
            {
                lockOrUnlock(1);
            }
            catch (Exception)
            {
                //MessageBox.Show(ea.ToString());
            }
            frmCalMoney.ShowDialog();
            ClientInformDetails cl = clientHistory.Retrieve(cli.IP);
            if (cl != null && cli.Status == 1)
                cl.NeedClear = true; // danh dau tinh tien
            DislayClienStatus(cli);
            dgvComMan.Rows[0].Cells[3].Value = "Kết thúc sử dụng";
            dgvComMan.Rows[0].Cells[4].Value = "Thời lượng: " + tg + ". Số tiền: " + mon + " đồng";
            //MessageBox.Show("Lock tính tiền");
            DataTransfer.saveFeeEvent(true, cli.ClientName, DateTime.Today.Date.ToString(), frmCalMoney.StartTime.ToString(), Convert.ToString(hours * 60 + min), mon);
        }

        private void lockOrUnlock(int wantToLock)
        {
            int h = Int32.Parse(listView1.SelectedItems[0].Name);
            ClientInfo cli= serverSocket1.GetClientByHash(h);
            if (cli.Status ==0 & wantToLock==1)
            {
                // send them vai lan nua cho chac an
                for (int kk = 0; kk < 1; kk++)
                    serverSocket1.Send(h, Commands.Lock, 0, "");
                //MessageBox.Show("Da khoa");
                listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 1);
                //listView1.Items[h.ToString()].ImageIndex = 1;
//                btLock.Text = "Mở khóa";
                cli.Status = 1;
                
                //DislayClienStatus(cli);
                //dgvComMan.Rows[0].Cells[3].Value = "Khóa máy";
                //dgvComMan.Rows[0].Cells[4].Value = "Khóa máy đang được tính tiền";
                //MessageBox.Show("Lock Khóa máy");
                //this.btLock.ImageIndex = 6;
                changeToSatus(0, 1);
            }
            else if(cli.Status==1 & wantToLock==0)
            {
                // send them vai lan nua cho chac an
                for (int kk = 0; kk < 1; kk++ )
                    serverSocket1.Send(h, Commands.Unlock, 0, "");
                //MessageBox.Show("Da mo khoa");
                //cli.Start = DateTime.Now;
                //MessageBox.Show(cli.Start.
//                btLock.Text = "Khóa máy";
                //listView1.Items[h.ToString()].ImageIndex = 0;                
                if(cli.feeStatus==1)
                    listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 0);
                else
                    listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 2);
                cli.Status = 0;
                //*cli.Ticks = serverSocket1.GetTicks();
                //DislayClienStatus(cli);
                //dgvComMan.Rows[0].Cells[3].Value = "Mở khóa";
                //dgvComMan.Rows[0].Cells[4].Value = "Mở khóa máy đang được tính tiền";
                //MessageBox.Show("Lock Mở khóa");
                //this.btLock.ImageIndex = 5;
                changeToSatus(1, 1);
            }
            if (wantToLock == 0)
                listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 0);
            //ClientInfo c = serverSocket1.GetClientByHash(h);
            //MessageBox.Show(c.Status.ToString());
        }

        private void lockOrUnlock()
        {
            int h = Int32.Parse(listView1.SelectedItems[0].Name);
            ClientInfo cli = serverSocket1.GetClientByHash(h);

            if (cli.Status == 0)
            {
                //changeToSatus(1, 0);
                // send them vai lan nua cho chac an
                for (int kk = 0; kk < 1; kk++)
                    serverSocket1.Send(h, Commands.Lock, 0, "");
                //MessageBox.Show("Da khoa");
                listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 1);
                //listView1.Items[h.ToString()].ImageIndex = 1;
                //                btLock.Text = "Mở khóa";
                //this.btLock.ImageIndex = 6;
                DislayClienStatus(cli);
                dgvComMan.Rows[0].Cells[3].Value = "Khóa máy";
                
                //MessageBox.Show("Lock Khóa máy");
                if (cli.feeStatus == 1)
                {
                    changeToSatus(1, 1);
                    dgvComMan.Rows[0].Cells[4].Value = "Khóa máy đang được tính tiền";
                }
                else
                {
                    changeToSatus(1, 0);
                    dgvComMan.Rows[0].Cells[4].Value = "Khóa máy đang sử dụng không hợp lệ";
                    if (cli.feeStatus == 0 & allRight == true)
                        DataTransfer.saveSystemEvent("Kết thúc sử dụng không tính tiền", "Việc sử dụng không hợp lệ kết thúc bởi chủ cửa hàng", "Chủ cửa hàng");
                    else if (cli.feeStatus == 0 & allRight == false)
                        DataTransfer.saveSystemEvent("Kết thúc sử dụng không tính tiền", "Việc sử dụng không hợp lệ kết thúc bởi người quản lý", "Người quản lý mạng");
                }
                cli.Status = 1;
            }
            else
            {
                //this.btLock.ImageIndex = 5;
                if (cli.feeStatus == 0)
                {
                    DialogResult rs = MessageBox.Show("Nếu bạn sử dụng máy này không tính tiền," + (char)13 + " thông tin sẽ được lưu lại trong nhật ký hệ thống." + (char)13 + " Bạn có muốn tiếp tục sử dụng không?", "Canh bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        changeToSatus(0, 0);
                        // send them vai lan nua cho chac an
                        for (int kk = 0; kk < 1; kk++)
                            serverSocket1.Send(h, Commands.Unlock, 0, "");
                        //MessageBox.Show("Da mo khoa");
                        //cli.Start = DateTime.Now;
                        //MessageBox.Show(cli.Start.
                        //                btLock.Text = "Khóa máy";
                        //listView1.Items[h.ToString()].ImageIndex = 0;
                        //if (cli.feeStatus == 1)
                        //{
                        //    listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 0);
                        //}
                        //else
                        //{
                            listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 2);
                        //}
                        cli.Status = 0;
                        //*cli.Ticks = serverSocket1.GetTicks();
                        DislayClienStatus(cli);
                        dgvComMan.Rows[0].Cells[3].Value = "Mở khóa";
                        dgvComMan.Rows[0].Cells[4].Value = "Mở máy sử dụng không hợp lệ";
                        //MessageBox.Show("Lock Mở khóa");
                        if (cli.feeStatus == 0 & allRight == true)
                        {
                            DataTransfer.saveSystemEvent("Bắt đầu sử dụng không tính tiền", "Việc sử dụng không hợp lệ bắt đầu bởi chủ cửa hàng", "Chủ cửa hàng");
                        }
                        else if (cli.feeStatus == 0 & allRight == false)
                        {
                            //dgvComMan.Rows[0].Cells[4].Value = "Mở máy để sử dụng không tính tiền";
                            DataTransfer.saveSystemEvent("Bắt đầu sử dụng không tính tiền", "Việc sử dụng không hợp lệ bắt đầu bởi người quản lý", "Người quản lý mạng");
                        }
                    }
                    //ClientInfo c = serverSocket1.GetClientByHash(h);
                    //MessageBox.Show(c.Status.ToString());
                }
                else
                {
                    changeToSatus(0, 1);
                    for (int kk = 0; kk < 1; kk++)
                        serverSocket1.Send(h, Commands.Unlock, 0, "");
                    //MessageBox.Show("Da mo khoa");
                    //cli.Start = DateTime.Now;
                    //MessageBox.Show(cli.Start.
                    //                btLock.Text = "Khóa máy";
                    //listView1.Items[h.ToString()].ImageIndex = 0;
                    //if (cli.feeStatus == 1)
                    //{
                        listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 0);
                    //}
                    // else
                    //{
                    //    listView1.Invoke(new dele_ListviewChangeItem(listviewChangeItem), h, 2);
                    //}
                    cli.Status = 0;
                    //*cli.Ticks = serverSocket1.GetTicks();
                    DislayClienStatus(cli);
                    dgvComMan.Rows[0].Cells[3].Value = "Mở khóa";
                    dgvComMan.Rows[0].Cells[4].Value = "Mở máy tiếp tục sử dụng";
                    //MessageBox.Show("Lock Mở khóa");

                }
            }
        }

        private void cbTypeLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            serverSocket1.Close();
            /* ************* Edited by Leo *************************
             * ****************************************************/
            if (allRight == true)
            {
                DataTransfer.saveSystemEvent("Đăng xuất", "Thành công", "Quản trị hệ thống");
            }
            if (allRight == false)
            {
                DataTransfer.saveSystemEvent("Đăng xuất", "Thành công", "Người quản lý mạng");
            }
            /* *************End Edited by Leo *************************
            * ****************************************************/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int h = Int32.Parse(listView1.SelectedItems[0].Name);            
            serverSocket1.Send(h, Commands.Shutdown, 0, "");
            ClientInfo cli = serverSocket1.GetClientByHash(h);
            DislayClienStatus(cli);
            dgvComMan.Rows[0].Cells[3].Value = "Tắt máy";
            dgvComMan.Rows[0].Cells[4].Value = "Thành công";
            //MessageBox.Show("Lock tắt máy");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int h = Int32.Parse(listView1.SelectedItems[0].Name);
            ClientInfo cli = serverSocket1.GetClientByHash(h);
            /*
            serverSocket1.Send(h, Commands.Hibernate, "");
            DislayClienStatus(cli);
            dgvComMan.Rows[0].Cells[3].Value = "Hibernate";
            dgvComMan.Rows[0].Cells[4].Value = "OK";*/
            //string mon = lbMoney.Text;
            // --------------------- edited by leo -------------------------------
            //try
            //{
            //    button3_Click(null, null);
            //}
            //catch (Exception)
            //{
            //    //MessageBox.Show(ea.ToString());
            //}
            // --------------------- end edited  -------------------------------
            if (cli.feeStatus == 0)
            {
                //toolTip1.SetToolTip(btCaculateFee, "Tính tiền");
                startCalFee(ref cli);
                /*
                ClientInformDetails cl = clientHistory.Retrieve(cli.IP);
                
                if (cli.feeStatus == 0 && cli.Status == 0)
                {
                    cl.money = 0;
                    cl.time = 0;
                }*/
                ClientInformDetails cl = clientHistory.Retrieve(cli.IP);
                if (cl != null)
                {
                    cl.money = 0;
                    cl.time = 0;

                }
                if (allRight == true)
                    DataTransfer.saveSystemEvent("Kết thúc sử dụng không tính tiền", "Việc sử dụng không hợp lệ kết thúc bởi chủ cửa hàng", "Chủ cửa hàng");
                else
                    DataTransfer.saveSystemEvent("Kết thúc sử dụng không tính tiền", "Việc sử dụng không hợp lệ kết thúc bởi người quản lý", "Người quản lý mạng");
                //    btHibernate.Text = "Tính tiền";
                //btCaculateFee.ImageIndex = 1;
                //try
                //{
                 //   button3_Click(null, null);
                //}
                //catch (Exception)
                //{
                    //MessageBox.Show(ea.ToString());
                //}

            }
            else
            {
                //btHibernate.Text = "Sử dụng";
                //toolTip1.SetToolTip(btCaculateFee, "Sử dụng");
                //btCaculateFee.ImageIndex = 0;
                cli.isReconnect = false;
                ClientInformDetails cl = clientHistory.Retrieve(cli.IP);
                if (cl != null)
                {
                    cl.money = 0;
                    cl.time = 0;
                    
                }
                stopCalFee(ref cli);
                //FrmCalMoney frmCalMoney = new FrmCalMoney();
                //frmCalMoney.StartTime = cli.Start.ToLongTimeString();
                //int c = serverSocket1.GetTicks() - cli.Ticks;
                //int hours = c / 60;
                //int min = c % 60;
                //string tg = hours.ToString() + " giờ " + min.ToString() + " phút";
                //frmCalMoney.UsedTime = tg;
                //frmCalMoney.Money = mon;
                // --------------------- edited by leo -----------------------------
                //bool lockComputer = frmCalMoney.ShowDialog();
                //if (lockComputer == true)
                //{
                //    try
                //    {
                //        button3_Click(null, null);
                //    }
                //    catch (Exception)
                //    {
                        //MessageBox.Show(ea.ToString());
                //    }
                //}
                // --------------------- end edited  -------------------------------
                //ClientInformDetails cl = clientHistory.Retrieve(cli.IP);
                //if (cl != null) 
                //    cl.NeedClear = true; // danh dau tinh tien
                //DislayClienStatus(cli);
                //dgvComMan.Rows[0].Cells[3].Value = "Tính tiền";
                //dgvComMan.Rows[0].Cells[4].Value = "thời gian: " + tg + ", thành tiền " + mon + " đồng";
                //MessageBox.Show("Lock tính tiền");
                //DataTransfer.saveFeeEvent(true, cli.ClientName, DateTime.Today.Date.ToString(), frmCalMoney.StartTime.ToString(), Convert.ToString(hours*60+min), mon);
                //DataTransfer.saveFeeEvent(true, "anh","12/2/2006","4pm","6pm","2000");

            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lvApplications.SelectedItems == null) return;
            if (lvApplications.SelectedItems.Count == 0) return;
            int h = Int32.Parse(listView1.SelectedItems[0].Name);
            // tat ung dung
            uint appID = UInt32.Parse(lvApplications.SelectedItems[0].Name);
            serverSocket1.Send(h, Commands.DeleteProcess, appID, "");
            ClientInfo cli = serverSocket1.GetClientByHash(h);
            DislayClienStatus(cli);
            dgvComMan.Rows[0].Cells[3].Value = "Tắt ứng dụng";
            dgvComMan.Rows[0].Cells[4].Value = lvApplications.SelectedItems[0].Text;
        }
        private void SetBtStatus(bool s)
        {
//            btLock.Enabled = s;
            btKillApp.Enabled = s;
            btRestart.Enabled = s;
            btTurnOff.Enabled = s; 
            btCaculateFee.Enabled = s;
            btLock.Enabled = s;
            pnShowClientInform.Visible = s;
            // thiet lap cho menu
            mniControlKillApp.Enabled = s;
            mniControlRestart.Enabled = s;
            mniControlTurnoff.Enabled = s;
            mniControlUseMachine.Enabled = s;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                grpClientName.Text = "Điều khiển";
                lvApplications.Items.Clear();
                lblApp.Text = "Số ứng dụng đang chạy: 0";
                SetBtStatus(false);
            }
            else
            {                                                
                listView1_SelectedIndexChanged(null, null);
                if (lvApplications.SelectedItems.Count != 0)
                    btKillApp.Enabled = true;
                else                    
                    btKillApp.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* ************* Edited by Leo *************************
            * ****************************************************/
            DialogResult drt = MessageBox.Show("Bạn thực sự muốn thoát chương trình ?", "Xac nhan thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drt == DialogResult.Yes)
            {
                
                /* *************End Edited by Leo *************************
                * ****************************************************/
                GC.Collect();
             
                Application.Exit();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbTimeStart_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void tsMnItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            sizeFont = cbFontSize.SelectedIndex + 1;
            SetFontSize();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lbUsedMins_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lvApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvApplications.SelectedItems.Count != 0)
                btKillApp.Enabled = true;
            else
                btKillApp.Enabled = false;
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            lockOrUnlock();
        }

        private void changeToSatus(int status, int feeStatus)
        {
            //this.btCaculateFee.ImageIndex = 0 : bieu tuong mo khoa tinh tien
            //this.btCaculateFee.ImageIndex = 1 : bieu tuong khoa ket thuc tinh tien
            //this.btLock.ImageIndex = 6 : bieu tuong mo khoa bat thuong
            //this.btLock.ImageIndex = 5 : bieu tuong khoa may bat thuong
            
            if (status == 0)
            {
                if (feeStatus == 0)
                {
                    if (btCaculateFee.ImageIndex != 0)
                    {
                        this.btCaculateFee.ImageIndex = 0;
                        this.toolTip1.SetToolTip(this.btCaculateFee,"Bắt đầu tính tiền");
                    }
                    if (btLock.ImageIndex != 5)
                    {
                        this.btLock.ImageIndex = 5;
                        this.toolTip1.SetToolTip(this.btLock, "Khóa máy");
                    }
                }
                else 
                {
                    if (btCaculateFee.ImageIndex != 1)
                    {
                        this.btCaculateFee.ImageIndex = 1;
                        this.toolTip1.SetToolTip(this.btCaculateFee, "Kết thúc sử dụng");
                    }
                    if (btLock.ImageIndex != 5)
                    {
                        this.btLock.ImageIndex = 5;
                        this.toolTip1.SetToolTip(this.btLock, "Khoá máy");
                    }
                }
            }
            else 
            {
                if (feeStatus == 0)
                {
                    if (btCaculateFee.ImageIndex != 0)
                    {
                        this.btCaculateFee.ImageIndex = 0;
                        this.toolTip1.SetToolTip(this.btCaculateFee, "Bắt đầu tính tiền");
                    }
                    if (btLock.ImageIndex != 6)
                    {
                        this.btLock.ImageIndex = 6;
                        this.toolTip1.SetToolTip(this.btLock, "Mở khóa");
                    }
                }
                else
                {
                    if (btCaculateFee.ImageIndex != 1)
                    {
                        this.btCaculateFee.ImageIndex = 1;
                        this.toolTip1.SetToolTip(this.btCaculateFee, "Kết thúc sử dụng");
                    }
                    if (btLock.ImageIndex != 6)
                    {
                        this.btLock.ImageIndex = 6;
                        this.toolTip1.SetToolTip(this.btLock, "Mở khóa");
                    }
                }
            }
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }
    }
    /*
    class ClsString : 
    {
        private string strName;
        private string strText;
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }
        public string ClassName
        {
            get { return strName; }
            set { strName = value; }
        }
        
    }*/
}
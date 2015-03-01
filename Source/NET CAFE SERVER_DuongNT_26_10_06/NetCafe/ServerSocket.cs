using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.Timers;
using System.IO;

namespace NetCafe
{
    // Server error codes
    public enum ServerErrorCodes
    {
        OpenPort = 1,
        AcceptSocket = 2,
    }
    // Client error codes
    public enum ClientErrorCodes
    {
        Lost = 1,
    }

    public enum Commands
    {
        AreOK = 0,
        Lock = 1,
        Unlock = 2,
        Restart = 3,
        Shutdown = 4,
        Hibernate = 5,
        ClearTemp = 6,
        TotalTime = 7,
        TotalPay = 8,
        GetProcess = 9,
        DeleteProcess = 10,
        GetClientName = 11,

        OK = 128,
        NotOK = 129,
        ListProcess = 130,
    }


    public delegate void OnAcceptEventHandler(object sender, Socket e);
    public delegate void OnClientCalMoneyEventHandler(object sender, int h);
    public delegate void OnServerErrorHandler(object sender, ServerErrorCodes code);
    public delegate void OnClientConnectEventHandler(object sender, int h);
    public delegate void OnClientDisconnectEventHandler(object sender, int hs);
    public delegate void OnClientErrorEventHandler(object sender, int h, ClientErrorCodes code);
    public delegate void OnClientReadEventHandler(object sender, int h, byte[] bb);
    public delegate void OnClientWriteEventHandler(object sender, int h, Commands comd, uint lParam, string strParam);



    public class ServerSocket : Component
    {
        // Private vars
        private int serverPort = 8001;
        private const int maxClient = 1000;
        private String serverName = Dns.GetHostName();
        private IPAddress serverIP = IPAddress.Parse(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString());
        private TcpListener serverListener;
        //private int numberOfClient = 0;

        private ArrayList serverClients = new ArrayList();

        // Server events
        public event OnAcceptEventHandler OnAccept;
        public event OnServerErrorHandler OnServerError;
        public event OnClientConnectEventHandler OnClientConnect;
        public event OnClientCalMoneyEventHandler OnClientCalMoney;
        public event OnClientDisconnectEventHandler OnClientDisconnect;
        public event OnClientErrorEventHandler OnClientError;
        public event OnClientReadEventHandler OnClientRead;
        public event OnClientWriteEventHandler OnClientWrite;

        //public System.Timers.Timer tmListen = new System.Timers.Timer(1);
        public System.Threading.Thread thrdListen;
        public System.Threading.Thread thrdCheck;
        private int ticks = 0; // dong ho dem tik tak
        private System.Timers.Timer timerClock = new System.Timers.Timer(1000);
        private int payCount = 0;
        private int refreshCount = 0;
        public ServerSocket()
        {
            serverClients.Capacity = maxClient;
        }
        protected void Dispose(bool d)
        {
            Close();
            base.Dispose(d);
        }
        public int GetTicks()
        {
            return ticks;
        }

        public void OpenPort()
        {
            try
            {
                DecServerIP dec = new DecServerIP();
                serverListener = new TcpListener(serverIP, serverPort);
                serverListener.Start();
            }
            catch (Exception e)
            {
                if (OnServerError != null) OnServerError(this, ServerErrorCodes.OpenPort);
            }

            thrdListen = new Thread(new ThreadStart(Listen));
            thrdListen.Start();
            thrdCheck = new Thread(new ThreadStart(Check));
            thrdCheck.Start();

            timerClock.Elapsed += new ElapsedEventHandler(timerClock_OnTimer);
            timerClock.Enabled = true;

        }
        private void timerClock_OnTimer(Object sender, ElapsedEventArgs e)
        {
            payCount++;
            if (payCount >= 60)
            {
                ++ticks;
                payCount = 0;
            }
            for (int i = 0; i < serverClients.Count; ++i)
            {
                int l_tick = ticks - ((ClientInfo)serverClients[i]).Ticks;
                try
                {
                    uint pay=0;
                    //if (OnClientCalMoney != null)
                    //OnClientCalMoney(this, ((ClientInfo)serverClients[i]).GetHashCode());
                    ClientInfo cli = (ClientInfo)serverClients[i];
                    cli.realTicks = l_tick;
                    uint total_tick = (uint)(l_tick + cli.oldTime);
                    Send(cli.GetHashCode(), Commands.TotalTime, total_tick, "");
                    /// se ap gia tinh theo ngu canh tai day
                    /// Neu tinh tiep sau khi bi dut ket noi
                    /// thi khong ap gia toi thieu
                    /// Neu tinh tu dau, thi ap gia toi thieu
                    //uint pay = (uint)Algorithm.CalcPay(l_tick, ((ClientInfo)serverClients[i]).Start, DateTime.Now);
                    if (cli.feeStatus == 0)
                        pay = 0;
                    else if (cli.feeStatus==1)
                    {
                        if (cli.oldMoney <= Algorithm.PayMin && cli.isReconnect)
                        {
                            l_tick += cli.oldTime;
                            pay = (uint)Algorithm.CalcPay(l_tick, cli.Start, DateTime.Now, true);
                        } else
                            pay = (uint)Algorithm.CalcPay(l_tick, cli.Start, DateTime.Now, !cli.isReconnect);
                    }
                    cli.money = (int)pay;
                    Send(cli.GetHashCode(), Commands.TotalPay, (uint)(cli.oldMoney + cli.money), "");
                }
                catch (Exception)
                {
                }
                //MessageBox.Show((ticks - ((ClientInfo)serverClients[i]).Ticks).ToString());
            }
        }
        public void Close()
        {

            timerClock.Enabled = false;
            timerClock = null;
            for (int i = 0; i < serverClients.Count; ++i)
            {
                ClientInfo aClient = (ClientInfo)serverClients[i];
                aClient.GetSocket().Shutdown(SocketShutdown.Both);
                aClient.GetSocket().Close();
                aClient.Release();
                //serverClients.RemoveAt(i);
            }
            thrdListen.Abort(); // khong lang nghe nua
            thrdCheck.Abort(); //cham dut tien trinh
            thrdCheck = null;
            serverListener.Stop();
            //MessageBox.Show("stopping");            
        }

        private void Listen()
        {
            while (true)
            {
                try
                {
                    // lang nghe ket noi
                    Socket s = serverListener.AcceptSocket();

                    //MessageBox.Show(s.RemoteEndPoint.ToString());
                    // tao su kien ket noi
                    if (s == null) continue;
                    if (s.Connected)
                    {
                        if (OnAccept != null) OnAccept(this, s);
                        s.ReceiveTimeout = 500;
                        s.SendTimeout = 500;
                        s.SendBufferSize = 0;

                        //MessageBox.Show("ttl" + s.Ttl.ToString());

                        // tao va them mot client moi vao danh sach
                        ClientInfo newClient = new ClientInfo(s);
                        newClient.Ticks = ticks;
                        serverClients.Add(newClient);
                        //MessageBox.Show("Add them client " + serverClients.Count.ToString());
                        // tao su kien connect
                        if (OnClientConnect != null) OnClientConnect(this, newClient.GetHashCode());
                    }

                }
                catch (Exception)
                {
                    if (OnServerError != null) OnServerError(this, ServerErrorCodes.AcceptSocket);
                }
            }
        }
        //public static Object synchronizeVariable = "locking variable";
        private void Check()
        {
            while (true)
            {
                //***********************
                //modified by NghienPC
                Thread.Sleep(1);
                //***********************
                for (int i = 0; i < serverClients.Count; i++)
                {

                    ClientInfo client = (ClientInfo)serverClients[i];
                    Socket sk = client.GetSocket();
                    //lock (sk)
                    {
                        try
                        {
                            // truyen goi tin kiem tra xem client con ket noi khong
                            refreshCount++;
                            if (refreshCount >= 2000) // han che so lan goi check alive
                            {
                                refreshCount = 0;
                                if (Send(client.GetHashCode(), Commands.AreOK, 0, "AreOK") != 0)
                                {
                                    throw new SocketException();
                                }

                            }
                            if (!client.GetSocket().Connected)
                            {
                                throw new SocketException();
                            }

                            // neu con ket noi     

                            CommPack commPack = client.ReceiveAsyn();

                            //MessageBox.Show("qua");
                            if (commPack != null) // neu doc thanh cong goi tra ve
                            {
                                // neu la lenh lay ten
                                Commands cmd = (Commands)commPack.uCmd;

                                if (cmd == Commands.GetClientName)
                                    client.ClientName = commPack.strParam; // ten may                                

                                if (cmd == Commands.GetProcess)
                                {
                                    //MessageBox.Show(commPack.strParam);

                                }
                                // phat sinh su kien client write;
                                if (OnClientWrite != null)
                                    OnClientWrite(this, client.GetHashCode(), cmd, commPack.lParam, commPack.strParam);
                            }
                            else
                            {

                            }

                        }
                        catch (SocketException e)
                        {
                            //MessageBox.Show(e.ToString());
                            //lock (client)
                            {
                                if (OnClientDisconnect != null) OnClientDisconnect(this, client.GetHashCode());
                                client.Release();
                                if (i < serverClients.Count) serverClients.RemoveAt(i);
                                //Monitor.PulseAll(client);
                                //Monitor.Wait(client);
                            }
                        }
                        catch (Exception)
                        { }
                        //Monitor.PulseAll(sk);
                        //Monitor.Wait(sk);
                    }

                }
            } // while

        }

        public int Send(int clientHash, Commands comd, uint lPar, string str)
        {
            ClientInfo client = GetClientByHash(clientHash);
            //lock (client)
            {
                if (client == null) return -1;
                try
                {
                    // gui tin
                    client.Send(new CommPack((uint)comd, lPar, str));
                    return 0;
                }
                catch (Exception)
                {
                    /*
                    //MessageBox.Show("err send");
                    // co loi, sinh su kien loi
                    if (OnClientError != null) OnClientError(this, clientHash, ClientErrorCodes.Lost);
                    // sinh su kien client disconnect
                    if (OnClientDisconnect != null) OnClientDisconnect(this, clientHash);                    
                    RemoveByHash(clientHash);
                    client.Release();
                     */
                    return -1;
                }
                //Monitor.PulseAll(client);
                //Monitor.Wait(client);
            }
            return 0;
        }

        private void RemoveByHash(int clientHash)
        {
            for (int i = 0; i < serverClients.Count; ++i)
                if (serverClients[i].GetHashCode() == clientHash)
                {
                    serverClients.RemoveAt(i);
                    return;
                }
            return;
        }

        public ClientInfo GetClientByHash(int clientHash)
        {
            for (int i = 0; i < serverClients.Count; ++i)
                if (serverClients[i].GetHashCode() == clientHash)
                {
                    return (ClientInfo)serverClients[i];
                }
            return null;
        }
    }
    public class ClientInfo
    {
        //private Socket s = null; 
        private Socket s = null;

        private String clientName;
        private String displayName;
        private int status;
        private int countTicks = 0;
        private DateTime start;
        public int money;
        public int realTicks;
        public int oldMoney = 0;
        public int oldTime = 0;
        public int feeStatus;
        private SockComm clientSockComm;
        public bool isReconnect = false;
        public int clientStatus = 0;        
        public ClientInfo(Socket _s)
        {
            s = _s;
            // tao mot doi tuong sockcomm de doc, ghi du lieu
            clientSockComm = new SockComm(s);
            start = DateTime.Now;
        }
        public void Release()
        {
            //if ((t != null) && (t.IsAlive)) t.Abort();
            if ((s != null) && (s.Connected))
                s.Close();

        }
        public DateTime Start
        {
            set
            {
                start = value;
            }
            get
            {
                return start;
            }
        }
        public int Ticks
        {
            set
            {
                countTicks = value;
            }
            get
            {
                return countTicks;
            }
        }

        public int Status
        {
            set
            {
                status = value;
            }
            get
            {
                return status;
            }
        }
        public String ClientName
        {
            set
            {
                clientName = value;
            }
            get
            {
                return clientName;
            }
        }
        public String IP
        {
            get
            {
                String r = s.RemoteEndPoint.ToString();
                return r.Substring(0, r.IndexOf(':'));
            }
        }
        public int Port
        {
            get
            {
                String r = s.RemoteEndPoint.ToString();
                return Int32.Parse(r.Substring(r.IndexOf(':') + 1));
            }

        }
        // truyen tin
        public int Send(CommPack cp)
        {

            clientSockComm.Send(cp);
            return 0;
        }
        // nhan tin
        public CommPack Receive()
        {
            return clientSockComm.Receive();
        }
        public CommPack ReceiveAsyn()
        {
            return clientSockComm.ReceiveAsyn();
        }
        public Socket GetSocket()
        {

            return s;
        }
    }
}

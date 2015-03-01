using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace NetCafe
{
    class DecServerIP
    {
        private Socket sock;
        private IPEndPoint iep;
        private EndPoint ep;
        private Thread sockListen;
        private byte[] data;
        private int recv;
        //private string stringData;
        
        public DecServerIP()
        {
            sock = new Socket(AddressFamily.InterNetwork,
                     SocketType.Dgram, ProtocolType.Udp);
            iep = new IPEndPoint(IPAddress.Any, 8002);
            sock.Bind(iep);
            ep = (EndPoint)iep;
            //Console.WriteLine("Ready to receive...");
            data = new byte[1024];
            sockListen = new Thread(ConnListent);
            sockListen.Start();
        }
        private void ConnListent()
        {
            byte[] bOK = new byte[2];
            bOK[0] = 0xFF;
            bOK[1] = 0xFF;
            while (true)
            {
                
                recv = sock.ReceiveFrom(data, ref ep);
                /*
                stringData = Encoding.ASCII.GetString(data, 0, recv);            
                Console.WriteLine("received: {0}  from: {1}",
                                      stringData, ep.ToString());
                  */                  
                sock.SendTo(bOK, ep);                
            }
        }
    }
}

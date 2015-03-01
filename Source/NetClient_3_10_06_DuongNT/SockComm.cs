/**
Class: SockComm - Socket Communication
nhiem vu: truyen - nhan thong tin qua socket theo goi tin 
 * **/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
namespace NetCafeClient
{
    // lop giao thuc goi tin truyen di
    public class CommPack
    {
        public const uint SIGN = 0x4D534346;
        public uint uSign = SIGN; //  Chu ki: "MSCF"
        public uint uCmd; // command
        public uint lParam; // long int param
        public string strParam; // string param
        public CommPack(uint cmd, uint lpr, string s)
        {
            // khoi tao cac tham so
            uSign = SIGN; // chu ki
            uCmd = cmd; // command
            lParam = lpr;// tham so
            strParam = s; // string param;
        }
    }
    public class SockComm
    {
        private StreamReader strReader; // luong doc socket
        private StreamWriter strWriter; // luong ghi socket
        private NetworkStream sockStream;
        private Socket socketRef;  
        public SockComm(Socket sock)
        {
            // khoi tao luong doc
            socketRef = sock;
            NetworkStream netStr = new NetworkStream(sock);
            sockStream = netStr;
            strReader = new StreamReader(netStr);
            // khoi tao luong ghi
            strWriter = new StreamWriter(netStr);
            //bufferStream = new BufferedStream(netStr);
        }
        public SockComm(NetworkStream str)
        {
            // khoi tao luong doc
            strReader = new StreamReader(str);
            // khoi tao luong ghi
            strWriter = new StreamWriter(str);
            sockStream = str;
        }
        
        public void Send(CommPack cp)
        {
            
            // gui strParam
            strWriter.WriteLine(cp.uSign.ToString());
            strWriter.WriteLine("0" + cp.uCmd.ToString());
            strWriter.WriteLine("0" + cp.lParam.ToString());
            if (cp.strParam.CompareTo("") == 0)
                strWriter.WriteLine(" ");
            else
                strWriter.WriteLine(cp.strParam);
            
            strWriter.Flush(); // gui di
        }
        public CommPack ReceiveAsyn()
        {
            if (sockStream.DataAvailable == false) return null;
            return Receive();
        }
        // doc goi tin tra ve
        public CommPack Receive()
        {
            try
            {
                                
                //CommPack cp = new CommPack()
                uint uCmd, uSign, lPar;
                string str;
                
                string s = strReader.ReadLine();
                
                if ((s == null) || (s == "")) return null;
                uSign = UInt32.Parse(s);
                // * */
                // kiem tra chu ki
                if (uSign != CommPack.SIGN)
                    return null;
                //MessageBox.Show(uSign.ToString());

                s = strReader.ReadLine();
                //MessageBox.Show(s);
                uCmd = UInt32.Parse(s);
                s = strReader.ReadLine();
                //MessageBox.Show(s); 
                lPar = UInt32.Parse(s);

                str = strReader.ReadLine();
                // tra ve du lieu doc duoc
                return new CommPack(uCmd, lPar, str);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}

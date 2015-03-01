using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections;
namespace NetCafe
{
    public class ClientHistory
    {
        private ArrayList list;
        public ClientHistory()
        {
            list = new ArrayList();            
        }        
        
        public ClientInformDetails Mydify(string ip, DateTime start)
        {
            int i = 0;
            ClientInformDetails c = null;
            for (i = 0; i < list.Count; i++)
                if ((c = (ClientInformDetails)list[i]).clientIp.CompareTo(ip) == 0)
                    break;
            if (i >= list.Count)
            { // khong tim thay
                c = new ClientInformDetails(ip, 0, 0);
                c.start = start;
                AddClient(c);
                return null;
            }
            else return c;

        }
        public void Remove(string ip) // loai phan tu
        {
            for (int i = 0; i < list.Count; i++)
                if (((ClientInformDetails)list[i]).clientIp.CompareTo(ip) == 0)
                {
                    list.RemoveAt(i);
                    return ;
                }
        }

        public void AddClient(ClientInformDetails cl)
        {
            list.Add(cl);
        }
        public ClientInformDetails Retrieve(string ip)
        {
            for (int i = 0; i < list.Count; i++)
                if (((ClientInformDetails)list[i]).clientIp.CompareTo(ip) == 0)
                    return (ClientInformDetails)list[i];
            return null;
        }
    }
    public class ClientInformDetails
    {
        public string clientIp;
        public int time;
        public int money;
        public bool NeedClear;
        public DateTime start;
        public int clientStatus = 0;
        public int oldFeeStatus;
        public ClientInformDetails(string ip, int t, int mon)
        {
            NeedClear = false;
            clientIp = ip;
            time = t;
            money = mon;
        }
        // xoa thong tin ve tien va thoi gian
        public void clearAll()
        {            
            time = 0;
            money = 0;
        }

    }
}

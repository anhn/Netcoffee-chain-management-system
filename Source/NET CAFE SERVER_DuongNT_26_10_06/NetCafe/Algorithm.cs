using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace NetCafe
{
    struct SaleOff
    {
        public DateTime begin;
        public DateTime end;
        public int off;
    }
    class Algorithm
    {
        public static int PayByHour;
        public static int PayByMinute;
        public static int Vat;
        public static int RoundBy;
        public static int PayMin;
        public static int PayType;
        public static int[,] WeekPrice = new int[24, 7];

        public static SaleOff[] Offs;

        public static String Encrypt(String s)
        {
            return s;
        }
        public static String Decrypt(String s)
        {
            return (s);
        }
        public static String EncryptFile(String s)
        {
            return (s);
        }
        public static String DecryptFile(String s)
        {
            return (s);
        }
        public static System.Array ResizeArray(System.Array oldArray, int newSize)
        {
            int oldSize = oldArray.Length;
            System.Type elementType = oldArray.GetType().GetElementType();
            System.Array newArray = System.Array.CreateInstance(elementType, newSize);
            int preserveLength = System.Math.Min(oldSize, newSize);
            if (preserveLength > 0)
                System.Array.Copy(oldArray, newArray, preserveLength);
            return newArray;
        }
        public static void ReadInput()
        {
            //FileStream fi = new FileStream("banggia.txt", FileMode.Open);
            StreamReader sr = new StreamReader("banggia.txt");
            PayType = Int32.Parse(sr.ReadLine());
            PayByHour = Int32.Parse(sr.ReadLine());
            PayByMinute = Int32.Parse(sr.ReadLine());
            PayMin = Int32.Parse(sr.ReadLine());
            Vat = Int32.Parse(sr.ReadLine());
            RoundBy = Int32.Parse(sr.ReadLine());
            for (int i = 0; i < 24; ++i)
                for (int j = 0; j < 7; ++j)
                    WeekPrice[i, j] = Int32.Parse(sr.ReadLine());
            Offs = new SaleOff[0];
            while (!sr.EndOfStream)
            {
                 Offs = (SaleOff[])ResizeArray(Offs,Offs.Length+1);
                 Offs[Offs.Length - 1].begin = DateTime.Parse(sr.ReadLine());
                 Offs[Offs.Length - 1].end = DateTime.Parse(sr.ReadLine());
                 Offs[Offs.Length - 1].off = Int32.Parse(sr.ReadLine());
            }
            sr.Close();
        }
        public static void SaveInput()
        {
            StreamWriter sw = new StreamWriter("banggia.txt");
            sw.WriteLine(PayType.ToString());
            sw.WriteLine(PayByHour.ToString());
            sw.WriteLine(PayByMinute.ToString());
            sw.WriteLine(PayMin.ToString());
            sw.WriteLine(Vat.ToString());
            sw.WriteLine(RoundBy.ToString());
            for (int i = 0; i < 24; ++i)
                for (int j = 0; j < 7; ++j)
                    sw.WriteLine(WeekPrice[i,j].ToString());
            for (int i = 0; i < Offs.Length; ++i)
            {
                sw.WriteLine(Offs[i].begin.ToString());
                sw.WriteLine(Offs[i].end.ToString());
                sw.WriteLine(Offs[i].off.ToString());
            }
            sw.Flush();
            sw.Close();
        }
        public static int CalcPay(int TotalTime, DateTime start, DateTime finish, bool damn)
        {
            ReadInput();
            int TotalPay = 0;
            int saleoff = 10000000;
            for (int i = 0; i < Offs.Length; ++i)
            {
                if ((start.CompareTo(Offs[i].begin) >= 0) && (start.CompareTo(Offs[i].end) <= 0) && (saleoff > Offs[i].off))
                {
                    saleoff = Offs[i].off;
                }
            }
            if (saleoff < 10000000)
            {
                TotalPay = TotalTime * saleoff / 60;
            }
            //else
            //{
                if (PayType == 0)
                {
                    TotalPay = TotalTime * PayByMinute;
                }
                else// if (PayType == 1)
                {
                    TotalPay -= (start.Minute * WeekPrice[start.Hour, (int)start.DayOfWeek] / 60);
                    TotalPay -= ((60 - finish.Minute) * WeekPrice[finish.Hour, (int)finish.DayOfWeek] / 60);
                    start = new DateTime(start.Year, start.Month, start.Day, start.Hour, 0, 0);
                    finish = new DateTime(finish.Year, finish.Month, finish.Day, finish.Hour, 0, 0);
                    finish = finish.AddHours(1);
                    while (DateTime.Compare(start, finish) < 0)
                    {
                        bool off = false;
                        /* *
                        for (int i = 0; i < Offs.Length; ++i)
                        {
                            if ((start.CompareTo(Offs[i].begin) >= 0) && (start.CompareTo(Offs[i].end) <= 0))
                            {
                                TotalPay += Offs[i].off;
                                off = true;
                                break;
                            }
                        }
                         * */
                        if (!off) TotalPay += WeekPrice[start.Hour, (int)start.DayOfWeek];
                        start = start.AddHours(1);
                    }
                }
            //}
            //TotalPay += (int)((Vat*TotalPay)/100);
                for (int i = 0; i < Offs.Length; ++i)
                {
                    if ((start.CompareTo(Offs[i].begin) >= 0) && (start.CompareTo(Offs[i].end) <= 0))
                    {
                        TotalPay *= (100-Offs[i].off);
                        TotalPay /= 100;
                        //off = true;
                        break;
                    }
                }
                //if ((TotalTime == 3)||(TotalTime == 2)) MessageBox.Show(TotalPay.ToString());
            if (RoundBy > 0)
            if ((TotalPay % RoundBy) > 0)
                TotalPay = RoundBy*((int)(TotalPay/RoundBy))+RoundBy;
            if (damn)
                if (TotalPay < PayMin) TotalPay = PayMin;
            return TotalPay;
        }
    }
}

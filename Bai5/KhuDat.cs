using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Bai5
{
    internal class KhuDat
    {
        protected string DiaDiem;
        protected double GiaBan;
        protected double DienTich;
        public virtual void nhap()
        {
            Console.WriteLine("Nhap vao dia diem.");
        input1:
            try
            {
                DiaDiem = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Dia diem khong hop le! Xin nhap lai!");
                goto input1;
            }
        input2:
            try
            {
                do
                {
                    GiaBan = Convert.ToDouble(Console.ReadLine());
                    if (GiaBan <= 0) Console.WriteLine("Gia ban khong the thap hon 0! Xin nhap lai.");
                } while (GiaBan <= 0);
                
            }
            catch
            {
                Console.WriteLine("Gia ban khong hop le! Xin nhap lai!");
                goto input2;
            }
        input3:
            try
            {      
                do
                {
                    DienTich = Convert.ToDouble(Console.ReadLine());
                    if (DienTich < 0) Console.WriteLine("Dien tich khong the nho hon 0! Xin nhap lai.");
                } while (DienTich <= 0);
            }
            catch
            {
                Console.WriteLine("Dien tich khong hop le! Xin nhap lai!");
                goto input3;
            }
        }
        public virtual void xuat()
        {
            Console.Write("Dia diem: " + DiaDiem + " | Gia ban: " + GiaBan + " | Dien tich: " + DienTich+" ");
        }
        public string diadiem
        {
            get
            {
                return DiaDiem;
            }
        }
        public double giaban
        {
            get
            {
                return GiaBan;
            }
        }
        public double dientich
        {
            get
            {
                return DienTich;
            }
        }
    }
}

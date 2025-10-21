using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5
{
    internal class NhaPho:KhuDat
    {
        private int NamXayDung;
        private int SoTang;
        public override void nhap()
        {
            base.nhap();
            Console.WriteLine("Nhap vao so nam xay dung cua ngoi nha.");
        input1:
            try
            {
                do
                {
                    NamXayDung = Convert.ToInt32(Console.ReadLine());
                    if (NamXayDung <= 0) Console.WriteLine("So nam khong hop le! Xin nhap lai.");
                } while (NamXayDung <= 0);
            }
            catch
            {
                Console.WriteLine("Input khong hop le! Xin nhap lai so nam ngoi nha duoc xay dung.");
                goto input1;
            }
            Console.WriteLine("Nhap vao so tang cua ngoi nha.");
        input2:
            try
            {
                do
                {
                    SoTang = Convert.ToInt32(Console.ReadLine());
                    if (SoTang <= 0) Console.WriteLine("So tang cua ngoi nha khong hop le! Xin nhap lai.");
                } while (SoTang <= 0);
            }
            catch
            {
                Console.WriteLine("Input khong hop le! Xin nhap lai so tang cua ngoi nha.");
                goto input2;
            }
        }
        public override void xuat()
        {
            base.xuat();
            Console.Write("| Nam xay dung: " + NamXayDung + " | So tang: " + SoTang + "\n");
        }
        public int namxaydung
        {
            get
            {
                return NamXayDung;
            }
        }
    }
}

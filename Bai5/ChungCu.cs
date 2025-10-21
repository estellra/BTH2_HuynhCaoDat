using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5
{
    internal class ChungCu:KhuDat
    {
        private int Tang;
        public override void nhap()
        {
            base.nhap();
            Console.WriteLine("Nhap vao so tang cua chung cu.");
        input:
            try
            {
                do
                {
                    Tang = Convert.ToInt32(Console.ReadLine());
                    if (Tang <= 0) Console.WriteLine("So tang cua chung cu khong hop le! Xin nhap lai.");
                } while (Tang <= 0);
            }
            catch
            {
                Console.WriteLine("Input khong hop le! Xin nhap lai so tang cua chung cu.");
                goto input; 
            }
        }
        public override void xuat()
        {
            base.xuat();
            Console.Write( "| So tang: " + Tang + "\n");
        }
    }
}

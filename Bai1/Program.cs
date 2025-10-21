using System;

public class calendar
{
    private int Thang;
    private int Nam;
    public void nhap()
    {
     Console.WriteLine("Nhap vao thang/nam de xem lich!");
     input1:
        try
        {
            do
            {
                Thang = Convert.ToInt32(Console.ReadLine());
                if (Thang > 12 || Thang < 1) Console.WriteLine("Thang khong hop le! Xin nhap lai.");
            } while (Thang > 12 || Thang < 1);
            
        }
        catch
        {
            Console.WriteLine("Input khong dung dinh dang! Xin nhap lai thang.");
            goto input1;
        }
      input2:
        try
        {
            do
            {
                Nam = Convert.ToInt32(Console.ReadLine());
                if (Nam < 1) Console.WriteLine("Nam khong hop le! Xin nhap lai");
            } while (Nam < 1);
        }
        catch
        {
            Console.WriteLine("Input khong dung dinh dang! Xin nhap lai nam.");
            goto input2;
        }
    }
    private int NgayTrongThang()
    {
        int[] ngay = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if ((Nam % 4 == 0 && Nam % 100 != 0) || Nam % 400 == 0) ngay[1]= 29;
        return ngay[Thang - 1];
    }

    private int TinhThu(int songay)
    {   
        if(Thang==1)
        {
            Thang = 13;
            Nam--;
        }
        else if(Thang==2)
        {
            Thang = 14;
            Nam--;
        }
        int s = songay + (13 * (Thang + 1)) / 5 + Nam%100+  (Nam % 100)/4 +   (Nam / 100)/4+5*(Nam/100);
        s %= 7;
        return s;
    }

    public void xuat()
    {
        Console.WriteLine("Sun " + " Mon " + " Tue " + " Wed " + " Thu " + " Fri " + " Sat ");
        string[][] lich = new string[5][];
        for (int i = 0; i < 5; i++) lich[i] = new string[7];
        for(int i=0;i<5;i++)
        {
            for(int j=0;j<7;j++)
            {
                lich[i][j] = " ";
            }
        }
        int pos=-1;
            switch(TinhThu(1))
            {
                case 0:
                lich[0][6] = "1";
                pos = 6;
                    break;
                case 1:
                lich[0][0] = "1";
                pos = 0;
                    break;
                case 2:
                lich[0][1] = "1";
                pos = 1;
                    break;
                case 3:
                lich[0][2] = "1";
                pos = 2;
                    break;
                case 4:
                lich[0][3] = "1";
                pos = 3;
                    break;
                case 5:
                lich[0][4] = "1";
                pos = 4;
                    break;
                case 6:
                lich[0][5] = "1";
                pos = 5;
                    break;
            }
            int d = 2;
            for(int i=0;i<5;i++)
            {
                for(int j=0;j<7;j++)
                {
                    if (pos == 6 && i==0) break;
                    if (i == 0&&j<=pos) j = pos + 1;
                    lich[i][j] =d.ToString();
                    d++;
                    if (d > NgayTrongThang()) break;
                }
                if (d > NgayTrongThang()) break;
            }
   
       for(int i=0; i<5;i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Console.Write(lich[i][j]);
                if (lich[i][j].Length==1) Console.Write("    ");
                else Console.Write("   ");
            }
            Console.Write("\n");
        }
    }

}

class program
{
    static void Main()
    {
        calendar a = new calendar();
        a.nhap();
        a.xuat();
    }
}
using System;
using System.Collections.Generic;

public class PhanSo
{
    private int tu;
    private int mau;
    public PhanSo()
    {
        tu = 1;
        mau = 1;
    }
    public PhanSo(int a,int b)
    {
        tu = a;
        if (b != 0) mau = b;
        else mau = 1;
        int t = ucln(tu,mau);
        tu /= t;
        mau /= t;
    }
    public PhanSo(double a)
    {
        int mau = 1;
          while((int)a!=a)
        {
            a *= 10;
            mau *= 10;
        }
        tu = (int)a;
        this.mau = mau;
        int t=ucln(tu, this.mau);
        tu /= t;
        this.mau /= t;
    }
    public int ucln(int a,int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        if (a == 0 && b == 0) return 1;
        if (a == 0 || b == 0) return a + b;
        while(a!=b)
        {
            if (a > b) a = a - b;
            else b = b - a;
        }
        return a;
    }

    public static PhanSo operator+(PhanSo a,PhanSo b)
    {
        int ms = a.mau * b.mau;
        int ts = a.tu * b.mau + a.mau * b.tu;
        PhanSo s = new PhanSo(ts,ms);
        return s;
    }
    public static PhanSo operator -(PhanSo a, PhanSo b)
    {
        int ms = a.mau * b.mau;
        int ts = a.tu * b.mau - a.mau * b.tu;
        PhanSo s = new PhanSo(ts, ms);
        return s;
    }
    public static PhanSo operator *(PhanSo a, PhanSo b)
    {
        int ms = a.mau * b.mau;
        int ts = a.tu * b.tu;
        PhanSo s = new PhanSo(ts, ms);
        return s;
    }
    public static PhanSo operator /(PhanSo a, PhanSo b)
    {
        int ms = a.mau * b.tu;
        int ts = a.tu * b.mau;
        PhanSo s = new PhanSo(ts, ms);
        return s;
    }
    public static explicit operator double(PhanSo ps)
    {
        return (double)ps.tu / ps.mau;
    }
    public void NhapPhanSo()
    {
    input1:
        try
        {
            tu = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Tu so khong hop le. Xin nhap lai!");
            goto input1;
        }
    input2:
        try
        {
            do
            {
                mau = Convert.ToInt32(Console.ReadLine());
                if (mau == 0) Console.WriteLine("Mau so khong the bang 0! Xin thu lai.");
            } while (mau == 0);
        }
        catch
        {
            Console.WriteLine("Mau so khong hop le. Xin nhap lai!");
            goto input2;
        }
        int t = ucln(tu,mau);
        tu /= t;
        mau /= t;
    }
    public void xuat()
    {
        if (tu == 0 && mau != 0)
        {
            Console.Write(0+" ");
            return;
        }
        if (tu == 0 && mau == 0)
        {
            Console.Write("Loi phan so! ");
            return;
        }
        if((tu<0&&mau<0)||(tu>0&&mau<0))
        {
            tu *= -1;
            mau *= -1;
        }
        if (mau == 1) Console.Write(tu+" ");
        else Console.Write(tu+"/"+mau+" ");
    }
    public void PhanSoLonNhat(List<PhanSo> ds)
    {
        if(ds.Count==0)
        {
            Console.WriteLine("Day khong ton tai phan so nao!");
            return;
        }
        double maxval = double.MinValue;
        PhanSo maxps = new PhanSo();
        foreach(var ps in ds)
        {
            if ((double)ps > maxval)
            {
                maxval = (double)ps;
                maxps = ps;
            }
        }
        Console.Write("Phan so lon nhat ton tai trong day la "); maxps.xuat();

    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Chao mung den voi chuong trinh xu ly phan so^^.\n----------------------------------------------");
        Console.WriteLine("Chon 1 de nhap vao 2 phan so va tinh tong, hieu, tich, thuong cua chung.\n" +
            "Chon 2 de nhap vao 1 day cac phan so roi xuat day cac phan so theo thu tu tang dan va tim phan so lon nhat.\n" +
            "Chon 0 de ket thuc chuong trinh....");
        int choice = -1;
        while(choice!=0)
        {
        choose:
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Lua chon khong hop le! Xin chon lai.");
                goto choose;
            }
            switch(choice)
            {
                case 1:
                    PhanSo a = new PhanSo();
                    PhanSo b = new PhanSo();
                    Console.WriteLine("Nhap vao phan so thu 1.");
                    a.NhapPhanSo();
                    Console.WriteLine("Nhap vao phan so thu 2.");
                    b.NhapPhanSo();
                    Console.Write("Tong cua 2 phan so "); a.xuat(); Console.Write("va "); b.xuat(); Console.Write("= ");
                    PhanSo tong = new PhanSo();
                    tong = a + b;
                    tong.xuat(); Console.Write("\n");
                    Console.Write("Hieu cua 2 phan so "); a.xuat(); Console.Write("va "); b.xuat(); Console.Write("= ");
                    PhanSo hieu = new PhanSo();
                    hieu = a - b;
                    hieu.xuat(); Console.Write("\n");
                    Console.Write("Tich cua 2 phan so "); a.xuat(); Console.Write("va "); b.xuat(); Console.Write("= ");
                    PhanSo tich = new PhanSo();
                    tich = a * b;
                    tich.xuat(); Console.Write("\n");
                    Console.Write("Thuong cua 2 phan so "); a.xuat(); Console.Write("va "); b.xuat(); Console.Write("= ");
                    PhanSo thuong = new PhanSo();
                    thuong = a / b;
                    thuong.xuat(); Console.Write("\n");
                    break;
                case 2:
                    List<PhanSo> dsps = new List<PhanSo>();
                    PhanSo c = new PhanSo();
                    Console.WriteLine("Nhap vao day cac phan so.");
                    int stop = 2;
                    while(stop==2)
                    {
                        PhanSo t = new PhanSo();
                        Console.WriteLine("Nhap vao phan so.");
                        t.NhapPhanSo();
                        dsps.Add(t);
                        Console.WriteLine("Ket thuc viec nhap cac phan so?\n1. Co\n2. Khong");
                    choice2:
                        try
                        {
                            stop = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Lua chon khong hop le. Xin thu lai!");
                            goto choice2;
                        }

                    }
                    c.PhanSoLonNhat(dsps);
                    Console.WriteLine("Day cac phan so ban da nhap la: ");
                    foreach (var ps in dsps)
                    {
                        ps.xuat();
                    }
                    Console.WriteLine("\nDay cac phan so ban da nhap sau khi sap xep theo thu tu tang dan la: ");
                    dsps.Sort((a, b) =>
                    {
                        double ps1 = (double)a;
                        double ps2 = (double)b;
                        return ps1.CompareTo(ps2);  
                    });
                    foreach (var ps in dsps)
                    {
                        ps.xuat();
                    }
                    break;
                case 0:
                    Console.WriteLine("Ket thuc chuong trinh.....");
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le! Xin chon lai.");
                    break;
            }
        }
    }
}
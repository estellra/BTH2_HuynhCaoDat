using Bai5;
using System;
using System.Diagnostics;
class CongTy
{
    List<KhuDat> DS;
    public void Nhap()
    {
        DS = new List<KhuDat>();
        int choice = 1;
        Console.WriteLine("Nhap vao danh sach thong tin cua cac khu dat, nha pho, chung cu.");
        while(choice!=0)
        {
            Console.WriteLine("Chon 1 de nhap vao thong tin cua khu dat.\n" +
                "Chon 2 de nhap vao thong tin cua nha pho.\n" +
                "Chon 3 de nhap vao thong tin cua chung cu.\n" +
                "Chon 0 de ket thuc qua trinh nhap danh sach.\n");
        input:
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Lua chon khong hop le! Xin chon lai.");
                goto input;
            }
            KhuDat t = new KhuDat();
            switch(choice)
            {
                case 1:
                    t.nhap();
                    DS.Add(t);
                    break;
                case 2:
                    t = new NhaPho();
                    t.nhap();
                    DS.Add(t);
                    break;
                case 3:
                    t = new ChungCu();
                    t.nhap();
                    DS.Add(t);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le! Xin chon lai.");
                    break;
            }
        }
    }
    public void TongGiaBan()
    {
        double dat = 0,nha=0,cc=0;
        foreach(var a in DS)
        {
            if(a.GetType()==typeof(KhuDat))
            {
                dat += a.giaban;
            }
            else if(a.GetType()==typeof(NhaPho))
            {
                nha += a.giaban;
            }
            else if(a.GetType()==typeof(ChungCu))
            {
                cc += a.giaban;
            }
        }
        Console.WriteLine("Tong gia ban cua khu dat la: " + dat);
        Console.WriteLine("Tong gia ban cua nha pho la: " + nha);
        Console.WriteLine("Tong gia ban cua chung cu la: " + cc);
        Console.WriteLine("Tong gia ban cua 3 loai la: " + (cc + nha + dat));      
    }

    public void xuat()
    {
        List<KhuDat> dat = new List<KhuDat>();
        List<KhuDat> nha = new List<KhuDat>();
        List<KhuDat> cc = new List<KhuDat>();
        foreach (var a in DS)
        {
            if (a.GetType() == typeof(KhuDat)) dat.Add(a);
            else if (a.GetType() == typeof(NhaPho)) nha.Add(a);
            else if (a.GetType() == typeof(ChungCu)) cc.Add(a);
        }
        if (dat.Count == 0) Console.WriteLine("Cong ty hien khong co khu dat nao!");
        else
        {
            Console.WriteLine("Cac khu dat trong cong ty la: ");
            foreach (var i in dat)
            {
                i.xuat();
                Console.Write("\n");
            }
        }
        if (nha.Count == 0) Console.WriteLine("Cong ty hien khong co nha pho nao!");
        else
        {
            Console.WriteLine("Cac nha pho hien co trong cong ty la: ");
            foreach (var i in nha) i.xuat();
        }
        if (cc.Count == 0) Console.WriteLine("Cong ty hien khong co chung cu nao!");
        else
        {
            Console.WriteLine("Cac chung cu hien co trong cong ty la: ");
            foreach (var i in cc) i.xuat();
        }
    }
    public void KhuDatVaNhaPhoTheoDK()
    {
        List<KhuDat> dat = new List<KhuDat>();
        List<KhuDat> nha = new List<KhuDat>();
        foreach(var a in DS)
        {
            if(a.GetType()==typeof(KhuDat))
            {
                if (a.dientich > 100) dat.Add(a);
            }
            else if(a.GetType()==typeof(NhaPho))
            {
                if (a.dientich > 60 && a is NhaPho np)
                {
                    if (np.namxaydung >= 2019) nha.Add(a);
                }
            }
        }
        if (dat.Count == 0) Console.WriteLine("Cong ty hien khong co khu dat nao thoa man dieu kien!");
        else
        {
            Console.WriteLine("Cac khu dat co dien tich >100m2 la: ");
            foreach (var i in dat)
            {
                i.xuat();
                Console.Write("\n");
            }
        }
        if (nha.Count == 0) Console.WriteLine("Cong ty hien khong co nha pho nao thoa man dieu kien!");
        else
        {
            Console.WriteLine("Cac nha pho co dien tich > 60m2 va nam xay dung >=2019 la: ");
            foreach (var i in nha) i.xuat();
        }
    }
    public void TimKiem()
    {
        Console.WriteLine("Nhap vao dia diem, gia thanh, dien tich mong muon de tim kiem nha pho/chung cu phu hop!");
        string diadiem;
        double giathanh, dt;
    input1:
        try
        {
            diadiem = Console.ReadLine();
        }
        catch
        {
            Console.WriteLine("Dia diem nhap vao khong hop le! Xin nhap lai.");
            goto input1;
        }
    input2:
        try
        {
            do
            {
                giathanh = Convert.ToDouble(Console.ReadLine());
                if (giathanh < 0) Console.WriteLine("Gia khong the nho hon 0! Xin nhap lai.");
            }while(giathanh < 0);
        }
        catch
        {
            Console.WriteLine("Gia ca nhap vao khong hop le! Xin nhap lai.");
            goto input2;
        }
    input3:
        try
        {
            do
            {
                dt = Convert.ToDouble(Console.ReadLine());
                if (dt < 0) Console.WriteLine("Dien tich khong the nho hon 0! Xin nhap lai.");
            } while (dt < 0);
        }
        catch
        {
            Console.WriteLine("Dien tich nhap vao khong hop le! Xin nhap lai.");
            goto input3;
        }
        List<KhuDat> kq = new List<KhuDat>();
        foreach(var a in DS)
        {
            if (a.GetType() == typeof(KhuDat)) continue;
            if (!(a.diadiem.Contains(diadiem,StringComparison.OrdinalIgnoreCase))&&
                !(diadiem.Contains(a.diadiem, StringComparison.OrdinalIgnoreCase))) continue;
            if (a.giaban > giathanh) continue;
            if (a.dientich < dt) continue;
            kq.Add(a);
        }
        if (kq.Count == 0) Console.WriteLine("Khong co nha pho/chung cu nao cua cong ty phu hop dieu kien:(");
        else
        {
            Console.WriteLine("Danh sach cac nha pho/chung cu thoa man dieu kien la: ");
            foreach (var i in kq) i.xuat();
        }
    }
}


class Program
{
    static void Main()
    {
        CongTy DaiPhu = new CongTy();
        DaiPhu.Nhap();
        Console.WriteLine("Chuong trinh quan ly cong ty^^\n--------------------------------------------");
        Console.WriteLine("Chon 1 de xem danh sach da nhap\nChon 2 de xem tong gia ban cac bat dong san cua cong ty\n" +
            "Chon 3 de tim cac khu dat/nha pho phu hop dieu kien\nChon 4 de tim kiem theo yeu cau cac nha pho/ chung cu\n" +
            "Chon 0 de ket thuc chuong trinh.");
        int choice = -1;
        while (choice != 0)
        {
        choose:
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Lua chon khong hop le. Xin chon lai!");
                goto choose;
            }
            switch (choice)
            {
                case 1:
                    DaiPhu.xuat();
                    break;
                case 2:
                    DaiPhu.TongGiaBan();
                    break;
                case 3:
                    DaiPhu.KhuDatVaNhaPhoTheoDK();
                    break;
                case 4:
                    DaiPhu.TimKiem();
                    break;
                case 0:
                    Console.WriteLine("Ket thuc chuong trinh.....");
                    return;
                default:
                    Console.WriteLine("Lua chon khong hop le! Xin chon lai");
                    break;
            }
        }
    }
}
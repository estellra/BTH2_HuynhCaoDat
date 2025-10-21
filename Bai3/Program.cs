using System;

class matran
{
    private int hang;
    private int cot;
    private int[][] mt;
    public void nhap()
    {
    input1:
        try
        {
            Console.WriteLine("Nhap vao so hang cua ma tran: ");
            do
            {
                hang = Convert.ToInt32(Console.ReadLine());
                if (hang < 1) Console.WriteLine("So hang khong hop le! Xin nhap lai.");
            } while (hang < 1);
        }
        catch
        {
            Console.WriteLine("Input nhap vao khong dung! Xin thu lai.");
            goto input1;
        }
    input2:
        try
        {
            Console.WriteLine("Nhap vao so cot cua ma tran: ");
            do
            {
                cot = Convert.ToInt32(Console.ReadLine());
                if (cot < 1) Console.WriteLine("So cot khong hop le! Xin nhap lai.");
            } while (cot < 1);
        }
        catch
        {
            Console.WriteLine("Input nhap vao khong dung! Xin thu lai.");
            goto input2;
        }
        mt = new int[hang][];
        for(int i=0;i<hang;i++)
        {
            mt[i] = new int[cot];
        }
        Console.WriteLine("Nhap vao cac phan tu cua ma tran.");    
            for (int i = 0; i < hang; i++)
            {
                for(int j=0;j<cot;j++)
                {
                input3:
                    try
                    {
                        mt[i][j] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Phan tu nhap vao khong hop le. Xin nhap lai!");
                        goto input3;
                    }
                }
            }    
    }
    public void xuat()
    {
        for(int i=0;i<hang;i++)
        {
            for(int j=0;j<cot;j++)
            {
                Console.Write(mt[i][j] + " ");
            }
            Console.Write("\n");
        }
    }
    public void TimKiem()
    {
        Console.WriteLine("Nhap vao phan tu ban muon tim kiem trong ma tran.");
        int k;
        input:
        try
        {
            k = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Phan tu khong hop le. Xin nhap lai!");
            goto input;
        }
        bool found = false;
        for(int i=0;i<hang;i++)
        {
            for(int j=0;j<cot;j++)
            {
                if (mt[i][j] == k)
                {
                    if (!found) Console.Write("Phan tu " + k + " duoc tim thay o vi tri ");
                    found = true;
                    Console.Write("[{0}][{1}] ",i,j);
                }
            }
        }
        if (!found) Console.WriteLine("Trong ma tran khong ton tai phan tu " + k);
        else Console.Write("\n");
    }
    bool ktsnt(int k)
    {
        for(int i=2;i<Math.Sqrt(k)+1;i++)
        {
            if (k % i == 0) return false;
        }
        return true;
    }
    public void snt()
    {
        List<int> dssnt = new List<int>();
        for(int i=0;i<hang;i++)
        {
            for(int j=0;j<cot;j++)
            {
                if (ktsnt(mt[i][j]))
                {
                    if (!dssnt.Contains(mt[i][j])) dssnt.Add(mt[i][j]);
                }
            }
        }
        if (dssnt.Count == 0) Console.WriteLine("Ma tran khong ton tai so nguyen to!");
        else
        {
            Console.WriteLine("Cac so nguyen to ton tai trong ma tran la: ");
            foreach (var i in dssnt) Console.Write(i + " ");
            Console.Write("\n");
        }
    }
    public void DongNhieuSNTNhat()
    {
        int slsntmax = 0;
        List<int> ds = new List<int>();
        for (int i=0;i<hang;i++)
        {
            int slsnt = 0;
            for(int j=0;j<cot;j++)
            {
                if (ktsnt(mt[i][j]))
                {
                    slsnt++;
                }
            }
            if(slsnt==slsntmax)
            {
                ds.Add(i);
            }
            else if (slsnt > slsntmax)
            {
                slsntmax = slsnt;
                ds.Clear();
                ds.Add(i);
            }
        }
        if(slsntmax==0)
        {
            Console.WriteLine("Ma tran nay khong ton tai so nguyen to!");
            return;
        }
        Console.Write("Dong co nhieu SNT nhat la dong: ");
        if (ds.Count == 1) Console.Write(ds.First() + " ");
        else
        {
            foreach (var i in ds) Console.Write(i + ", ");
        }
        Console.WriteLine("voi tong so luong SNT la "+slsntmax);
        
    }
}


class program
{
    static void Main()
    {
        matran a = new matran();
        a.nhap();
        Console.WriteLine("Chuong trinh xu ly ma tran^^\n--------------------------------------------");
        Console.WriteLine("Chon 1 de xem ma tran da nhap\nChon 2 de tim kiem mot phan tu trong matran\n" +
            "Chon 3 de xuat ra cac phan tu la SNT trong ma tran\nChon 4 de tim xem dong nao co nhieu SNT nhat\n" +
            "Chon 0 de ket thuc chuong trinh.");
        int choice=-1;
        while(choice!=0)
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
            switch(choice)
            {
                case 1:
                    a.xuat();
                    break;
                case 2:
                    a.TimKiem();
                    break;
                case 3:
                    a.snt();
                    break;
                case 4:
                    a.DongNhieuSNTNhat();
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
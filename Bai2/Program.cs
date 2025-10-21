using System;
using System.IO;

class thumuc
{
    private string path;
    public void nhap()
    {
        Console.WriteLine("Nhap vao duong dan cua thu muc muon xem!");
        input:
        try
        {
            do
            {
                path = Console.ReadLine();
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Duong dan khong ton tai! Vui long thu lai.");
                }
            } while (!Directory.Exists(path));
        }
        catch
        {
            Console.WriteLine("Input khong hop le! Xin thu lai.");
            goto input;
        }
    }
    public void xuat()
    {
        Console.WriteLine("Da truy cap vao duong dan " + path);
        
        string[] files = Directory.GetFiles(path);
        if (files.Length == 0) Console.WriteLine("Duong dan nay khong co file nao!");
        else Console.WriteLine("Cac file co trong duong dan.");
        foreach (string file in files)
            {
                FileInfo in4 = new FileInfo(file);
                Console.WriteLine(in4.LastWriteTime.ToString() + "\t" + in4.Length + " Bytes\t" + in4.Name);
            }
        
        string[] folders = Directory.GetDirectories(path);
        if (folders.Length == 0) Console.WriteLine("Duong dan nay khong co thu muc nao!");
        else Console.WriteLine("Cac thu muc co trong duong dan.");
        foreach (string folder in folders)
            {
                
                DirectoryInfo in4 = new DirectoryInfo(folder);
                Console.WriteLine(in4.LastWriteTime.ToString() + "\t" + "<DIR>\t" + in4.Name);
            }
        long s = 0;
        foreach(string file in files)
        {
            s += new FileInfo(file).Length;
        }
        Console.WriteLine("\t"+files.Length + " File(s)\t" + s + " Bytes");
        Console.WriteLine("\t"+folders.Length + " Dir(s)");
        string root = Path.GetPathRoot(path);
        DriveInfo drive = new DriveInfo(root);
        Console.WriteLine("\t"+drive.TotalSize + " Bytes total\t" + drive.AvailableFreeSpace + " Bytes free\t");
    }
}


class program
{
    static void Main()
    {
        thumuc a = new thumuc();
        a.nhap();
        a.xuat();
    }
}
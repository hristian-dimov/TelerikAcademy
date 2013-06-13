using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Program
{
    private static List<string> exeFiles = new List<string>();

    static void Main(string[] args)
    {
        Console.WriteLine("Run Visual Studio as Administrator so the program can work properly!!!");
        string directory = @"C:\Program Files";

        DirSearch(directory);

        foreach (string file in exeFiles)
        {
            Console.WriteLine(file);
        }
    }

    private static void DirSearch(string directory)
    {
        try
        {
            foreach (string dir in Directory.GetDirectories(directory))
            {
                foreach (string exe in Directory.GetFiles(dir, "*.exe"))
                {
                    exeFiles.Add(exe);
                }

                DirSearch(dir);
            }
        }
        catch (System.UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
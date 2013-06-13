using System;
using System.IO;

class Program
{
    public static void Main()
    {
        // start visual studio as administrator in order
        // for the program to work
        Console.WriteLine("Run Visual Studio as Administrator so the program can work properly!!!");
        string rootName = @"C:\Program Files";
        string dirSearchSum = @"C:\Program Files";
        Folder rootFolder = new Folder(rootName);
        Folder searchSumDirectory = new Folder(dirSearchSum);
        CreateTree(rootFolder);

        Console.WriteLine("Folder {0}", dirSearchSum);
        Console.WriteLine("Size of folder is {0} bytes", sumFileSize(rootFolder, searchSumDirectory));
    }

    private static void CreateTree(Folder folder)
    {
        try
        {
            string[] filesName = Directory.GetFiles(folder.Name);
            folder.AddFiles(filesName);
            var dirs = Directory.GetDirectories(folder.Name);
            foreach (var dir in dirs)
            {
                Folder newfolder = new Folder(dir);
                folder.AddChieldsFolders(newfolder);
                CreateTree(newfolder);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("No access to this directory");
            return;
        }
    }

    private static long sumFileSize(Folder rootFolder, Folder searchFolder)
    {
        long sum = 0;

        if (rootFolder.Name == searchFolder.Name)
        {
            sum = rootFolder.FolderSize;
            return sum;
        }

        foreach (var folder in rootFolder.Folders)
        {
            if (folder.Name == searchFolder.Name)
            {
                sum = folder.FolderSize;
                return sum;
            }
            else
            {
                sumFileSize(folder, searchFolder);
            }
        }

        return sum;
    }
}
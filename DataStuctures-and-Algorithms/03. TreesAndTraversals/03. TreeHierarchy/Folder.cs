using System;
using System.Collections.Generic;
using System.IO;

public class Folder
{

    public string Name { get; set; }
    public List<File> Files { get; set; }
    public List<Folder> Folders { get; set; }

    public Folder(string name, List<File> files, List<Folder> childFolders)
    {
        this.Name = name;
        this.Files = files;
        this.Folders = childFolders;
    }

    public Folder(string name) :
        this(name, new List<File>(), new List<Folder>())
    {
    }

    public long FolderSize
    {
        get
        {
            long sum = 0;
            foreach (var file in this.Files)
            {
                sum += file.Size;
            }

            foreach (var folder in this.Folders)
            {
                sum += folder.FolderSize;
            }

            return sum;
        }
    }

    public void AddFiles(string[] filesNames)
    {
        for (int i = 0; i < filesNames.Length; i++)
        {
            FileInfo newFileInfo = new FileInfo(filesNames[i]);
            long fileSize = newFileInfo.Length;
            this.Files.Add(new File(filesNames[i], fileSize));
        }
    }

    public void AddChieldsFolders(Folder chieldFolder)
    {
        this.Folders.Add(chieldFolder);
    }
}

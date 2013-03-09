using System;
using System.IO;

static class PathStorage
{
    public static void SavePath(Path p)
    {
        using (StreamWriter writter = new StreamWriter(@"../../points.txt"))
        {
            foreach (var point in p.Points)
            {
                writter.WriteLine(string.Format("{0}, {1}, {2}", point.X, point.Y, point.Z));
            }
        }
    }

    public static void LoadPath()
    {
        string line = string.Empty;
        using (StreamReader reader = new StreamReader(@"../../points.txt"))
        {
            line = reader.ReadToEnd();
            Console.WriteLine(line.Trim());
        }
    }
}
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        CustomHashTable<int, int> hassTable = new CustomHashTable<int, int>();

        for (int i = 0; i < 20; i++)
        {
            hassTable.Add(i, i + 1);
        }

        Console.WriteLine(hassTable.Find(6)); // should print 7

        Console.WriteLine(hassTable.Count);
    }
}
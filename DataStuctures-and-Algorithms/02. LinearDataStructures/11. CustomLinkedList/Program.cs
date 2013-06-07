using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        CustomLinkedList<int> customList = new CustomLinkedList<int>();
        customList.AddLast(15);
        customList.AddLast(30);
        customList.AddLast(31);
        customList.AddLast(32);
        customList.AddLast(33);

        Console.WriteLine(customList.FirstItem.Value);
        Console.WriteLine(customList.FirstItem.NextItem.Value);
        Console.WriteLine(customList.Count);

        customList.RemoveLast();
        Console.WriteLine(customList.Count);
        customList.RemoveLast();
        Console.WriteLine(customList.Count);
        customList.RemoveLast();
        Console.WriteLine(customList.Count);
    }
}
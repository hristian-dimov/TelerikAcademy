using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

        var groupNumbers = numbers.GroupBy(u => u)
            .Select(i => new { Number = i.Key, TotalOccurance = i.Count() })
            .OrderBy(u => u.Number);

        Console.WriteLine(string.Join("\n", groupNumbers));
    }
}
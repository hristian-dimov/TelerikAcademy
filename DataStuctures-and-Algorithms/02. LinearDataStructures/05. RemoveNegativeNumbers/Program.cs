using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 5, -2, 13, -4, -2, -18, 22 };

        // check Utils.cs file for more information
        var excludeAllNegativeNumbers = numbers.LoopWithExclusion(n => n < 0);

        Console.WriteLine(string.Join(", ", excludeAllNegativeNumbers));
    }
}
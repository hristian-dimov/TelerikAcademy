using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<double> numbers = new List<double>() { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

        Dictionary<double, int> occurrences = new Dictionary<double, int>();

        foreach (var number in numbers)
        {
            if (!occurrences.ContainsKey(number))
            {
                occurrences.Add(number, 1);
            }
            else
            {
                occurrences[number]++;
            }
        }

        var ordered = occurrences.OrderBy(x => x.Key);

        foreach (var item in ordered)
        {
            Console.WriteLine("{0} -> {1}", item.Key, item.Value);
        }
    }
}
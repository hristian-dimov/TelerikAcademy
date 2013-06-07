using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        while (true)
        {
            string line = Console.ReadLine();
            if (line == string.Empty)
            {
                break;
            }

            int currentNumber = int.Parse(line);
            numbers.Add(currentNumber);
        }

        numbers.Sort();

        Console.WriteLine(string.Join(", ", numbers));
    }
}
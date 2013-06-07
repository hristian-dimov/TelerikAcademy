using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<double> numbers = new List<double>();

        while (true)
        {
            string line = Console.ReadLine();
            if (line == string.Empty)
            {
                break;
            }

            double currentNumber = double.Parse(line);
            numbers.Add(currentNumber);
        }

        double sum = numbers.Sum();
        double average = sum / numbers.Count;

        Console.WriteLine("Sum = {0} ; Average = {1:F2}", sum, average);
    }
}
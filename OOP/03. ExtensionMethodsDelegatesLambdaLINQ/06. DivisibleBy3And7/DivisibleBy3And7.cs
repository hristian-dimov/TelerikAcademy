using System;
using System.Linq;

class DivisibleBy3And7
{
    static void Main()
    {
        int[] numbers = new int[100];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i;
        }

        var newArr = numbers.Where(x => x % 3 == 0 && x % 7 == 0);

        foreach (var item in newArr)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine(new string('-', 25));
        Console.WriteLine();

        var newArrLinq = from number in numbers
                     where number % 3 == 0 && number % 7 == 0
                     select number;

        foreach (var item in newArrLinq)
        {
            Console.WriteLine(item);
        }
    }
}
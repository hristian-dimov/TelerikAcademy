using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static BigInteger Factorial(BigInteger n)
    {
        BigInteger result = 1;

        for (BigInteger i = n; i > 0; i--)
        {
            result *= i;
        }

        return result;
    }

    static void Main()
    {
        Dictionary<char, int> chars = new Dictionary<char, int>();
        string line = Console.ReadLine();

        foreach (var letter in line)
        {
            if (!chars.ContainsKey(letter))
            {
                chars.Add(letter, 1);
            }
            else
            {
                chars[letter]++;
            }
        }

        BigInteger combinations = Factorial(line.Length);


        foreach (var color in chars)
        {
            combinations /= Factorial(color.Value);
        }

        Console.WriteLine(combinations);
    }
}
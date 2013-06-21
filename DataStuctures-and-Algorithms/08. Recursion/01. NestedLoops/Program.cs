using System;

class Program
{
    static void NestLoops(int index, int[] vector)
    {
        if (index == -1)
        {
            Print(vector);
        }
        else
        {
            for (int i = 1; i <= vector.Length; i++)
            {
                vector[index % vector.Length] = i;
                NestLoops(index - 1, vector);
            }
        }
    }

    static void Print(int[] vector)
    {
        foreach (var i in vector)
        {
            Console.Write("{0} ", i);
        }

        Console.WriteLine();
    }

    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] vector = new int[number];

        NestLoops(number - 1, vector);
    }
}
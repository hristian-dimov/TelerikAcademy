using System;

class Program
{
    static int N = 3;
    static int K = 2;
    static string[] array = new string[K];
    static string[] set = { "hi", "a", "b", "adrian", "typiq neno" };

    public static void Variate(int index, int endNumberIndex)
    {
        if (index >= array.Length)
        {
            Print(array);
            return;
        }

        for (int i = 0; i < endNumberIndex; i++)
        {
            array[index] = set[i];
            Variate(index + 1, endNumberIndex);
        }
    }

    public static void Print(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Variate(0, N);
    }
}
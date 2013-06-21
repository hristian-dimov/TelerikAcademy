using System;

class Program
{
    static int K = 2;
    static string[] array = new string[K];
    static string[] set = { "test", "rock", "fun" };

    public static void Subset(int index, int nextElement, int endNumberIndex)
    {
        if (index > array.Length)
        {
            return;
        }

        for (int i = nextElement + 1; i <= endNumberIndex; i++)
        {
            array[index - 1] = set[i - 1];

            if (index == array.Length)
            {
                Print(array);
            }

            Subset(index + 1, i, endNumberIndex);
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
        Subset(1, 0, set.Length);
    }
}
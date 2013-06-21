using System;

class Program
{
    public static void Combination(int index, int nextElement, int endNumberIndex, int[] array)
    {
        if (index > array.Length)
        {
            return;
        }

        for (int i = nextElement; i <= endNumberIndex; i++)
        {
            array[index - 1] = i;

            if (index == array.Length)
            {
                Print(array);
            }

            Combination(index + 1, i, endNumberIndex, array);
        }
    }

    public static void Print(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());
        int[] array = new int[K];

        Combination(1, 1, N, array);
    }
}
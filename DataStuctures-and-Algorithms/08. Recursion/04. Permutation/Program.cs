using System;

class Permutations
{
    public static void Permute(int index, bool[] used, int[] array)
    {
        if (index >= array.Length)
        {
            Print(array);
            return;
        }

        for (int i = 1; i <= array.Length; i++)
        {
            int boolIndex = i - 1;
            if (!used[boolIndex])
            {
                array[index] = i;

                used[boolIndex] = true;
                Permute(index + 1, used, array);
                used[boolIndex] = false;
            }
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
        int[] array = new int[N];
        bool[] used = new bool[N];

        Permute(0, used, array);
    }
}
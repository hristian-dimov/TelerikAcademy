using System;

public class Program
{
    static string pleasantnessStr = Console.ReadLine();
    static int variety = int.Parse(Console.ReadLine());

    public static void Main()
    {
        string[] pleasantnessStrArr = pleasantnessStr.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] pleasantness = new int[pleasantnessStrArr.Length];
        int minProblems = pleasantness.Length;
        for (int i = 0; i < pleasantnessStrArr.Length; i++)
        {
            pleasantness[i] = int.Parse(pleasantnessStrArr[i]);
        }

        for (int i = 0; i < pleasantness.Length - 1; i++)
        {
            for (int j = i + 1; j < pleasantness.Length; j++)
            {
                if (Math.Abs(pleasantness[i] - pleasantness[j]) >= variety)
                {
                    int problemsCount = ((int)Math.Ceiling((double)i / 2) + 1) +
                        ((j - (i + 1)) / 2 + 1);
                    minProblems = Math.Min(minProblems, problemsCount);
                }
            }
        }
        Console.WriteLine(minProblems);
    }
}
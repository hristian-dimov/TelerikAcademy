using System;

class PrintStats
{
    public void PrintStatistics(double[] numbers, int count)
    {
        double maxNumber = FindMax(numbers);
        Console.WriteLine("This is max number: {0}", maxNumber);

        double minNumber = FindMin(numbers);
        Console.WriteLine("This is min number: {0}", minNumber);

        double averageNumber = FindAverage(numbers);
        Console.WriteLine("This is avg number: {0}", averageNumber);
    }

    private static double FindAverage(double[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        double average = sum / numbers.Length;
        return average;
    }

    private static double FindMin(double[] numbers)
    {
        double min = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }

    private static double FindMax(double[] numbers)
    {
        double max = numbers[0];

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return max;
    }

    static void Main()
    {
        PrintStats stats = new PrintStats();
        stats.PrintStatistics(new double[3] { 1, 2, 6 }, 3);
    }
}
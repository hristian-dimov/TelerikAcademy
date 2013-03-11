using System;
using System.Collections.Generic;

static class IEnumerableExtensionMethods
{
    public static T Sum<T>(this IEnumerable<T> numbers)
    {
        dynamic sum = 0;

        foreach (var item in numbers)
            sum += item;

        return sum;
    }

    public static T Product<T>(this IEnumerable<T> numbers)
    {
        dynamic product = 1;

        foreach (var item in numbers)
            product *= item;

        return product;
    }

    public static T Min<T>(this IEnumerable<T> numbers)
    {
        dynamic minItem = int.MaxValue;

        foreach (var item in numbers)
            if (item < minItem)
                minItem = item;

        return minItem;
    }

    public static T Max<T>(this IEnumerable<T> numbers)
    {
        dynamic maxItem = int.MinValue;

        foreach (var item in numbers)
            if (item > maxItem)
                maxItem = item;

        return maxItem;
    }

    public static T Average<T>(this IEnumerable<T> numbers)
    {
        dynamic items = 0;
        dynamic sum = 0;

        foreach (var item in numbers)
        {
            items++;
            sum += item;
        }

        return sum / items;
    }

    static void Main()
    {
        Random randomValues = new Random();

        int[] numbers = new int[10];
        
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = randomValues.Next(5, 10);
        }

        Console.WriteLine("Sum: {0}", numbers.Sum<int>());
        Console.WriteLine("Product: {0}", numbers.Product<int>());
        Console.WriteLine("Min element: {0}", numbers.Min<int>());
        Console.WriteLine("Max element: {0}", numbers.Max<int>());
        Console.WriteLine("Average: {0}", numbers.Average<int>());
    }
}
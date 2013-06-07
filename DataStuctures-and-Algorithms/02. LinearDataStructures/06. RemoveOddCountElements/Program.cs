using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        Dictionary<int, int> dictionaryNumbers = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (!dictionaryNumbers.ContainsKey(numbers[i]))
            {
                dictionaryNumbers.Add(numbers[i], 1);
            }
            else
            {
                dictionaryNumbers[numbers[i]]++;
            }
        }

        // deleting the odd occurance count numbers
        foreach (var number in dictionaryNumbers)
        {
            if (number.Value % 2 != 0)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers.Remove(number.Key);
                }
            }
        }

        Console.WriteLine(string.Join(", ", numbers));
    }
}
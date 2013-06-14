using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> words = new List<string>() { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

        Dictionary<string, int> occurrences = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (!occurrences.ContainsKey(word))
            {
                occurrences.Add(word, 1);
            }
            else
            {
                occurrences[word]++;
            }
        }

        foreach (var item in occurrences)
        {
            if (item.Value % 2 == 1)
            {
                Console.Write(item.Key + " ");
            }
        }
        Console.WriteLine();
    }
}
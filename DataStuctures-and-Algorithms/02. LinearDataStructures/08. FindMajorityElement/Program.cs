using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static int FindMajority(List<int> list)
    {
        int i, j, count;

        for (i = 0; i <= list.Count / 2; i++)
        {
            for (count = 0, j = i; j < list.Count; j++)
            {
                if (list[i] == list[j])
                {
                    count++;
                }
            }

            if (count > list.Count / 2)
            {
                return list[i];
            }
        }

        return -1;
    }

    static void Main()
    {
        List<int> numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

        int majority = FindMajority(numbers);

        if (majority == -1)
        {
            Console.WriteLine("There is no majority element !");
        }
        else
        {
            Console.WriteLine("Majority: {0}", majority);
        }
    }
}
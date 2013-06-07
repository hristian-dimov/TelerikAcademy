using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1, 1, 1, 1, 1 };

        int lastNumber = -1;
        int sequence = 0;
        int bestSequence = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (lastNumber == numbers[i])
            {
                sequence++;
            }
            else
            {
                sequence = 1;
            }

            if (sequence > bestSequence)
            {
                bestSequence = sequence;
            }

            lastNumber = numbers[i];
        }

        Console.WriteLine("Longest equal subset is: {0} numbers", bestSequence);
    }
}
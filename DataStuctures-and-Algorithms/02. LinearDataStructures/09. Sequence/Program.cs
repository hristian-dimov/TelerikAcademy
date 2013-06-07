using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Queue<int> sequence = new Queue<int>();
        List<int> result = new List<int>();
        int N = int.Parse(Console.ReadLine());

        sequence.Enqueue(N);

        for (int i = 0; i < 50; i++)
        {
            int currentNumber = sequence.Dequeue();
            result.Add(currentNumber);

            sequence.Enqueue(currentNumber + 1);
            sequence.Enqueue(2 * currentNumber + 1);
            sequence.Enqueue(currentNumber + 2);
        }

        Console.WriteLine(string.Join(" ", result));
    }
}
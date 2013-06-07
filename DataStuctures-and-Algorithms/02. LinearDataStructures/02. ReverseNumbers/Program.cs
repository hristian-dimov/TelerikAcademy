using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < N; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            stack.Push(currentNumber);
        }

        Console.WriteLine(string.Join(", ", stack));
    }
}
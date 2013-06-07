using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        CustomStack<int> customStack = new CustomStack<int>();

        customStack.Push(123);
        customStack.Push(124);
        customStack.Push(125);
        customStack.Push(1251);

        Console.WriteLine("Stack count: {0}", customStack.Count);

        int number = customStack.Pop();
        Console.WriteLine("Pop an element: {0}", number);
        Console.WriteLine("Peek element: {0}", customStack.Peek());
    }
}

using System;

class Program
{
    static void Main()
    {
        CustomQueue<int> testQueue = new CustomQueue<int>();

        testQueue.Enqueue(1);
        testQueue.Enqueue(2);
        testQueue.Enqueue(3);

        Console.WriteLine("Queue Lenght: {0}", testQueue.Count);
        Console.WriteLine("Dequeued Item: {0}", testQueue.Dequeue());
        Console.WriteLine("Dequeued Item: {0}", testQueue.Dequeue());
        Console.WriteLine("Peeking at Item: {0}", testQueue.Peek());
    }
}
using System;

class Program
{
    static void Main()
    {
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();

        priorityQueue.Enqueue(1, 10);
        priorityQueue.Enqueue(5, 12);
        priorityQueue.Enqueue(2, 13);
        priorityQueue.Enqueue(4, 14);
        priorityQueue.Enqueue(3, 15);

        Console.WriteLine("Peek at biggest element: {0} ", priorityQueue.Peek());
        priorityQueue.Dequeue();

        Console.WriteLine("Peek after dequeue: {0}", priorityQueue.Peek());

        priorityQueue.Enqueue(5, 15);
        priorityQueue.Enqueue(2, 20);
        Console.WriteLine("Biggest element after enqueue: {0} ", priorityQueue.Peek());
    }
}
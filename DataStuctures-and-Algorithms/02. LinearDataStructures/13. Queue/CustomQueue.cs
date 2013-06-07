using System;
using System.Collections.Generic;
using System.Linq;

public class CustomQueue<T>
{
    public QueueItem<T> FirstItem { get; private set; }

    public int Count
    {
        get
        {
            int count = 0;
            QueueItem<T> currentItem = this.FirstItem;

            if (this.FirstItem == null)
            {
                return 0;
            }

            while (currentItem.PreviousItem != null)
            {
                currentItem = currentItem.PreviousItem;
                count++;
            }

            return count + 1;
        }
    }

    public void Enqueue(T value)
    {
        if (this.FirstItem == null)
        {
            this.FirstItem = new QueueItem<T>(value);
        }
        else
        {
            QueueItem<T> next = this.FirstItem;

            while (next.PreviousItem != null)
            {
                next = next.PreviousItem;
            }

            next.PreviousItem = new QueueItem<T>(value);
        }
    }

    public T Dequeue()
    {
        // storing the first item in the queue
        QueueItem<T> dequeuedItem = this.FirstItem;
        // making the second item first, because we dequeued 1 item
        this.FirstItem = this.FirstItem.PreviousItem;

        return dequeuedItem.Value;
    }

    public T Peek()
    {
        return this.FirstItem.Value;
    }
}
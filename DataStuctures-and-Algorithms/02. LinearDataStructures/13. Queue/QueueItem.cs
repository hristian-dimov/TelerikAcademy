using System;
using System.Collections.Generic;
using System.Linq;

public class QueueItem<T>
{
    public QueueItem(T value)
    {
        this.Value = value;
    }

    public T Value { get; set; }
    public QueueItem<T> PreviousItem { get; set; }
}
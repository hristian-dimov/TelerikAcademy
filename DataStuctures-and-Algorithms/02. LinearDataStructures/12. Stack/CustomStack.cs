using System;
using System.Collections.Generic;
using System.Linq;

public class CustomStack<T>
{
    private T[] array;

    public CustomStack()
    {
        this.array = new T[1];
        this.Count = 0;
    }

    public int Count
    {
        get;
        private set;
    }

    public void Push(T value)
    {
        if (this.Count >= this.array.Length)
        {
            this.ResizeStack();
        }

        this.array[this.Count] = value;
        this.Count++;
    }

    public T Pop()
    {
        T poppedElement = this.array[this.Count - 1];
        this.Count--;

        return poppedElement;
    }

    public T Peek()
    {
        T peekedElement = this.array[this.Count - 1];

        return peekedElement;
    }

    public void Clear()
    {
        this.array = new T[1];
        this.Count = 0;
    }

    private void ResizeStack()
    {
        T[] newArray = new T[2 * this.array.Length];

        for (int i = 0; i < this.array.Length; i++)
        {
            newArray[i] = this.array[i];
        }

        this.array = newArray;
    }
}
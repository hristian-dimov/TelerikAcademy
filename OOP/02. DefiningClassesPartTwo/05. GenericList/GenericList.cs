using System;
using System.Text;

class GenericList<T>
{
    private const int DefaultCapacity = 4;

    private T[] elementsList;

    public int ElementsCount { get; private set; }

    public GenericList(int capacity)
    {
        this.ElementsCount = 0;
        this.elementsList = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            return this.elementsList[index];
        }

        set
        {
            this.elementsList[index] = value;
        }
    }

    public void Add(T element)
    {
        if (this.ElementsCount >= this.elementsList.Length)
        {
            T[] newList = new T[this.elementsList.Length * 2];

            for (int i = 0; i < this.elementsList.Length; i++)
            {
                newList[i] = this.elementsList[i];
            }

            newList[this.elementsList.Length] = element;
            this.elementsList = newList;
            this.ElementsCount++;
        }
        else
        {
            this.elementsList[this.ElementsCount] = element;
            this.ElementsCount++;
        }
    }

    public void Remove(int index)
    {
        if (index < this.elementsList.Length)
        {
            T[] newList = new T[this.elementsList.Length - 1];

            for (int i = 0; i < this.elementsList.Length; i++)
            {
                if (i == index)
                    continue;
            }

            this.elementsList = newList;
            this.ElementsCount--;
        }
        else
        {
            throw new IndexOutOfRangeException("Index is outside the array");
        }
    }

    public void Clear()
    {
        this.ElementsCount = 0;
        elementsList = new T[DefaultCapacity];
    }

    public int IndexOf(T value)
    {
        return Array.IndexOf(this.elementsList, value);
    }

    public override string ToString()
    {
        StringBuilder list = new StringBuilder();

        for (int i = 0; i < this.elementsList.Length; i++)
        {
            if (i != this.ElementsCount - 1)
            {
                list.AppendFormat("{0}, ", this.elementsList[i]);
            }
            else
            {
                list.AppendFormat("{0}", this.elementsList[i]);
            }
        }

        return list.ToString();
    }

    public T Min<I>() where I : IComparable<T>
    {
        dynamic min = this.elementsList[0];

        for (int i = 1; i < elementsList.Length; i++)
            if (min.CompareTo(elementsList[i]) > 0)
                min = elementsList[i];

        return min;
    }

    public T Max<I>() where I : IComparable<T>
    {
        dynamic max = this.elementsList[0];

        for (int i = 1; i < elementsList.Length; i++)
            if (max.CompareTo(elementsList[i]) < 0)
                max = elementsList[i];

        return max;
    }
}
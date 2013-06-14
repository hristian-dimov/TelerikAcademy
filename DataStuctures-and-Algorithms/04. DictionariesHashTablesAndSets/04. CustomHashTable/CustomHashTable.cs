using System;
using System.Collections;
using System.Collections.Generic;

class CustomHashTable<K, T>
{
    // fileds
    private LinkedList<KeyValuePair<K, T>>[] data;
    private int count;
    private int capacity;

    // constructors
    public CustomHashTable(int capacity = 16)
    {
        this.data = new LinkedList<KeyValuePair<K, T>>[capacity];
        this.count = 0;
        this.capacity = capacity;
    }

    // properties
    public int Count
    {
        get
        {
            return this.count;
        }
    }

    public T this[K key]
    {
        get
        {
            T value = this.Find(key);
            return value;
        }

        set
        {
            var index = key.GetHashCode() % this.data.Length;
            if (data[index] != null)
            {
                var next = this.data[index].First;
                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        next.Value = new KeyValuePair<K, T>(key, value);
                        break;
                    }

                    next = next.Next;
                }
            }
            else
            {
                data[index] = new LinkedList<KeyValuePair<K, T>>();
                data[index].AddFirst(new LinkedListNode<KeyValuePair<K, T>>(new KeyValuePair<K, T>(key, value)));
            }

            this.count++;
        }
    }

    // methods
    public void Add(K key, T value)
    {
        // if the capacity reaches 75% the data storage is enlarged
        if (this.count > this.capacity * 0.75)
        {
            this.EnlargeCapacity();
        }

        int index = key.GetHashCode() % this.data.Length;
        if (this.data[index] == null)
        {
            this.data[index] = new LinkedList<KeyValuePair<K, T>>();
        }

        var next = this.data[index].First;
        while (next != null)
        {
            if (next.Value.Key.Equals(key))
            {
                throw new ArgumentException("Key already exists");
            }

            next = next.Next;
        }

        this.data[index].AddLast(new KeyValuePair<K, T>(key, value));
        this.count++;
    }

    public T Find(K key)
    {
        int index = key.GetHashCode() % this.data.Length;
        if (data[index] != null)
        {
            var next = this.data[index].First;
            while (next != null)
            {
                if (next.Value.Key.Equals(key))
                {
                    return next.Value.Value;
                }

                next = next.Next;
            }
        }

        throw new ArgumentException("Key doesn't exists");
    }

    public void Remove(K key)
    {
        int index = key.GetHashCode() % this.data.Length;
        if (this.data[index] == null)
        {
            throw new ArgumentException("Key doesn't exists");
        }

        bool isRemoved = false;
        var next = this.data[index].First;
        while (next != null)
        {
            if (next.Value.Key.Equals(key))
            {
                this.data[index].Remove(next);
                isRemoved = true;
                break;
            }

            next = next.Next;
        }

        if (!isRemoved)
        {
            throw new ArgumentException("Key doesn't exists");
        }

        this.count--;
    }

    public void Clear()
    {
        this.data = new LinkedList<KeyValuePair<K, T>>[16];
        this.count = 0;
        this.capacity = data.Length;
    }

    private void EnlargeCapacity()
    {
        LinkedList<KeyValuePair<K, T>>[] newDataStorage = new LinkedList<KeyValuePair<K, T>>[capacity * 2];

        for (int i = 0; i < this.data.Length; i++)
        {
            newDataStorage[i] = this.data[i];
        }

        this.data = newDataStorage;
        this.capacity = newDataStorage.Length;
    }
}
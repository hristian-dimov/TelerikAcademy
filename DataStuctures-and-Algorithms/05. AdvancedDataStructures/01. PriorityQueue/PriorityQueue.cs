using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue<TPriority, TValue>
{
    private List<KeyValuePair<TPriority, TValue>> baseHeap;
    private IComparer<TPriority> comparer;

    #region Constructors

    public PriorityQueue()
    {
        this.baseHeap = new List<KeyValuePair<TPriority, TValue>>();
        this.comparer = Comparer<TPriority>.Default;
    }

    #endregion

    #region Priority queue operations

    // Enqueues element into priority queue
    public void Enqueue(TPriority priority, TValue value)
    {
        Insert(priority, value);
    }

    // Dequeues element with minimum priority and return its priority and value
    public KeyValuePair<TPriority, TValue> Dequeue()
    {
        if (!IsEmpty)
        {
            KeyValuePair<TPriority, TValue> result = baseHeap[0];
            DeleteRoot();
            return result;
        }
        else
            throw new InvalidOperationException("Priority queue is empty");
    }

    // Returns priority and value of the element with minimun priority, without removing it from the queue
    public KeyValuePair<TPriority, TValue> Peek()
    {
        if (!IsEmpty)
            return baseHeap[0];
        else
            throw new InvalidOperationException("Priority queue is empty");
    }

    // Gets whether priority queue is empty
    public bool IsEmpty
    {
        get { return baseHeap.Count == 0; }
    }

    #endregion

    #region Heap operations

    private void ExchangeElements(int pos1, int pos2)
    {
        KeyValuePair<TPriority, TValue> val = baseHeap[pos1];
        baseHeap[pos1] = baseHeap[pos2];
        baseHeap[pos2] = val;
    }

    private void Insert(TPriority priority, TValue value)
    {
        KeyValuePair<TPriority, TValue> val = new KeyValuePair<TPriority, TValue>(priority, value);
        baseHeap.Add(val);

        // heap[i] have children heap[2*i + 1] and heap[2*i + 2] and parent heap[(i-1)/ 2];

        // heapify after insert, from end to beginning
        HeapifyFromEndToBeginning(baseHeap.Count - 1);
    }

    private int HeapifyFromEndToBeginning(int pos)
    {
        if (pos >= baseHeap.Count) return -1;

        while (pos > 0)
        {
            int parentPos = (pos - 1) / 2;
            if (comparer.Compare(baseHeap[parentPos].Key, baseHeap[pos].Key) > 0)
            {
                ExchangeElements(parentPos, pos);
                pos = parentPos;
            }
            else break;
        }
        return pos;
    }

    private void DeleteRoot()
    {
        if (baseHeap.Count <= 1)
        {
            baseHeap.Clear();
            return;
        }

        baseHeap[0] = baseHeap[baseHeap.Count - 1];
        baseHeap.RemoveAt(baseHeap.Count - 1);

        // heapify
        HeapifyFromBeginningToEnd(0);
    }

    private void HeapifyFromBeginningToEnd(int pos)
    {
        if (pos >= baseHeap.Count) return;

        // heap[i] have children heap[2*i + 1] and heap[2*i + 2] and parent heap[(i-1)/ 2];

        while (true)
        {
            // on each iteration exchange element with its smallest child
            int smallest = pos;
            int left = 2 * pos + 1;
            int right = 2 * pos + 2;
            if (left < baseHeap.Count && comparer.Compare(baseHeap[smallest].Key, baseHeap[left].Key) > 0)
                smallest = left;
            if (right < baseHeap.Count && comparer.Compare(baseHeap[smallest].Key, baseHeap[right].Key) > 0)
                smallest = right;

            if (smallest != pos)
            {
                ExchangeElements(smallest, pos);
                pos = smallest;
            }
            else break;
        }
    }

    #endregion
}
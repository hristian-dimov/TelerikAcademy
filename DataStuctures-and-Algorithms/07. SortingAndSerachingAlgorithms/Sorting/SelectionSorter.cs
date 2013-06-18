namespace Sorting
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int minValue = int.MinValue;

            for (int i = 0; i < collection.Count - 1; i++)
            {
                minValue = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minValue]) < 0)
                    {
                        minValue = j;
                    }
                }

                if (minValue != i)
                {
                    T swapValue = collection[i];
                    collection[i] = collection[minValue];
                    collection[minValue] = swapValue;
                }
            }
        }
    }
}

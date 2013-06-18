namespace Sorting
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        private int Partition(IList<T> collection, int left, int right)
        {
            var x = collection[right];
            int i = left - 1;
            T swapValue;

            for (int j = left; j < right; j++)
            {
                if (collection[j].CompareTo(x) < 0)
                {
                    i = i + 1;

                    swapValue = collection[i];
                    collection[i] = collection[j];
                    collection[j] = swapValue;
                }
            }

            swapValue = collection[i + 1];
            collection[i + 1] = collection[right];
            collection[right] = swapValue;

            return i + 1;
        }

        private void QuickSort(IList<T> collection, int left, int right)
        {
            if (left < right)
            {
                int partition = Partition(collection, left, right);
                QuickSort(collection, left, partition - 1);
                QuickSort(collection, partition + 1, right);
            }
        }

        public void Sort(IList<T> collection)
        {
            if (collection.Count > 1)
            {
                this.QuickSort(collection, 0, collection.Count - 1);
            }
        }
    }
}

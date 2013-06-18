namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private void Merge(IList<T> collection, int from, int mid, int to)
        {
            int N = to - from + 1;
            IList<T> temporaryArray = new T[N];

            int nextElementInFirstHalf = from;
            int nextElementInSecondHalf = mid + 1;
            int nextOpenPosition = 0; /* next open position in temporaryArray */

            while (nextElementInFirstHalf <= mid && nextElementInSecondHalf <= to)
            {
                if (collection[nextElementInFirstHalf].CompareTo(collection[nextElementInSecondHalf]) < 0)
                {
                    temporaryArray[nextOpenPosition] = collection[nextElementInFirstHalf];
                    nextElementInFirstHalf++;
                }
                else
                {
                    temporaryArray[nextOpenPosition] = collection[nextElementInSecondHalf];
                    nextElementInSecondHalf++;
                }
                nextOpenPosition++;
            }

            while (nextElementInFirstHalf <= mid)
            {
                temporaryArray[nextOpenPosition] = collection[nextElementInFirstHalf];
                nextElementInFirstHalf++;
                nextOpenPosition++;
            }

            while (nextElementInSecondHalf <= to)
            {
                temporaryArray[nextOpenPosition] = collection[nextElementInSecondHalf];
                nextElementInSecondHalf++;
                nextOpenPosition++;
            }

            for (nextOpenPosition = 0; nextOpenPosition < N; nextOpenPosition++)
                collection[from + nextOpenPosition] = temporaryArray[nextOpenPosition];
        }

        private void MergeSort(IList<T> collection, int from, int to)
        {
            if (from == to) return;
            int mid = (from + to) / 2;

            MergeSort(collection, from, mid);
            MergeSort(collection, mid + 1, to);
            Merge(collection, from, mid, to);
        }

        public void Sort(IList<T> collection)
        {
            if (collection.Count > 1)
            {
                this.MergeSort(collection, 0, collection.Count - 1);
            }
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting.Test
{
    [TestClass]
    public class SelectionSorterTest
    {
        [TestMethod]
        public void DefaultCaseSelectionSortTest()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            collection.Sort(new SelectionSorter<int>());

            int[] expectedCollection = { 0, 11, 22, 33, 101, 101 };

            for (int i = 0; i < expectedCollection.Length; i++)
            {
                int expected = expectedCollection[i];
                int actual = collection.Items[i];

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void NegativeValuesSelectionSortTest()
        {
            var collection = new SortableCollection<int>(new[] { -22, 11, -101, 33, 0, 101 });
            collection.Sort(new SelectionSorter<int>());

            int[] expectedCollection = { 0, 11, -22, 33, -101, 101 };
            Array.Sort(expectedCollection);

            for (int i = 0; i < expectedCollection.Length; i++)
            {
                int expected = expectedCollection[i];
                int actual = collection.Items[i];

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void AllEqualValuesSelectionSortTest()
        {
            var collection = new SortableCollection<int>(new[] { 1, 1, 1, 1, 1, 1 });
            collection.Sort(new SelectionSorter<int>());

            int[] expectedCollection = { 1, 1, 1, 1, 1, 1 };
            Array.Sort(expectedCollection);

            for (int i = 0; i < expectedCollection.Length; i++)
            {
                int expected = expectedCollection[i];
                int actual = collection.Items[i];

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
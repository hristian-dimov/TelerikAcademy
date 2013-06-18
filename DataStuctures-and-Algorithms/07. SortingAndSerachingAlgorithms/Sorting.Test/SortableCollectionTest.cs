using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting.Test
{
    [TestClass]
    public class SortableCollectionTest
    {
        [TestMethod]
        public void LinearSearchContainsElementTest()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

            Assert.IsTrue(collection.LinearSearch(101));
        }

        [TestMethod]
        public void LinearSearchDoesntContainsElementTest()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

            Assert.IsFalse(collection.LinearSearch(102));
        }

        [TestMethod]
        public void LinearSearchNegativeElementTest()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

            Assert.IsFalse(collection.LinearSearch(-101));
        }

        [TestMethod]
        public void BinarySearchContainsElementTest()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

            Assert.IsTrue(collection.BinarySearch(101));
        }

        [TestMethod]
        public void BinarySearchDoesntContainElementTest()
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

            Assert.IsFalse(collection.BinarySearch(10));
        }
    }
}
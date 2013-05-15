using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalkInMatrix;

namespace WalkInMatrixTest
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZeroDimentionsTest()
        {
            Matrix matrix = new Matrix(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooBigDimentionsTest()
        {
            Matrix matrix = new Matrix(101);
        }

        [TestMethod]
        public void OneDimentionTest()
        {
            Matrix matrix = new Matrix(1);

            Assert.IsTrue(matrix.ToString() == string.Format("  1\r\n"));
        }

        [TestMethod]
        public void ThreeDimentionTest()
        {
            Matrix matrix = new Matrix(3);

            Assert.IsTrue(matrix.ToString() == string.Format("  1  7  8\r\n  6  2  9\r\n  5  4  3\r\n"));
        }

        [TestMethod]
        public void isDimentionsSetCorectly()
        {
            Matrix matrix = new Matrix(99);

            Assert.AreEqual(99, matrix.Dimentions);
        }
    }
}

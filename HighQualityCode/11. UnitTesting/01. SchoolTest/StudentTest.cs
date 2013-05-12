using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullStudentNameTest()
        {
            Student student = new Student(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyStudenttNameTest()
        {
            Student student = new Student("", 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LittleStudentNumberTest()
        {
            Student student = new Student("Test", 1111);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BigStudentNumberTest()
        {
            Student student = new Student("Test", 999999);
        }

        [TestMethod]
        public void IsStudentNameSetCorectlyTest()
        {
            Student student = new Student("Test", 10000);

            string exprected = "Test";
            string actual = student.Name;
            Assert.AreEqual(exprected, actual, "Student's name is not set correctly.");
        }

        [TestMethod]
        public void IsStudentNumberSetCorectlyTest()
        {
            Student student = new Student("Test", 10000);

            int exprected = 10000;
            int actual = student.StudentNumber;
            Assert.AreEqual(exprected, actual, "Student's number is not set correctly.");
        }
    }
}

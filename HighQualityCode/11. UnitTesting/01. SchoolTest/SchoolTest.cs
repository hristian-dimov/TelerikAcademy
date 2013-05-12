using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolTest
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullSchoolNameTest()
        {
            School school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptySchoolNameTest()
        {
            School school = new School("");
        }

        [TestMethod]
        public void IsSchoolNameSetCorectlyTest()
        {
            School school = new School("Test");

            string exprected = "Test";
            string actual = school.Name;
            Assert.AreEqual(exprected, actual, "School's name is not set correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddCourseNullTest()
        {
            School school = new School("test");
            school.AddCourse(null);
        }

        [TestMethod]
        public void AddCourseTest()
        {
            School school = new School("test");
            Course course = new Course("test");
            school.AddCourse(course);

            Assert.IsTrue(school.Courses.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveCourseNullTest()
        {
            School school = new School("test");
            school.RemoveCourse(null);
        }

        [TestMethod]
        public void RemoveCourseTest()
        {
            School school = new School("test");
            Course course = new Course("test");

            school.AddCourse(course);
            school.RemoveCourse(course);

            Assert.IsTrue(school.Courses.Count == 0);
        }
    }
}

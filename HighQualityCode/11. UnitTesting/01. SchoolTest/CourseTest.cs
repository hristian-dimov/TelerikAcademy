using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolTest
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullCouseNameTest()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyCourseNameTest()
        {
            Course course = new Course("");
        }

        [TestMethod]
        public void IsCourseNameSetCorectlyTest()
        {
            Course course = new Course("Test");

            string exprected = "Test";
            string actual = course.CourseName;
            Assert.AreEqual(exprected, actual, "Course's name is not set correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JoinCourseStudentNullTest()
        {
            Course course = new Course("test");
            course.JoinCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void JoinCourseMaxStudentTest()
        {
            Course test = new Course("test");

            for (int i = 0; i < Course.MaxStudentsInCourse; i++)
            {
                test.JoinCourse(new Student("Name - " + i, 10000 + i));
            }

            test.JoinCourse(new Student("30-th student", 12345));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DuplicateStudentTest()
        {
            Course test = new Course("test");
            Student student = new Student("NewStudent", 12345);

            test.JoinCourse(student);
            test.JoinCourse(student);
        }

        [TestMethod]
        public void JoinCourseTest()
        {
            Course test = new Course("test");
            Student student = new Student("NewStudent", 12345);

            test.JoinCourse(student);

            Assert.IsTrue(test.StudentsList.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LeaveCourseNullStudentTest()
        {
            Course test = new Course("test");
            test.LeaveCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LeaveCourseWrongStudentTest()
        {
            Course test = new Course("test");
            Student student = new Student("NewStudent", 12345);

            test.LeaveCourse(student);
        }

        [TestMethod]
        public void LeaveCourseTest()
        {
            Course test = new Course("test");
            Student student = new Student("NewStudent", 12345);

            test.JoinCourse(student);
            test.LeaveCourse(student);

            Assert.IsTrue(test.StudentsList.Count == 0);
        }
    }
}

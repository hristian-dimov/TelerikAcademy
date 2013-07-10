-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jul 10, 2013 at 02:16 PM
-- Server version: 5.5.27
-- PHP Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `university`
--

-- --------------------------------------------------------

--
-- Table structure for table `courses`
--

CREATE TABLE IF NOT EXISTS `courses` (
  `courseID` int(11) NOT NULL AUTO_INCREMENT,
  `courseName` varchar(255) DEFAULT '',
  `teacherID` int(11) DEFAULT '0',
  `departmentID` int(11) DEFAULT '0',
  PRIMARY KEY (`courseID`),
  KEY `Courses_DepartmentsCourses` (`departmentID`),
  KEY `Courses_specialityID` (`departmentID`),
  KEY `Courses_teacherID` (`teacherID`),
  KEY `Courses_TeachersCourses` (`teacherID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`courseID`, `courseName`, `teacherID`, `departmentID`) VALUES
(1, '.NET C#', 1, 1),
(2, 'VB .NET', 2, 1),
(3, 'F#', 2, 1),
(4, 'Python', 1, 1),
(5, 'Java', 2, 1),
(6, 'Konstitucionno pravo', 4, 2),
(7, 'Tenis na masa', 5, 4),
(8, 'Biology', 3, 3),
(9, 'Yoga', 3, 4),
(10, 'Drawing', 3, 3);

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

CREATE TABLE IF NOT EXISTS `departments` (
  `departmentID` int(11) NOT NULL AUTO_INCREMENT,
  `departmentName` varchar(255) DEFAULT '',
  `managerID` int(11) DEFAULT '0',
  PRIMARY KEY (`departmentID`),
  KEY `Departments_managerID` (`managerID`),
  KEY `Departments_ManagmentDepartments` (`managerID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `departments`
--

INSERT INTO `departments` (`departmentID`, `departmentName`, `managerID`) VALUES
(1, 'Informatics', 6),
(2, 'Law', 7),
(3, 'Arts', 8),
(4, 'Sport', 9);

-- --------------------------------------------------------

--
-- Table structure for table `jobtype`
--

CREATE TABLE IF NOT EXISTS `jobtype` (
  `jobID` int(11) NOT NULL AUTO_INCREMENT,
  `jobName` varchar(255) DEFAULT '',
  PRIMARY KEY (`jobID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `jobtype`
--

INSERT INTO `jobtype` (`jobID`, `jobName`) VALUES
(1, 'Rector'),
(2, 'Dean'),
(3, 'Program Director'),
(4, 'Manager'),
(5, 'Accountant'),
(6, 'Librarian'),
(7, 'Security Officer'),
(8, 'Cleaner'),
(9, 'Handyman'),
(10, 'Intern');

-- --------------------------------------------------------

--
-- Table structure for table `majors`
--

CREATE TABLE IF NOT EXISTS `majors` (
  `majorID` int(11) NOT NULL AUTO_INCREMENT,
  `majorName` varchar(255) DEFAULT '',
  `specialtyID` int(11) DEFAULT '0',
  PRIMARY KEY (`majorID`),
  KEY `Majors_SpecialtiesMajors` (`specialtyID`),
  KEY `Majors_speciatyID` (`specialtyID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- Dumping data for table `majors`
--

INSERT INTO `majors` (`majorID`, `majorName`, `specialtyID`) VALUES
(1, 'Applied Informatics', 1),
(2, 'Advanced Programming', 1),
(3, 'Game Development', 1),
(4, 'Antena Specialist', 2),
(5, 'Satellite', 2),
(6, 'Lawyer', 3),
(7, 'Judge', 3),
(8, 'Music History', 4),
(9, 'Ancient Greek Art History', 4),
(10, 'Coach', 5),
(11, 'Athlete', 5);

-- --------------------------------------------------------

--
-- Table structure for table `managment`
--

CREATE TABLE IF NOT EXISTS `managment` (
  `managerID` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(255) DEFAULT '',
  `lastName` varchar(255) DEFAULT '',
  `jobTypeID` int(11) DEFAULT '0',
  `salary` int(11) DEFAULT '0',
  PRIMARY KEY (`managerID`),
  KEY `Managment_jobTypeID` (`jobTypeID`),
  KEY `Managment_JobTypeManagment` (`jobTypeID`),
  KEY `Managment_Managmentsalary` (`salary`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=14 ;

--
-- Dumping data for table `managment`
--

INSERT INTO `managment` (`managerID`, `firstName`, `lastName`, `jobTypeID`, `salary`) VALUES
(6, 'Rektor', 'Rektorov', 1, 4000),
(7, 'Fred', 'Flintstone', 2, 1500),
(8, 'Petya', 'Margaritkova', 3, 900),
(9, 'Ivanka', 'Hristova', 3, 900),
(10, 'Margarit', 'Petkov', 3, 890),
(11, 'Asev', 'Paskov', 4, 900),
(12, 'Georgi', 'Miorgi', 5, 200),
(13, 'Nasko', 'Mentata', 6, 700);

-- --------------------------------------------------------

--
-- Table structure for table `scholarshiptype`
--

CREATE TABLE IF NOT EXISTS `scholarshiptype` (
  `scholarshipID` int(11) NOT NULL AUTO_INCREMENT,
  `scholarshipName` varchar(255) DEFAULT '',
  `isFull` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`scholarshipID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `scholarshiptype`
--

INSERT INTO `scholarshiptype` (`scholarshipID`, `scholarshipName`, `isFull`) VALUES
(1, 'Full  Local Scholarship', 1),
(2, 'Partial Local Scholarship', 0),
(3, 'EU Scholarship', 0),
(4, 'No Scholarship', 0);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE IF NOT EXISTS `specialties` (
  `specialtyID` int(11) NOT NULL AUTO_INCREMENT,
  `specialtyName` varchar(255) DEFAULT '',
  `departmentID` int(11) DEFAULT '0',
  `teacherID` int(11) DEFAULT '0',
  PRIMARY KEY (`specialtyID`),
  UNIQUE KEY `Specialties_teacherID` (`teacherID`),
  KEY `Specialties_departmentID` (`departmentID`),
  KEY `Specialties_DepartmentsSpecialties` (`departmentID`),
  KEY `Specialties_TeachersSpecialties` (`teacherID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`specialtyID`, `specialtyName`, `departmentID`, `teacherID`) VALUES
(1, 'Computer Science', 1, 1),
(2, 'Telecommonications', 1, 2),
(3, 'Law', 2, 4),
(4, 'History of Arts', 3, 3),
(5, 'Sport', 4, 5);

-- --------------------------------------------------------

--
-- Table structure for table `studentcourses`
--

CREATE TABLE IF NOT EXISTS `studentcourses` (
  `studentID` int(11) NOT NULL DEFAULT '0',
  `courseID` int(11) NOT NULL DEFAULT '0',
  `mark` int(11) DEFAULT '0',
  PRIMARY KEY (`studentID`,`courseID`),
  KEY `StudentCourses_courseID` (`courseID`),
  KEY `StudentCourses_CoursesStudentCourses` (`courseID`),
  KEY `StudentCourses_StudentsStudentCourses` (`studentID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `studentcourses`
--

INSERT INTO `studentcourses` (`studentID`, `courseID`, `mark`) VALUES
(1, 1, 6),
(1, 2, 6),
(1, 5, 6),
(2, 1, 4),
(2, 3, 4),
(2, 7, 3),
(3, 1, 3),
(3, 4, 3),
(3, 8, 3),
(3, 9, 2),
(4, 6, 3),
(4, 10, 5);

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE IF NOT EXISTS `students` (
  `studentID` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(255) DEFAULT '',
  `lastName` varchar(255) DEFAULT '',
  `facultyNumber` int(11) DEFAULT '0',
  `email` varchar(255) DEFAULT '',
  `departmentID` int(11) DEFAULT '0',
  `specialtyID` int(11) DEFAULT '0',
  `majorID` int(11) DEFAULT '0',
  `scholarshipID` int(11) DEFAULT '0',
  PRIMARY KEY (`studentID`),
  KEY `Students_departmentID` (`departmentID`),
  KEY `Students_DepartmentsStudents` (`departmentID`),
  KEY `Students_majorID` (`majorID`),
  KEY `Students_MajorsStudents` (`majorID`),
  KEY `Students_ScholarshipTypeStudents` (`scholarshipID`),
  KEY `Students_SpecialtiesStudents` (`specialtyID`),
  KEY `Students_specialtyID` (`specialtyID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`studentID`, `firstName`, `lastName`, `facultyNumber`, `email`, `departmentID`, `specialtyID`, `majorID`, `scholarshipID`) VALUES
(1, 'Adrian', 'Hristov', 54944, 'simpleEmail@gmail.com', 3, 1, 1, 3),
(2, 'Hristian', 'Dimov', 58771, 'email@email.com', 2, 2, 1, 1),
(3, 'Nenko', 'Bademko', 66666, 'nenko@bademko.solenko', 1, 2, NULL, 1),
(4, 'Montenegro', 'Iliev', 44444, 'dd@hh.ss', 2, 2, NULL, 1);

-- --------------------------------------------------------

--
-- Table structure for table `supportstaff`
--

CREATE TABLE IF NOT EXISTS `supportstaff` (
  `staffID` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(255) DEFAULT '',
  `lastName` varchar(255) DEFAULT '',
  `jobTypeID` int(11) DEFAULT '0',
  `salary` int(11) DEFAULT '0',
  PRIMARY KEY (`staffID`),
  KEY `SupportStaff_jobTitleID` (`jobTypeID`),
  KEY `SupportStaff_JobTypeSupportStaff` (`jobTypeID`),
  KEY `SupportStaff_SupportStaffsalary` (`salary`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `supportstaff`
--

INSERT INTO `supportstaff` (`staffID`, `firstName`, `lastName`, `jobTypeID`, `salary`) VALUES
(1, 'Mitko', 'Ognqr4eto', 9, 450),
(2, 'Lelq Je4ka', 'Pastorkata', 8, 500),
(3, 'Petko', 'Argov', 7, 420),
(4, 'Kristyan', 'Gospodinov', 9, 350),
(5, 'Neno', 'Robertov', 10, 0);

-- --------------------------------------------------------

--
-- Table structure for table `teacherdegree`
--

CREATE TABLE IF NOT EXISTS `teacherdegree` (
  `degreeID` int(11) NOT NULL AUTO_INCREMENT,
  `degreeName` varchar(255) DEFAULT '',
  PRIMARY KEY (`degreeID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `teacherdegree`
--

INSERT INTO `teacherdegree` (`degreeID`, `degreeName`) VALUES
(1, 'Phd'),
(2, 'Professor'),
(3, 'Chief Assistant'),
(4, 'Assistant');

-- --------------------------------------------------------

--
-- Table structure for table `teachers`
--

CREATE TABLE IF NOT EXISTS `teachers` (
  `teacherID` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(255) DEFAULT '',
  `lastName` varchar(255) DEFAULT '',
  `teacherNumber` int(11) DEFAULT '0',
  `degreeID` int(11) DEFAULT '0',
  `departmentID` int(11) DEFAULT '0',
  `salary` int(11) DEFAULT '0',
  PRIMARY KEY (`teacherID`),
  KEY `Teachers_departmentID` (`degreeID`),
  KEY `Teachers_departmentID1` (`departmentID`),
  KEY `Teachers_DepartmentsTeachers` (`departmentID`),
  KEY `Teachers_TeacherDegreeTeachers` (`degreeID`),
  KEY `Teachers_Teacherssalary` (`salary`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `teachers`
--

INSERT INTO `teachers` (`teacherID`, `firstName`, `lastName`, `teacherNumber`, `degreeID`, `departmentID`, `salary`) VALUES
(1, 'Petran', 'Aleksiev', 13214, 3, 2, 700),
(2, 'Sevdalin', 'Ananiev', 60352, 3, 1, 400),
(3, 'Nenka', 'Bademka', 73737, 4, 3, 250),
(4, 'Petrakis', 'Costakis', 45422, 2, 2, 1200),
(5, 'Genadi', 'Avtodjambazov', 33454, 1, 2, 600),
(6, 'Alex', 'Malex', 132234, 3, 3, 700);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `courses`
--
ALTER TABLE `courses`
  ADD CONSTRAINT `Courses_FK00` FOREIGN KEY (`departmentID`) REFERENCES `departments` (`departmentID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `Courses_FK01` FOREIGN KEY (`teacherID`) REFERENCES `teachers` (`teacherID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `departments`
--
ALTER TABLE `departments`
  ADD CONSTRAINT `Departments_FK00` FOREIGN KEY (`managerID`) REFERENCES `managment` (`managerID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `majors`
--
ALTER TABLE `majors`
  ADD CONSTRAINT `Majors_FK00` FOREIGN KEY (`specialtyID`) REFERENCES `specialties` (`specialtyID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `managment`
--
ALTER TABLE `managment`
  ADD CONSTRAINT `Managment_FK00` FOREIGN KEY (`jobTypeID`) REFERENCES `jobtype` (`jobID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `specialties`
--
ALTER TABLE `specialties`
  ADD CONSTRAINT `Specialties_FK00` FOREIGN KEY (`departmentID`) REFERENCES `departments` (`departmentID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `Specialties_FK01` FOREIGN KEY (`teacherID`) REFERENCES `teachers` (`teacherID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `studentcourses`
--
ALTER TABLE `studentcourses`
  ADD CONSTRAINT `StudentCourses_FK00` FOREIGN KEY (`courseID`) REFERENCES `courses` (`courseID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `StudentCourses_FK01` FOREIGN KEY (`studentID`) REFERENCES `students` (`studentID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `students`
--
ALTER TABLE `students`
  ADD CONSTRAINT `Students_FK00` FOREIGN KEY (`departmentID`) REFERENCES `departments` (`departmentID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `Students_FK01` FOREIGN KEY (`majorID`) REFERENCES `majors` (`majorID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `Students_FK02` FOREIGN KEY (`scholarshipID`) REFERENCES `scholarshiptype` (`scholarshipID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `Students_FK03` FOREIGN KEY (`specialtyID`) REFERENCES `specialties` (`specialtyID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `supportstaff`
--
ALTER TABLE `supportstaff`
  ADD CONSTRAINT `SupportStaff_FK00` FOREIGN KEY (`jobTypeID`) REFERENCES `jobtype` (`jobID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `teachers`
--
ALTER TABLE `teachers`
  ADD CONSTRAINT `Teachers_FK00` FOREIGN KEY (`departmentID`) REFERENCES `departments` (`departmentID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `Teachers_FK01` FOREIGN KEY (`degreeID`) REFERENCES `teacherdegree` (`degreeID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

using System;
using SchoolSystem.Data;
using SchoolSystem.Models;
using System.Data.Entity;
using SchoolSystem.Data.Migrations;

namespace SchoolSystem.Client
{
    internal class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolSystemContext, Configuration>());

            var db = new SchoolSystemContext();

            var newStudent = new Student { Name = "Random Person", Number = "99999", };
            db.Students.Add(newStudent);

            db.SaveChanges();
        }
    }
}

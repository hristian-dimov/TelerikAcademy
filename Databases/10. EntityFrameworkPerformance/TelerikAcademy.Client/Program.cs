using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Models;

namespace TelerikAcademy.Client
{
    class Program
    {
        static void Main()
        {

            Stopwatch sw = new Stopwatch();
            string firstResult, secondResult;
            string optimizedResult, notOptimizedResult;

            using (var database = new TelerikAcademyEntities())
            {
                sw.Start();

                PrintWithoutInclude(database);

                sw.Stop();
                firstResult = sw.Elapsed.ToString();

                sw.Restart();

                Console.WriteLine("========================================");

                PrintWithInclude(database);
                sw.Stop();
                secondResult = sw.Elapsed.ToString();

                Console.WriteLine("Time without include: {0}", firstResult);
                Console.WriteLine("Time with include: {0}", secondResult);

                ////////////////// Task 2 //////////////////

                sw.Restart();
                Console.WriteLine("========================================");

                Optimized(database);
                sw.Stop();
                optimizedResult = sw.Elapsed.ToString();

                sw.Restart();

                Console.WriteLine("========================================");

                NotOptimized(database);
                sw.Stop();
                notOptimizedResult = sw.Elapsed.ToString();


                Console.WriteLine("Time without optimized: {0}", notOptimizedResult);
                Console.WriteLine("Time with optimized: {0}", optimizedResult);
            }
        }

        private static void PrintWithInclude(TelerikAcademyEntities db)
        {
            foreach (var emp in db.Employees.Include("Department").Include("Address.Town").Take(20))
            {
                Console.WriteLine("DepartmentID: {0}, {1} {2}\tFrom {3}",
                    emp.Department.DepartmentID,
                    emp.FirstName,
                    emp.LastName,
                    emp.Address.Town.Name);
            }
        }

        private static void PrintWithoutInclude(TelerikAcademyEntities db)
        {
            foreach (var emp in db.Employees.Take(20))
            {
                Console.WriteLine("DepartmentID: {0}, {1} {2}\tFrom {3}",
                    emp.Department.DepartmentID,
                    emp.FirstName,
                    emp.LastName,
                    emp.Address.Town.Name);
            }
        }

        private static void Optimized(TelerikAcademyEntities db)
        {
            var towns = db.Employees
                .Select(emp => emp.Address)
                .Select(town => town.Town)
                .Where(town => town.Name == "Sofia");

            foreach (var town in towns)
            {
                Console.WriteLine(town.Name);
            }
        }

        private static void NotOptimized(TelerikAcademyEntities db)
        {
            var towns = db.Employees.ToList()
                .Select(emp => emp.Address).ToList()
                .Select(town => town.Town).ToList()
                .Where(town => town.Name == "Sofia");

            foreach (var town in towns)
            {
                Console.WriteLine(town.Name);
            }
        }
    }
}

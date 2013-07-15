namespace SchoolSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SchoolSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<SchoolSystem.Data.SchoolSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SchoolSystem.Data.SchoolSystemContext context)
        {
            string[] studentNames = { "Ivan", "Dragan", "Patkan", "Goran", "Vylchan" };
            string[] studentNumbers = { "11111", "22222", "33333", "44444", "55555" };

            string[] courseNames = { "PHP", "C#", "Java", "Javascript", "Python" };
            string[] courseDescriptions = { "PHP Course", "C# Course", "Java Course", "Javascript Course", "Python Course" };

            for (int i = 0; i < studentNames.Length; i++)
            {
                context.Students.AddOrUpdate(s => s.Number,
                    new Student { Name = studentNames[i], Number = studentNumbers[i], });
            }


            for (int i = 0; i < courseNames.Length; i++)
            {
                context.Courses.AddOrUpdate(c => c.Name,
                    new Course { Name = courseNames[i], Description = courseDescriptions[i] });
            }
        }
    }
}

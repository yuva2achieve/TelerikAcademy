namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using StudentSystem.Model;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            for (int i = 0; i < 50; i++)
            {
                Random rand = new Random();
                var randomNumber = rand.Next();
                context.Students.AddOrUpdate(
                    new Student() { FullName = "Full Name" + i * randomNumber, Number = "11" + i * randomNumber });

                context.Courses.AddOrUpdate(
                    new Course() { Name = "Course" + i * randomNumber, Description = "Description" + i * randomNumber });

            }
        }
    }
}

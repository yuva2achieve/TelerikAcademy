using System;
using System.Data.Entity;
using System.Linq;
using StudentSystem.Model;

namespace StudentSystem.Data
{
    public class StudentSystemContext: DbContext
    {
        public StudentSystemContext()
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
    }
}

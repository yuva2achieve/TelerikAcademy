using System;
using System.Data.Entity;
using System.Linq;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystemDb")
        {
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<School>().Property(x => x.Location).HasMaxLength(100);

            modelBuilder.Entity<Student>().Property(x => x.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Student>().Property(x => x.LastName).HasMaxLength(20);

            modelBuilder.Entity<Mark>().Property(x => x.Subject).HasMaxLength(30);

            base.OnModelCreating(modelBuilder);
        }
    }
}

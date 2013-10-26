using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSystem.Services.Models
{
    public class Student
    {
        public Student()
        {
            this.Marks = new List<Mark>();
        }

        public Student(string firstName, string lastName, int grade, int age, ICollection<Mark> marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
            this.Age = age;
            this.Marks = marks;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Grade { get; set; }

        public int Age { get; set; }

        public ICollection<Mark> Marks { get; set; }
    }
}
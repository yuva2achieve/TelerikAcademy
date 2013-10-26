using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSystem.Services.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }

    public class StudentDetails : Student
    {
        public StudentDetails()
        {
            this.Marks = new List<Mark>();
        }
        
        public ICollection<Mark> Marks { get; set; }
    }
}
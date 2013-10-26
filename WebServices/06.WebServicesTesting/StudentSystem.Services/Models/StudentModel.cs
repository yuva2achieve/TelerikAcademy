using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class StudentModel
    {
        public StudentModel(Student student)
        {
            this.Id = student.Id;
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.Age = student.Age;
            this.Grade = student.Grade;
            this.Marks = new List<MarkModel>();

            foreach (var mark in student.Marks)
            {
                MarkModel markModel = new MarkModel(mark);
                this.Marks.Add(markModel);
            }
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public virtual ICollection<MarkModel> Marks { get; set; }
    }
}
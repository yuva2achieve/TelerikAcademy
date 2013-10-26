using System;
using StudentSystem.Models;

namespace StudentSystem.Services.Models
{
    public class StudentDetails : StudentModel
    {
        public StudentDetails(Student student) : base(student)
        {
            this.School = new SchoolModel(student.School);
        }

        public virtual SchoolModel School { get; set; }
    }
}
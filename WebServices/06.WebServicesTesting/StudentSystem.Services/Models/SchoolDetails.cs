using System;
using System.Collections.Generic;
using StudentSystem.Models;

namespace StudentSystem.Services.Models
{
    public class SchoolDetails : SchoolModel
    {
        public SchoolDetails(School school) : base(school)
        {
            this.Students = new HashSet<StudentModel>();

            foreach (var student in school.Students)
            {
                StudentModel studentModel = new StudentModel(student);
                this.Students.Add(studentModel);
            }
        }

        public ICollection<StudentModel> Students { get; set; }
    }
}
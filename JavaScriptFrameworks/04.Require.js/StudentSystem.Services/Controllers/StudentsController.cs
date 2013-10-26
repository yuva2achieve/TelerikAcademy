using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private ICollection<StudentDetails> data;

        public StudentsController()
        {
            this.data = new List<StudentDetails>();
            this.data.Add(
                new StudentDetails()
                {
                    Id = 1,
                    Name = "Ivan Ivanov",
                    Age = 18,
                    Grade = 12,
                    Marks = new List<Mark>()
                    {
                        new Mark{ Subject = "Math", Score = 4},
                        new Mark{ Subject = "Biology", Score = 6}
                    }
                });

            this.data.Add(
                new StudentDetails()
                {
                    Id = 1,
                    Name = "Petar Petrov",
                    Age = 17,
                    Grade = 11,
                    Marks = new List<Mark>()
                    {
                        new Mark{ Subject = "Literature", Score = 5},
                        new Mark{ Subject = "Chemistry", Score = 3}
                    }
                });
        }

        // GET api/students
        public IEnumerable<Student> Get()
        {
            var students = new List<Student>();

            foreach (var student in this.data)
            {
                var studentModel = new Student();
                studentModel.Id = student.Id;
                studentModel.Name = student.Name;
                studentModel.Age = student.Age;
                studentModel.Grade = student.Grade;

                students.Add(studentModel);
            }

            return students;
        }

        [HttpGet]
        [ActionName("marks")]
        public IEnumerable<Mark> GetMarksById(int id)
        {
            var student = this.data.FirstOrDefault(st => st.Id == id);
            if (student == null)
            {
                throw new ArgumentException("There is no student with Id: " + id);
            }

            return student.Marks;
        }

    }
}

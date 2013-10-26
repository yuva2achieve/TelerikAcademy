using StudentSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudentSystem.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly ICollection<Student> data;

        public StudentsController()
        {
            this.data = new List<Student>();
            var marks = new List<Mark>()
            {
                new Mark(){ Subject = "Math", Score = 5},
                new Mark(){ Subject = "Biology", Score = 6},
                new Mark(){ Subject = "Literature", Score = 3},
                new Mark(){ Subject = "Chemistry", Score = 2}
            };

            this.data.Add(new Student() { FirstName = "Petar", LastName = "Petrov", Age = 17, Grade = 11, Marks = marks });
            this.data.Add(new Student() { FirstName = "Ivan", LastName = "Georgiev", Age = 17, Grade = 11, Marks = marks });
            this.data.Add(new Student() { FirstName = "Georgi", LastName = "Georgiev", Age = 19, Grade = 12, Marks = marks });

        }
        // GET api/students
        public IEnumerable<Student> Get()
        {
            return this.data;
        }
    }
}

using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentSystem.Repositories;
using StudentSystem.Data;
using StudentSystem.Services.Models;

namespace StudentSystem.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private IRepository<Student> data;

        public StudentsController()
        {
            StudentSystemContext context = new StudentSystemContext();
            this.data = new EfRepository<Student>(context);
        }

        public StudentsController(IRepository<Student> data)
        {
            this.data = data;
        }

        // GET api/students
        [HttpGet]
        public IEnumerable<StudentDetails> Get()
        {
            var studentEntities = this.data.All().ToList();

            var studentModels = new List<StudentDetails>();
            foreach (var student in studentEntities)
            {
                StudentDetails studentModel = new StudentDetails(student);
                studentModels.Add(studentModel);
            }

            return studentModels;
        }

        // GET api/students/5
        [HttpGet]
        public StudentDetails Get(int id)
        {
            var studentEntity = this.data.Get(id);
            var studentModel = new StudentDetails(studentEntity);

            return studentModel;
        }

        // POST api/students
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Student value)
        {
            if (value == null )
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Student is null");
                return errResponse;
            }

            this.data.Add(value);

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}

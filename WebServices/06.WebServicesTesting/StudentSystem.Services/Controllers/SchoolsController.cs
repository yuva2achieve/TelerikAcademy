using StudentSystem.Data;
using StudentSystem.Models;
using StudentSystem.Repositories;
using StudentSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentSystem.Services.Controllers
{
    public class SchoolsController : ApiController
    {
        private IRepository<School> data;

        public SchoolsController()
        {
            StudentSystemContext context = new StudentSystemContext();
            this.data = new EfRepository<School>(context);
        }

        public SchoolsController(IRepository<School> data)
        {
            this.data = data;
        }

        // GET api/schools
        [HttpGet]
        public IEnumerable<SchoolDetails> Get()
        {
            var schoolEntities = this.data.All().ToList();

            var schoolModels = new List<SchoolDetails>();
            foreach (var student in schoolEntities)
            {
                SchoolDetails studentModel = new SchoolDetails(student);
                schoolModels.Add(studentModel);
            }

            return schoolModels;
        }

        // GET api/schools/5
        [HttpGet]
        public SchoolDetails Get(int id)
        {
            var schoolEntity = this.data.Get(id);
            var schoolModel = new SchoolDetails(schoolEntity);

            return schoolModel;
        }

        // POST api/schools
        [HttpPost]
        public HttpResponseMessage Post([FromBody]School value)
        {
            if (value == null )
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "School is null");
                return errResponse;
            }

            this.data.Add(value);

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}

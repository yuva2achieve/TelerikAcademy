using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Services.Models
{
    public class SchoolModel
    {
        public SchoolModel(School school)
        {
            this.Id = school.Id;
            this.Name = school.Name;
            this.Location = school.Location;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
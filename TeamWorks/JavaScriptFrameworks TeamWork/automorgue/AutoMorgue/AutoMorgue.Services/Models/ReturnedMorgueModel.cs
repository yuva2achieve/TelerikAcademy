using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMorgue.Models;

namespace AutoMorgue.Services.Models
{
    public class ReturnedMorgueModel
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string WorkTime { get; set; }

        public IEnumerable<AutoPartModel> Parts { get; set; }
    }
}
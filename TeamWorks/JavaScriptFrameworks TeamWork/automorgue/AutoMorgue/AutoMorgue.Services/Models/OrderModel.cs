using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMorgue.Services.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string User { get; set; }

        public string AutoPart { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
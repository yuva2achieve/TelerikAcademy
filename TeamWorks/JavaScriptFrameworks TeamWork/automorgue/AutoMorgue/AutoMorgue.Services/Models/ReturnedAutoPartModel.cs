using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMorgue.Services.Models
{
    public class ReturnedAutoPartModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MorgueName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Category { get; set; }
    }
}
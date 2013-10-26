using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMorgue.Services.Models
{
    public class AutoPartAddModel
    {
        public string Morgue { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }
    }
}
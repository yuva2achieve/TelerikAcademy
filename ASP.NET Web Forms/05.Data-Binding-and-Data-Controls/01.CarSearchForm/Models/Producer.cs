using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.CarSearchForm.Models
{
    public class Producer
    {
        public string Name { get; set; }
        public ICollection<CarModel> Models { get; set; }
    }
}
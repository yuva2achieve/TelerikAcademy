using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMorgue.Models
{
    public class AutoPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Morgue Morgue { get; set; }
        public virtual Category Category { get; set; }
    }
}

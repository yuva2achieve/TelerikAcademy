using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMorgue.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual AutoPart AutoPart { get; set; }
        public virtual User User{ get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMorgue.Models
{
    public class Morgue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkTime { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<AutoPart> AutoParts { get; set; }

        public Morgue()
        {
            this.AutoParts = new HashSet<AutoPart>();
        }
    }
}

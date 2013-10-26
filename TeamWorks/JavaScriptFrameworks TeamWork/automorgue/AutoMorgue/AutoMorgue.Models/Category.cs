using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMorgue.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AutoPart> AutoParts { get; set; }

        public Category()
        {
            this.AutoParts = new HashSet<AutoPart>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class Tweet
    {
        public Tweet()
        {
            this.HashTags = new HashSet<HashTag>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<HashTag> HashTags { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}

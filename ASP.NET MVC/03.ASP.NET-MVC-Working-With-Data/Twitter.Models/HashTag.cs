using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twitter.Models
{
    public class HashTag
    {
        public HashTag()
        {
            this.Tweets = new HashSet<Tweet>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}

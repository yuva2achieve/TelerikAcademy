using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.Services.Models
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
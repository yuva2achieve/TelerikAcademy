using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.Services.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public virtual User Author { get; set; }
        public virtual Post Post { get; set; }
    }
}
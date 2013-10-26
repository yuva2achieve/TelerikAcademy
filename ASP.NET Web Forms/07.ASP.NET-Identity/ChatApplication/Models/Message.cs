using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApplication.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}
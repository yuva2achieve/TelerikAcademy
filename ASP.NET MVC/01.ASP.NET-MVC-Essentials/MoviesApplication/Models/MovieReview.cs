using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApplication.Models
{
    public class MovieReview
    {
        public int Id { get; set; }
        public decimal Rating { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual int MovieId { get; set; }
    }
}
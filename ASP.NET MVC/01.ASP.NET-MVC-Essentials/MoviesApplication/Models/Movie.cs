using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApplication.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Reviews = new HashSet<MovieReview>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MovieReview> Reviews { get; set; }
    }
}
using MoviesApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MoviesApplication.ViewModels
{
    public class MovieDetailsModel
    {
        public MovieDetailsModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.Description = movie.Description;
            this.Year = movie.Year;
            if (movie.Reviews.Count > 0)
            {
                this.Rating = movie.Reviews.Average(m => m.Rating);
                this.Reviews = movie.Reviews;
            }
            else
            {
                this.Rating = 0;
                this.Reviews = new HashSet<MovieReview>();
            }
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal? Rating { get; set; }
        public ICollection<MovieReview> Reviews { get; set; }
    }
}
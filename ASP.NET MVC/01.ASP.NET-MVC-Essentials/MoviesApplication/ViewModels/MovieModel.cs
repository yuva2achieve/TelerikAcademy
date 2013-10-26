using MoviesApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MoviesApplication.ViewModels
{
    public class MovieModel
    {
        public MovieModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.Year = movie.Year;
            if (movie.Reviews.Count > 0)
            {
                this.Rating = movie.Reviews.Average(m => m.Rating);
            }
            else
            {
                this.Rating = 0;
            }
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal? Rating { get; set; }
    }
}
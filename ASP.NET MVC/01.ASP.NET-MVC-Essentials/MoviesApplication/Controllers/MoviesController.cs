using MoviesApplication.Models;
using MoviesApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesApplication.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db;
        public MoviesController()
        {
            this.db = new ApplicationDbContext();
        }

        [HttpGet]
        [ActionName("Details")]
        public ActionResult MovieDetails(int id)
        {
            var movieInDb = this.db.Movies.Find(id);
            MovieDetailsModel movieModel = new MovieDetailsModel(movieInDb);
            return View(movieModel);
        }

        [HttpGet]
        [ActionName("All")]
        public ActionResult ListAllMovies()
        {
            var moviesInDb = db.Movies.Include("Reviews").ToList();
            var movieModels = new List<MovieModel>();
            foreach (var movie in moviesInDb)
            {
                MovieModel model = new MovieModel(movie);
                movieModels.Add(model);
            }
            return View(movieModels);
        }

        [HttpGet]
        [ActionName("Top250")]
        public ActionResult ListTopMovies()
        {
            var moviesInDb = db.Movies.Include("Reviews").ToList();
            var movieModels = new List<MovieModel>();
            foreach (var movie in moviesInDb)
            {
                MovieModel model = new MovieModel(movie);
                movieModels.Add(model);
            }
            movieModels = movieModels.OrderByDescending(m => m.Rating).ToList();
            return View(movieModels);
        }
	}
}
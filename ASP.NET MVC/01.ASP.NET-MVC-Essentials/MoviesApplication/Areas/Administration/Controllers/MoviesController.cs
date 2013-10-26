using MoviesApplication.Models;
using MoviesApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesApplication.Areas.Administration.Controllers
{
    [Authorize(Roles="Administrator")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext db;
        public MoviesController()
        {
            this.db = new ApplicationDbContext();
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
        [ActionName("Details")]
        public ActionResult MovieDetails(int id)
        {
            var movieInDb = this.db.Movies.Find(id);
            MovieDetailsModel movieModel = new MovieDetailsModel(movieInDb);
            return View(movieModel);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateMovie()
        {
            Movie movie = new Movie();
            return View(movie);
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateMovie([Bind(Include = "Title,Year,Description")]Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("All");
            }
            return View(movie);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditMovie(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound("Movie not found!");
            }

            return View(movie);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditMovie(int id, [Bind(Include = "Title,Year,Description")]Movie movie)
        {
            var movieInDb = db.Movies.Find(id);
            if (movieInDb == null)
            {
                return HttpNotFound("Movie not found!");
            }
            if (ModelState.IsValid)
            {
                movieInDb.Title = movie.Title;
                movieInDb.Description = movie.Description;
                movieInDb.Year = movie.Year;
                db.SaveChanges();
                return RedirectToAction("All");
            }
            return View(movie);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteMovie(int id)
        {
            var movie = db.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteMovie(int id, Movie movie)
        {
            var movieInDb = db.Movies.Find(id);
            movieInDb.Reviews.ToList().ForEach(r => db.MovieReviews.Remove(r));
            db.Movies.Remove(movieInDb);
            db.SaveChanges();
            return RedirectToAction("All");
        }
	}
}
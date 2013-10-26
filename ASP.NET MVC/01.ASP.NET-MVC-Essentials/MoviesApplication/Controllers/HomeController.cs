using MoviesApplication.Models;
using MoviesApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController()
        {
            this.db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var latestMovies = this.db.Movies.Include("Reviews").OrderByDescending(m => m.Id).Take(5).ToList();
            var movieModels = new List<MovieModel>();
            foreach (var movie in latestMovies)
            {
                MovieModel model = new MovieModel(movie);
                movieModels.Add(model);
            }
            return View(movieModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
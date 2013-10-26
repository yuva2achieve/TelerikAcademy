using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieLibrary.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Movies/
        public ActionResult Index()
        {
            return View(this.db.Movies.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                this.db.Movies.Add(movie);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("_Create",movie);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var movie = this.db.Movies
                .Include("LeadMaleActor")
                .Include("LeadFemaleActor")
                .FirstOrDefault(x => x.Id == id);
            return PartialView("_Update", movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var movieInDb = this.db.Movies
                    .Include("LeadMaleActor")
                    .Include("LeadFemaleActor")
                    .FirstOrDefault(x => x.Id == movie.Id);
                this.UpdateMovieValues(movieInDb, movie);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("_Update", movie);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var movie = this.db.Movies
                .Include("LeadMaleActor")
                .Include("LeadFemaleActor")
                .FirstOrDefault(x => x.Id == id);
            return PartialView("_Delete", movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Movie movie)
        {
            var movieInDb = this.db.Movies
                .Include("LeadMaleActor")
                .Include("LeadFemaleActor")
                .FirstOrDefault(x => x.Id == movie.Id);
            this.db.Movies.Remove(movieInDb);
            this.db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var movieInDb = this.db.Movies
                .Include("LeadMaleActor")
                .Include("LeadFemaleActor")
                .FirstOrDefault(x => x.Id == id);

            return PartialView("_Details", movieInDb);
        }

        private void UpdateMovieValues(Movie original, Movie updated)
        {
            original.Title = updated.Title;
            original.LeadMaleActor = updated.LeadMaleActor;
            original.LeadFemaleActor = updated.LeadFemaleActor;
            original.Year = updated.Year;
            original.Director = updated.Director;
        }
        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
	}
}
using MoviesApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesApplication.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [ActionName("Create")]
        public ActionResult AddReview(int movieId)
        {
            MovieReview review = new MovieReview() { MovieId = movieId };
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [ActionName("Create")]
        public ActionResult AddReview(int movieId, [Bind(Include = "Rating,Body")]MovieReview model)
        {
            var movie = db.Movies.Find(movieId);
            if (movie == null)
            {
                return HttpNotFound("Movie not found!");
            }
            var author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (ModelState.IsValid)
            {
                model.Author = author;
                model.MovieId = movieId;
                model.Date = DateTime.Now;
                movie.Reviews.Add(model);
                db.SaveChanges();
                return RedirectToAction("Details", "Movies", new { id = movie.Id });
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditReview(int movieId, int id, [Bind(Include = "Rating,Body")]MovieReview model)
        {
            var review = db.MovieReviews.Find(id);
            if (ModelState.IsValid)
            {
                review.Rating = model.Rating;
                review.Body = model.Body;
                review.Date = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Details", "Movies", new { id = movieId });
            }
            return View(review);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditReview(int movieId, int id)
        {
            var review = db.MovieReviews.Find(id);
            return View(review);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteReview(int movieId, int id)
        {
            var review = db.MovieReviews.Find(id);
            return View(review);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReview(int movieId, int id, MovieReview model)
        {
            var review = db.MovieReviews.Find(id);
            db.MovieReviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Details", "Movies", new { id = movieId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}
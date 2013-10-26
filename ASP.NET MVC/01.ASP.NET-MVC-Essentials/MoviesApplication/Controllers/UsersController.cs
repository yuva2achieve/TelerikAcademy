using MoviesApplication.Models;
using MoviesApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesApplication.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [ActionName("Reviews")]
        [Authorize]
        public ActionResult ListUserReviews()
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound("There is no such user.");
            }
            var reviews = db.MovieReviews.Include("Author").Where(r => r.Author.UserName == User.Identity.Name).ToList();
            if (reviews == null)
            {
                reviews = new List<MovieReview>();
            }
            return View(reviews);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}
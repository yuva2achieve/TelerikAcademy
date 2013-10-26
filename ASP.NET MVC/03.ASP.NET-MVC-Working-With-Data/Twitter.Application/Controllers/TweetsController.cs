using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Application.Models;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Application.Controllers
{
    public class TweetsController : BaseController
    {
        public TweetsController(IUowData data)
            : base(data)
        {
        }

        [HttpGet, ActionName("All")]
        public ActionResult All()
        {
            var tweets = this.Data.Tweets.All().OrderByDescending(t => t.Date).ToList();
            var currentUser = this.Data.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            foreach (var item in tweets)
            {
                item.Content = base.ReplaceTagsInContent(item);
            }

            ViewBag.currentUser = currentUser;
            return View(tweets);
        }

        [HttpGet, ActionName("Create")]
        [Authorize]
        public ActionResult Create()
        {
            return PartialView("_Create", new CreateTweetModel() { Content = string.Empty });
        }

        [HttpPost, ActionName("Create")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTweetModel model)
        {
            if (ModelState.IsValid)
            {
                var hashTags = this.Data.HashTags.All().ToList();
                var tweet = new Tweet();
                var author = this.Data.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                tweet.Content = model.Content;
                tweet.Date = DateTime.Now;
                tweet.Author = author;
                tweet.HashTags = base.GetTagsFromContent(model.Content, hashTags);
                author.Tweets.Add(tweet);
                this.Data.Tweets.Add(tweet);
                this.Data.SaveChanges();

                return RedirectToAction("Profile", "Users", new { username = User.Identity.Name });
            }

            return PartialView("_Create", model);
        }

        [HttpPost, ActionName("AddToFavorites")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddToFavorites(int id)
        {
            var tweet = this.Data.Tweets.GetById(id);
            var user = this.Data.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            user.FavoriteTweets.Add(tweet);
            this.Data.SaveChanges();
            return RedirectToAction("Profile", "Users", new { username = User.Identity.Name });
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;

namespace Twitter.Application.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache["LatestTweets"] == null)
            {
                var tweets = this.Data.Tweets
                    .All("Author,HashTags")
                    .OrderByDescending(t => t.Date)
                    .Take(10)
                    .ToList();

                foreach (var item in tweets)
                {
                    item.Content = base.ReplaceTagsInContent(item);
                }

                this.HttpContext.Cache.Add("LatestTweets", tweets, null, DateTime.Now.AddMinutes(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            var currentUser = this.Data.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            ViewBag.currentUser = currentUser;

            return View(this.HttpContext.Cache["LatestTweets"]);
        }
    }
}
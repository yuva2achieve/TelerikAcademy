using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Application.Models;
using Twitter.Data;

namespace Twitter.Application.Controllers
{
    public class TagsController : BaseController
    {
        public TagsController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Trending()
        {
            if (this.HttpContext.Cache["TrendingTags"] == null)
            {
                var tags = this.Data.HashTags
                    .All("Tweets")
                    .OrderByDescending(h => h.Tweets.Count)
                    .Select(x => new HashTagViewModel { Id = x.Id, Name = x.Name, TweetsCount = x.Tweets.Count })
                    .Take(10)
                    .ToList();

                this.HttpContext.Cache.Add("TrendingTags", tags, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["TrendingTags"]);
        }

        public ActionResult Search(int id)
        {
            string cacheKey = "Tag" + id;
            var tag = this.Data.HashTags.GetById(id);

            if (this.HttpContext.Cache[cacheKey] == null)
            {
                var tweets = tag.Tweets.ToList();

                foreach (var item in tweets)
                {
                    item.Content = this.ReplaceTagsInContent(item);
                }

                this.HttpContext.Cache.Add(cacheKey, tweets, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            var currentUser = this.Data.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            ViewBag.currentUser = currentUser;
            ViewBag.tag = tag.Name;

            return View(this.HttpContext.Cache[cacheKey]);
        }
	}
}
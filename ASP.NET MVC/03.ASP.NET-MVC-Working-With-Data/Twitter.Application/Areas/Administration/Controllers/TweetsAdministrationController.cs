using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Application.Areas.Administration.Models;
using Twitter.Data;
using Twitter.Models;
using Twitter.Application.Controllers;

namespace Twitter.Application.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TweetsAdministrationController : BaseController
    {
        public TweetsAdministrationController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            var tweets = this.Data.Tweets.All().ToList();
            var tweetModels = new List<TweetAdministrationModel>();

            foreach (var tweet in tweets)
            {
                var tweetModel = this.FromTweet(tweet);
                tweetModels.Add(tweetModel);
            }

            return View(tweetModels);
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var tweets = this.Data.Tweets.All().ToList();
            var tweetModels = new List<TweetAdministrationModel>();

            foreach (var tweet in tweets)
            {
                var tweetModel = this.FromTweet(tweet);
                tweetModels.Add(tweetModel);
            }

            return Json(tweetModels.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, TweetAdministrationModel model)
        {
            var newModel = model;

            if (model != null && ModelState.IsValid)
            {
                var hashTags = this.Data.HashTags.All().ToList();
                var tweetInDb = this.Data.Tweets.GetById(model.Id);
                tweetInDb.Content = model.Content;
                tweetInDb.Date = model.Date;
                tweetInDb.HashTags = base.GetTagsFromContent(model.Content, hashTags);
                
                this.Data.SaveChanges();

                newModel = this.FromTweet(tweetInDb);
            }

            return Json(new[] { newModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, TweetAdministrationModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var tweetInDb = this.Data.Tweets.GetById(model.Id);

                this.Data.Tweets.Delete(tweetInDb);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private TweetAdministrationModel FromTweet(Tweet tweet)
        {
            var tweetModel = new TweetAdministrationModel()
            {
                Id = tweet.Id,
                Content = tweet.Content,
                Date = tweet.Date
            };

            return tweetModel;
        }
	}
}
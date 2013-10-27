using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.Models;
using Twitter.Data;
using Moq;
using System.Web.Mvc;
using Twitter.Application.Controllers;
using Twitter.Tests.MoqHelpers;
using System.Web.Routing;
using Twitter.Application.Models;

namespace Twitter.Tests
{
    [TestClass]
    public class TweetsControllerTests
    {
        private TestHelpers helper;
        private Mock<IUowData> uowData;
        private Mock<ControllerContext> controllerContext;
        private TweetsController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            this.helper = new TestHelpers();
            this.uowData = this.helper.GetUnitOfWork();
            this.controllerContext = this.helper.GetControllerContext();

            var routes = new RouteCollection();
            Twitter.Application.RouteConfig.RegisterRoutes(routes);
            var helper = new UrlHelper(new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData()), routes);

            this.controller = new TweetsController(this.uowData.Object);
            this.controller.Url = helper;
            this.controller.ControllerContext = controllerContext.Object;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.helper.Users.Clear();
            this.helper.HashTags.Clear();
            this.helper.Tweets.Clear();
            this.uowData = null;
            this.controllerContext = null;
            this.controller = null;
        }

        [TestMethod]
        public void AllShouldReturn4Tweets()
        {
            var viewResult = this.controller.All() as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        public void AllShouldReturn0Tweets()
        {
            this.helper.Tweets.Clear();
            var viewResult = this.controller.All() as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(0, model.Count);
        }

        [TestMethod]
        public void AllShouldReturn6Tweets()
        {
            this.helper.Tweets.Add(new Tweet() { Id = 4, Content = "Tweet 5", Author = this.helper.User, Date = new DateTime(2013, 10, 18, 19, 0, 0) });
            this.helper.Tweets.Add(new Tweet() { Id = 5, Content = "Tweet 6", Author = this.helper.User, Date = new DateTime(2013, 10, 18, 19, 0, 0) });
            var viewResult = this.controller.All() as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(6, model.Count);
        }

        [TestMethod]
        public void AllShouldReturnOrderTweetsDescendingByDate()
        {
            var viewResult = this.controller.All() as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(4, model.Count);
            Assert.AreEqual(1, model[0].Id);
            Assert.AreEqual(0, model[1].Id);
            Assert.AreEqual(3, model[2].Id);
            Assert.AreEqual(2, model[3].Id);
        }

        [TestMethod]
        public void CreateShouldReturnProperView()
        {
            var viewResult = this.controller.Create() as PartialViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as CreateTweetModel;
            Assert.IsNotNull(model, "Model is Null!");
        }

        [TestMethod]
        public void CreateShouldCreateNewTweetProperly()
        {
            var newTweet = new CreateTweetModel() { Content = "This is text." };
            Assert.AreEqual(4, this.helper.Tweets.Count);

            var viewResult = this.controller.Create(newTweet) as RedirectToRouteResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            Assert.AreEqual(5, this.helper.Tweets.Count);
        }

        [TestMethod]
        public void CreateShouldNotAddTweetInCaseOfInvalidModel()
        {
            // Max content length allowed is 140
            var newTweet = new CreateTweetModel() { Content = "Error." };
            Assert.AreEqual(4, this.helper.Tweets.Count);

            this.controller.ViewData.ModelState.AddModelError("key", "ErrorMessage");
            var viewResult = this.controller.Create(newTweet) as PartialViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            Assert.AreEqual(4, this.helper.Tweets.Count);

            var model = viewResult.Model as CreateTweetModel;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(model, newTweet);
        }

        [TestMethod]
        public void AddToFavoritesShouldReturn404IfTweetIdIsInvalid()
        {
            var viewResult = this.controller.AddToFavorites(99) as HttpNotFoundResult;
            Assert.IsNotNull(viewResult, "View is Null!");
            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [TestMethod]
        public void AddToFavoritesShouldAddTweetProperly()
        {
            Assert.AreEqual(0, this.helper.Users[0].FavoriteTweets.Count);

            var viewResult = this.controller.AddToFavorites(this.helper.Tweets[0].Id) as RedirectToRouteResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            Assert.AreEqual(1, this.helper.Users[0].FavoriteTweets.Count);

            viewResult = this.controller.AddToFavorites(this.helper.Tweets[1].Id) as RedirectToRouteResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            Assert.AreEqual(2, this.helper.Users[0].FavoriteTweets.Count);
        }
    }
}
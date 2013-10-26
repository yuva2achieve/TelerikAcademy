using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.Models;
using Twitter.Data;
using Moq;
using System.Web.Mvc;
using Twitter.Application.Controllers;
using Twitter.Tests.MoqHelpers;
using System.Web.Routing;
using System.Linq;
using System.Linq.Expressions;
using Twitter.Application.Models;

namespace Twitter.Tests
{
    [TestClass]
    public class TweetsControllerTests
    {
        private ApplicationUser user;
        private List<ApplicationUser> users;
        private List<Tweet> tweets;
        private List<HashTag> hashTags;
        private Mock<IRepository<HashTag>> hashTagsRepository;
        private Mock<IRepository<Tweet>> tweetsRepository;
        private Mock<IRepository<ApplicationUser>> usersRepository;
        private Mock<IUowData> uowData;
        private Mock<ControllerContext> controllerContext;
        private TweetsController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            this.user = new ApplicationUser("admin") { FullName = "Admin Admin" };

            this.users = new List<ApplicationUser>()
            {
                this.user
            };

            this.hashTags = new List<HashTag>()
            {
                new HashTag(){ Id = 0, Name = "Tag1" },
                new HashTag(){ Id = 1, Name = "Tag2" },
                new HashTag(){ Id = 2, Name = "Tag3" }
            };

            this.tweets = new List<Tweet>()
            {
                new Tweet(){ Id = 0, Content = "Tweet 1", Author = this.user, Date = new DateTime(2013, 10, 18, 19, 0, 0) },
                new Tweet(){ Id = 1, Content = "Tweet 2", Author = this.user, Date = new DateTime(2013, 10, 18, 19, 20, 0) },
                new Tweet(){ Id = 2, Content = "Tweet 3", Author = this.user, Date = new DateTime(2013, 10, 18, 18, 0, 0) },
                new Tweet(){ Id = 3, Content = "Tweet 4", Author = this.user, Date = new DateTime(2013, 10, 18, 18, 20, 0) }
            };

            this.hashTags[0].Tweets.Add(this.tweets[0]);
            this.hashTags[0].Tweets.Add(this.tweets[1]);
            this.hashTags[0].Tweets.Add(this.tweets[2]);
            this.hashTags[1].Tweets.Add(this.tweets[0]);
            this.hashTags[1].Tweets.Add(this.tweets[3]);

            this.tweets[0].HashTags.Add(this.hashTags[0]);
            this.tweets[0].HashTags.Add(this.hashTags[1]);
            this.tweets[1].HashTags.Add(this.hashTags[0]);
            this.tweets[2].HashTags.Add(this.hashTags[0]);
            this.tweets[3].HashTags.Add(this.hashTags[1]);

            this.hashTagsRepository = new Mock<IRepository<HashTag>>();
            this.hashTagsRepository.Setup(x => x.Add(It.IsAny<HashTag>())).Callback((HashTag h) => this.hashTags.Add(h));
            this.hashTagsRepository.Setup(x => x.All(It.IsAny<string>())).Returns(this.hashTags.AsQueryable());
            this.hashTagsRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.hashTags[id]);

            this.tweetsRepository = new Mock<IRepository<Tweet>>();
            this.tweetsRepository.Setup(x => x.Add(It.IsAny<Tweet>())).Callback((Tweet t) => this.tweets.Add(t));
            this.tweetsRepository.Setup(x => x.All(It.IsAny<string>())).Returns(this.tweets.AsQueryable());

            this.usersRepository = new Mock<IRepository<ApplicationUser>>();
            this.usersRepository.Setup(x => x.All(null)).Returns(this.users.AsQueryable());
            this.usersRepository.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<ApplicationUser, bool>>>())).Returns(this.user);

            this.uowData = new Mock<IUowData>();
            this.uowData.SetupGet(x => x.HashTags).Returns(hashTagsRepository.Object);
            this.uowData.SetupGet(x => x.Tweets).Returns(tweetsRepository.Object);
            this.uowData.SetupGet(x => x.Users).Returns(usersRepository.Object);;

            var httpContext = MvcMockHelpers.FakeHttpContext("~/");
            var routes = new RouteCollection();
            Twitter.Application.RouteConfig.RegisterRoutes(routes);
            var helper = new UrlHelper(new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData()), routes);
            this.controllerContext = new Mock<ControllerContext>();
            this.controllerContext.Setup(ctx => ctx.HttpContext).Returns(httpContext);

            this.controller = new TweetsController(this.uowData.Object);
            this.controller.Url = helper;
            this.controller.ControllerContext = controllerContext.Object;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.user = null;
            this.users = null;
            this.tweets = null;
            this.hashTags = null;
            this.tweetsRepository = null;
            this.usersRepository = null;
            this.hashTagsRepository = null;
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
            this.tweets.Clear();
            var viewResult = this.controller.All() as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(0, model.Count);
        }

        [TestMethod]
        public void AllShouldReturn6Tweets()
        {
            this.tweets.Add(new Tweet() { Id = 4, Content = "Tweet 5", Author = this.user, Date = new DateTime(2013, 10, 18, 19, 0, 0) });
            this.tweets.Add(new Tweet() { Id = 5, Content = "Tweet 6", Author = this.user, Date = new DateTime(2013, 10, 18, 19, 0, 0) });
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
            Assert.AreEqual(4, this.tweets.Count);

            var viewResult = this.controller.Create(newTweet) as RedirectToRouteResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            Assert.AreEqual(5, this.tweets.Count);
        }

        [TestMethod]
        public void CreateShouldNotAddTweetInCaseOfInvalidModel()
        {
            // Max content length allowed is 140
            var newTweet = new CreateTweetModel() { Content = "Error." };
            Assert.AreEqual(4, this.tweets.Count);

            this.controller.ViewData.ModelState.AddModelError("key", "ErrorMessage");
            var viewResult = this.controller.Create(newTweet) as PartialViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            Assert.AreEqual(4, this.tweets.Count);

            var model = viewResult.Model as CreateTweetModel;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(model, newTweet);
        }
    }
}
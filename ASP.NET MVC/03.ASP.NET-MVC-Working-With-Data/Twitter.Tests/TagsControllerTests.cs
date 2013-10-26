using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.Models;
using System.Collections.Generic;
using Moq;
using Moq.Protected;
using Twitter.Data;
using Twitter.Application.Controllers;
using Twitter.Tests.MoqHelpers;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Routing;
using Twitter.Application.Models;

namespace Twitter.Tests
{
    [TestClass]
    public class TagsControllerTests
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
        private TagsController controller;

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
            this.hashTagsRepository.Setup(x => x.All(It.IsAny<string>())).Returns(this.hashTags.AsQueryable());
            this.hashTagsRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) => this.hashTags[id]);

            this.tweetsRepository = new Mock<IRepository<Tweet>>();
            this.tweetsRepository.Setup(x => x.All(It.IsAny<string>())).Returns(this.tweets.AsQueryable());

            this.usersRepository = new Mock<IRepository<ApplicationUser>>();
            this.usersRepository.Setup(x => x.All(null)).Returns(this.users.AsQueryable());
            this.usersRepository.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<ApplicationUser, bool>>>())).Returns(this.user);

            this.uowData = new Mock<IUowData>();
            this.uowData.SetupGet(x => x.HashTags).Returns(hashTagsRepository.Object);
            this.uowData.SetupGet(x => x.Tweets).Returns(tweetsRepository.Object);
            this.uowData.SetupGet(x => x.Users).Returns(usersRepository.Object);

            var httpContext = MvcMockHelpers.FakeHttpContext("~/");
            var routes = new RouteCollection();
            Twitter.Application.RouteConfig.RegisterRoutes(routes);
            var helper = new UrlHelper(new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData()), routes);
            this.controllerContext = new Mock<ControllerContext>();
            this.controllerContext.Setup(ctx => ctx.HttpContext).Returns(httpContext);

            this.controller = new TagsController(this.uowData.Object);
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
        public void SearchShouldReturn3ResultsForTagWithId0()
        {
            var viewResult = this.controller.Search(0) as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(3, model.Count);

            this.hashTags[0].Tweets.Add(this.tweets[3]);
            viewResult = this.controller.Search(0) as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            model = viewResult.Model as List<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");

            // Assert that previous result is cached.
            Assert.AreEqual(3, model.Count);
        }

        [TestMethod]
        public void SearchShouldReturn2ResultsForTagWithId1()
        {
            var viewResult = this.controller.Search(1) as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(2, model.Count);
        }

        [TestMethod]
        public void SearchShouldReturn0ResultsForTagWithId2()
        {
            var viewResult = this.controller.Search(2) as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(0, model.Count);
        }

        [TestMethod]
        public void TrendingShouldReturn3TagsByTweetCount()
        {
            var viewResult = this.controller.Trending() as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<HashTagViewModel>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(3, model.Count);
            Assert.AreEqual(0, model[0].Id);
            Assert.AreEqual(1, model[1].Id);
            Assert.AreEqual(2, model[2].Id);

            this.hashTags.Add(new HashTag() { Id = 3, Name = "Tag4" });
            viewResult = this.controller.Trending() as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            model = viewResult.Model as List<HashTagViewModel>;
            Assert.IsNotNull(model, "Model is Null!");

            // Assert that cache is working.
            Assert.AreEqual(3, model.Count);
        }

        [TestMethod]
        public void TrendingShouldReturn10TagsByTweetCount()
        {
            this.controller.HttpContext.Cache.Remove("TrendingTags");

            this.hashTags.Add(new HashTag() { Id = 3, Name = "Tag4" });
            this.hashTags.Add(new HashTag() { Id = 4, Name = "Tag5" });
            this.hashTags.Add(new HashTag() { Id = 5, Name = "Tag6" });
            this.hashTags.Add(new HashTag() { Id = 6, Name = "Tag7" });
            this.hashTags.Add(new HashTag() { Id = 7, Name = "Tag8" });
            this.hashTags.Add(new HashTag() { Id = 8, Name = "Tag9" });
            this.hashTags.Add(new HashTag() { Id = 9, Name = "Tag10" });
            this.hashTags.Add(new HashTag() { Id = 10, Name = "Tag11" });

            this.hashTags[10].Tweets.Add(this.tweets[0]);
            this.hashTags[10].Tweets.Add(this.tweets[1]);
            this.hashTags[10].Tweets.Add(this.tweets[2]);
            this.hashTags[10].Tweets.Add(this.tweets[3]);

            var viewResult = this.controller.Trending() as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<HashTagViewModel>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(10, model.Count);
            Assert.AreEqual(10, model[0].Id);
            Assert.AreEqual(0, model[1].Id);
            Assert.AreEqual(1, model[2].Id);
            Assert.AreEqual(2, model[3].Id);
        }
    }
}

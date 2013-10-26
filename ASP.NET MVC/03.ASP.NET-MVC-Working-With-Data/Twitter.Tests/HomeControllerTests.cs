using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Twitter.Models;
using Twitter.Data;
using System.Collections.Generic;
using System.Linq;
using Twitter.Application.Controllers;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web;
using Twitter.Tests.MoqHelpers;
using System.Web.Routing;

namespace Twitter.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private ApplicationUser user;
        private List<ApplicationUser> users;
        private List<Tweet> tweets;
        private Mock<IRepository<Tweet>> tweetsRepository;
        private Mock<IRepository<ApplicationUser>> usersRepository;
        private Mock<IUowData> uowData;
        private Mock<ControllerContext> controllerContext;
        private HomeController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            this.user = new ApplicationUser("admin") { FullName = "Admin Admin" };

            this.users = new List<ApplicationUser>()
            {
                this.user
            };

            this.tweets = new List<Tweet>()
            {
                new Tweet(){ Id = 0, Content = "Tweet 1", Author = this.user, Date = new DateTime(2013, 10, 18, 19, 0, 0) },
                new Tweet(){ Id = 1, Content = "Tweet 2", Author = this.user, Date = new DateTime(2013, 10, 18, 19, 20, 0) },
                new Tweet(){ Id = 2, Content = "Tweet 3", Author = this.user, Date = new DateTime(2013, 10, 18, 18, 0, 0) },
                new Tweet(){ Id = 3, Content = "Tweet 4", Author = this.user, Date = new DateTime(2013, 10, 18, 18, 20, 0) }
            };

            this.tweetsRepository = new Mock<IRepository<Tweet>>();
            this.tweetsRepository.Setup(x => x.All(It.IsAny<string>())).Returns(this.tweets.AsQueryable());

            this.usersRepository = new Mock<IRepository<ApplicationUser>>();
            this.usersRepository.Setup(x => x.All(null)).Returns(this.users.AsQueryable());
            this.usersRepository.Setup(x => x.FirstOrDefault(It.IsAny<Expression<Func<ApplicationUser, bool>>>())).Returns(this.user);

            this.uowData = new Mock<IUowData>();
            this.uowData.SetupGet(x => x.Tweets).Returns(tweetsRepository.Object);
            this.uowData.SetupGet(x => x.Users).Returns(usersRepository.Object);
            var httpContext = MvcMockHelpers.FakeHttpContext("~/");
            var routes = new RouteCollection();
            Twitter.Application.RouteConfig.RegisterRoutes(routes);
            var helper = new UrlHelper(new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData()), routes);
            this.controllerContext = new Mock<ControllerContext>();
            this.controllerContext.Setup(ctx => ctx.HttpContext).Returns(httpContext);

            this.controller = new HomeController(this.uowData.Object);
            this.controller.Url = helper;
            this.controller.ControllerContext = controllerContext.Object;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.user = null;
            this.users = null;
            this.tweets = null;
            this.tweetsRepository = null;
            this.usersRepository = null;
            this.uowData = null;
            this.controllerContext = null;
            this.controller = null;
        }

        [TestMethod]
        public void IndexShouldReturn4ItemsOrderedDescendingByDate()
        {
            var viewResult = this.controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "View result is Null!");
            Assert.IsNotNull(viewResult.Model, "Model is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.AreEqual(4, model.Count);
            Assert.AreEqual(1, model[0].Id);
            Assert.AreEqual(0, model[1].Id);
            Assert.AreEqual(3, model[2].Id);
            Assert.AreEqual(2, model[3].Id);
        }

        [TestMethod]
        public void IndexShouldReturn6ItemsOrderedDescendingByDate()
        { 
            // Remove cached values
            this.controller.HttpContext.Cache.Remove("LatestTweets");

            this.tweets.Add(new Tweet() { Id = 4, Content = "Tweet 5", Author = this.user, Date = new DateTime(2013, 10, 18, 19, 30, 0) });
            this.tweets.Add(new Tweet() { Id = 5, Content = "Tweet 6", Author = this.user, Date = new DateTime(2013, 10, 18, 19, 25, 0) });

            var viewResult = this.controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "View result is Null!");
            Assert.IsNotNull(viewResult.Model, "Model is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.AreEqual(6, model.Count);
            Assert.AreEqual(4, model[0].Id);
            Assert.AreEqual(5, model[1].Id);
            Assert.AreEqual(1, model[2].Id);
            Assert.AreEqual(0, model[3].Id);
            Assert.AreEqual(3, model[4].Id);
            Assert.AreEqual(2, model[5].Id);

            // Add new value
            this.tweets.Add(new Tweet() { Id = 6, Content = "Tweet 7", Author = this.user, Date = new DateTime(2013, 10, 18, 19, 25, 0) });
            
            viewResult = this.controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "View result is Null!");
            Assert.IsNotNull(viewResult.Model, "Model is Null!");

            // Assert that cache is working
            model = viewResult.Model as List<Tweet>;
            Assert.AreEqual(6, model.Count);
        }

        [TestMethod]
        public void IndexShouldReturnCachedResult()
        {
            var viewResult = this.controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "View result is Null!");
            Assert.IsNotNull(viewResult.Model, "Model is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.AreEqual(6, model.Count);
            Assert.AreEqual(4, model[0].Id);
            Assert.AreEqual(5, model[1].Id);
            Assert.AreEqual(1, model[2].Id);
            Assert.AreEqual(0, model[3].Id);
            Assert.AreEqual(3, model[4].Id);
            Assert.AreEqual(2, model[5].Id);
        }
    }
}

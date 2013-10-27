using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Twitter.Models;
using Twitter.Data;
using System.Collections.Generic;
using Twitter.Application.Controllers;
using System.Web.Mvc;
using Twitter.Tests.MoqHelpers;
using System.Web.Routing;

namespace Twitter.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private TestHelpers helper;
        private Mock<IUowData> uowData;
        private Mock<ControllerContext> controllerContext;
        private HomeController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            this.helper = new TestHelpers();
            this.uowData = this.helper.GetUnitOfWork();
            this.controllerContext = this.helper.GetControllerContext();

            var routes = new RouteCollection();
            Twitter.Application.RouteConfig.RegisterRoutes(routes);
            var helper = new UrlHelper(new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData()), routes);

            this.controller = new HomeController(this.uowData.Object);
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

            this.helper.Tweets.Add(new Tweet() { Id = 4, Content = "Tweet 5", Author = this.helper.User, Date = new DateTime(2013, 10, 18, 19, 30, 0) });
            this.helper.Tweets.Add(new Tweet() { Id = 5, Content = "Tweet 6", Author = this.helper.User, Date = new DateTime(2013, 10, 18, 19, 25, 0) });

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
            this.helper.Tweets.Add(new Tweet() { Id = 6, Content = "Tweet 7", Author = this.helper.User, Date = new DateTime(2013, 10, 18, 19, 25, 0) });
            
            viewResult = this.controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "View result is Null!");
            Assert.IsNotNull(viewResult.Model, "Model is Null!");

            // Assert that cache is working
            model = viewResult.Model as List<Tweet>;
            Assert.AreEqual(6, model.Count);
        }
    }
}

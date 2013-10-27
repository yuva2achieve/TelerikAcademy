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
        private TestHelpers helper;
        private Mock<IUowData> uowData;
        private Mock<ControllerContext> controllerContext;
        private TagsController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            this.helper = new TestHelpers();
            this.uowData = this.helper.GetUnitOfWork();
            this.controllerContext = this.helper.GetControllerContext();

            var routes = new RouteCollection();
            Twitter.Application.RouteConfig.RegisterRoutes(routes);
            var helper = new UrlHelper(new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData()), routes);

            this.controller = new TagsController(this.uowData.Object);
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
        public void SearchShouldReturn3ResultsForTagWithId0()
        {
            var viewResult = this.controller.Search(0) as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(3, model.Count);

            this.helper.HashTags[0].Tweets.Add(this.helper.Tweets[3]);
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

            this.helper.HashTags.Add(new HashTag() { Id = 3, Name = "Tag4" });
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

            this.helper.HashTags.Add(new HashTag() { Id = 3, Name = "Tag4" });
            this.helper.HashTags.Add(new HashTag() { Id = 4, Name = "Tag5" });
            this.helper.HashTags.Add(new HashTag() { Id = 5, Name = "Tag6" });
            this.helper.HashTags.Add(new HashTag() { Id = 6, Name = "Tag7" });
            this.helper.HashTags.Add(new HashTag() { Id = 7, Name = "Tag8" });
            this.helper.HashTags.Add(new HashTag() { Id = 8, Name = "Tag9" });
            this.helper.HashTags.Add(new HashTag() { Id = 9, Name = "Tag10" });
            this.helper.HashTags.Add(new HashTag() { Id = 10, Name = "Tag11" });

            this.helper.HashTags[10].Tweets.Add(this.helper.Tweets[0]);
            this.helper.HashTags[10].Tweets.Add(this.helper.Tweets[1]);
            this.helper.HashTags[10].Tweets.Add(this.helper.Tweets[2]);
            this.helper.HashTags[10].Tweets.Add(this.helper.Tweets[3]);

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

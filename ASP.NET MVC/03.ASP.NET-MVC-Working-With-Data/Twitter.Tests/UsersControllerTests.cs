using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.Application.Controllers;
using Moq;
using Twitter.Data;
using System.Web.Mvc;
using System.Web.Routing;
using Twitter.Tests.MoqHelpers;
using Twitter.Models;
using System.Collections.Generic;

namespace Twitter.Tests
{
    [TestClass]
    public class UsersControllerTests
    {
        private TestHelpers helper;
        private Mock<IUowData> uowData;
        private Mock<ControllerContext> controllerContext;
        private UsersController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            this.helper = new TestHelpers();
            this.uowData = this.helper.GetUnitOfWork();
            this.controllerContext = this.helper.GetControllerContext();

            var routes = new RouteCollection();
            Twitter.Application.RouteConfig.RegisterRoutes(routes);
            var helper = new UrlHelper(new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData()), routes);

            this.controller = new UsersController(this.uowData.Object);
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
        public void AllShouldReturn3Users()
        {
            var viewResult = this.controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<ApplicationUser>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(3, model.Count);
        }

        [TestMethod]
        public void AllShouldReturn4Users()
        {
            this.helper.Users.Add(new ApplicationUser("test111") { FullName = "Just testing" });
            var viewResult = this.controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as List<ApplicationUser>;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(4, model.Count);
        }
    }
}

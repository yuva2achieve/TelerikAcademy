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

        [TestMethod]
        public void GetUserProfileShouldReturnProperProfile()
        {
            var user = this.helper.User;

            var viewResult = this.controller.GetUserProfile(user.UserName) as ViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as ApplicationUser;
            Assert.IsNotNull(model, "Model is Null!");
            Assert.AreEqual(4, user.Tweets.Count);
            Assert.AreEqual("admin", user.UserName);
            Assert.AreEqual("Admin Admin", user.FullName);
        }

        [TestMethod]
        public void GetUserProfileShouldReturn404IfUsernameIsInvalid()
        {
            var viewResult = this.controller.GetUserProfile("invalidName") as HttpNotFoundResult;
            Assert.IsNotNull(viewResult, "View is Null!");
            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [TestMethod]
        public void TweetsShouldReturnProperNumberOfTweets()
        {
            var user = this.helper.User;

            var viewResult = this.controller.Tweets(user.UserName) as PartialViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as IEnumerable<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");

            var modelAsList = new List<Tweet>(model);
            Assert.IsNotNull(modelAsList, "Model is Null!");
            Assert.AreEqual(4, modelAsList.Count);

            this.helper.Tweets.Add(new Tweet() { Id = 5, Author = this.helper.User, Content = "Some content", Date = DateTime.Now });
            this.helper.User.Tweets.Add(this.helper.Tweets[4]);

            viewResult = this.controller.Tweets(user.UserName) as PartialViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            model = viewResult.Model as IEnumerable<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");

            modelAsList = new List<Tweet>(model);
            Assert.IsNotNull(modelAsList, "Model is Null!");
            Assert.AreEqual(5, modelAsList.Count);
        }

        [TestMethod]
        public void TweetsShouldReturn0Tweets()
        {
            var user = this.helper.User;
            this.helper.User.Tweets.Clear();

            var viewResult = this.controller.Tweets(user.UserName) as PartialViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as IEnumerable<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");

            var modelAsList = new List<Tweet>(model);
            Assert.IsNotNull(modelAsList, "Model is Null!");
            Assert.AreEqual(0, modelAsList.Count);
        }

        [TestMethod]
        public void TweetsShouldReturn404IfUsernameIsInvalid()
        {
            var viewResult = this.controller.Tweets("invalidusername") as HttpNotFoundResult;
            Assert.IsNotNull(viewResult, "View is Null!");
            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [TestMethod]
        public void FavoritesShouldReturnProperNumberOfTweets()
        {
            var user = this.helper.User;

            var viewResult = this.controller.Favorites(user.UserName) as PartialViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            var model = viewResult.Model as IEnumerable<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");

            var modelAsList = new List<Tweet>(model);
            Assert.IsNotNull(modelAsList, "Model is Null!");
            Assert.AreEqual(0, modelAsList.Count);

            this.helper.User.FavoriteTweets.Add(new Tweet() { Id = 5, Author = this.helper.User, Content = "Some content", Date = DateTime.Now });

            viewResult = this.controller.Favorites(user.UserName) as PartialViewResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            model = viewResult.Model as IEnumerable<Tweet>;
            Assert.IsNotNull(model, "Model is Null!");

            modelAsList = new List<Tweet>(model);
            Assert.IsNotNull(modelAsList, "Model is Null!");
            Assert.AreEqual(1, modelAsList.Count);
        }

        [TestMethod]
        public void FavoritesShouldReturn404IfUsernameIsInvalid()
        {
            var viewResult = this.controller.Favorites("invalidusername") as HttpNotFoundResult;
            Assert.IsNotNull(viewResult, "View is Null!");
            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [TestMethod]
        public void FollowShouldAddUserToFollowingList()
        {
            var user = this.helper.User;
            Assert.AreEqual(0, user.Following.Count);

            var viewResult = this.controller.Follow("testuser") as RedirectToRouteResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            user = this.helper.User;
            Assert.AreEqual(1, user.Following.Count);

            viewResult = this.controller.Follow("justtest") as RedirectToRouteResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            user = this.helper.User;
            Assert.AreEqual(2, user.Following.Count);
        }

        [TestMethod]
        public void FollowShouldReturn404IfUsernameIsInvalid()
        {
            var viewResult = this.controller.Follow("invalidusername") as HttpNotFoundResult;
            Assert.IsNotNull(viewResult, "View is Null!");
            Assert.AreEqual(404, viewResult.StatusCode);
        }

        [TestMethod]
        public void StopFollowingShouldRemoveUserFromFollowingList()
        {
            var user = this.helper.User;

            var viewResult = this.controller.Follow("testuser") as RedirectToRouteResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            user = this.helper.User;
            Assert.AreEqual(1, user.Following.Count);

            viewResult = this.controller.StopFollowing("testuser") as RedirectToRouteResult;
            Assert.IsNotNull(viewResult, "View is Null!");

            user = this.helper.User;
            Assert.AreEqual(0, user.Following.Count);
        }

        [TestMethod]
        public void StopFollowingShouldReturn404IfUsernameIsInvalid()
        {
            var viewResult = this.controller.StopFollowing("invalidusername") as HttpNotFoundResult;
            Assert.IsNotNull(viewResult, "View is Null!");
            Assert.AreEqual(404, viewResult.StatusCode);
        }
    }
}

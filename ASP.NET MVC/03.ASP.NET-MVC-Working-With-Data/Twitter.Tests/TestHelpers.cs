using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Twitter.Data;
using Twitter.Models;
using Twitter.Tests.MoqHelpers;

namespace Twitter.Tests
{
    public class TestHelpers
    {
        public ApplicationUser User { get; private set; }
        public List<ApplicationUser> Users { get; private set; }
        public List<HashTag> HashTags { get; private set; }
        public List<Tweet> Tweets { get; private set; }

        public TestHelpers()
        {
            this.AddUsers();
            this.AddHashTags();
            this.AddTweets();
            this.ConnectHashTagsAndTweets();
        }

        public Mock<IUowData> GetUnitOfWork()
        {
            Mock<IRepository<HashTag>> hashTagsRepository = new Mock<IRepository<HashTag>>();
            hashTagsRepository.Setup(x => x.Add(It.IsAny<HashTag>())).Callback((HashTag h) => this.HashTags.Add(h));
            hashTagsRepository.Setup(x => x.All(It.IsAny<string>())).Returns(this.HashTags.AsQueryable());
            hashTagsRepository.Setup(x => x.GetById(It.IsAny<object>())).Returns((object id) => this.HashTags.Find(h => h.Id == (int)id));

            Mock<IRepository<Tweet>> tweetsRepository = new Mock<IRepository<Tweet>>();
            tweetsRepository.Setup(x => x.Add(It.IsAny<Tweet>())).Callback((Tweet t) => this.Tweets.Add(t));
            tweetsRepository.Setup(x => x.GetById(It.IsAny<object>())).Returns((object id) => this.Tweets.Find(t => t.Id == (int)id));
            tweetsRepository.Setup(x => x.All(It.IsAny<string>())).Returns(this.Tweets.AsQueryable());

            Mock<IRepository<ApplicationUser>> usersRepository = new Mock<IRepository<ApplicationUser>>();
            usersRepository.Setup(x => x.All(null)).Returns(Users.AsQueryable());
            usersRepository.Setup(x => x.FirstOrDefault(It.IsAny<Func<ApplicationUser, bool>>())).Returns((Func<ApplicationUser, bool> predicate) => this.Users.FirstOrDefault(predicate));
            
            Mock<IUowData> uowData = new Mock<IUowData>();
            uowData.SetupGet(x => x.HashTags).Returns(hashTagsRepository.Object);
            uowData.SetupGet(x => x.Tweets).Returns(tweetsRepository.Object);
            uowData.SetupGet(x => x.Users).Returns(usersRepository.Object);

            return uowData;
        }

        public Mock<ControllerContext> GetControllerContext()
        {
            var httpContext = MvcMockHelpers.FakeHttpContext("~/");
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(ctx => ctx.HttpContext).Returns(httpContext);

            return controllerContext;
        }

        private void AddUsers()
        {
            this.User = new ApplicationUser("admin") { FullName = "Admin Admin" };

            this.Users = new List<ApplicationUser>()
            {
                this.User,
                new ApplicationUser("testuser") { FullName = "Ivan Ivanov" },
                new ApplicationUser("justtest") { FullName = "Georgi Georgiev" }
            };
        }

        private void AddHashTags()
        {
            this.HashTags = new List<HashTag>()
            {
                new HashTag(){ Id = 0, Name = "Tag1" },
                new HashTag(){ Id = 1, Name = "Tag2" },
                new HashTag(){ Id = 2, Name = "Tag3" }
            };
        }

        private void AddTweets()
        {
            this.Tweets = new List<Tweet>()
            {
                new Tweet(){ Id = 0, Content = "Tweet 1", Author = this.User, Date = new DateTime(2013, 10, 18, 19, 0, 0) },
                new Tweet(){ Id = 1, Content = "Tweet 2", Author = this.User, Date = new DateTime(2013, 10, 18, 19, 20, 0) },
                new Tweet(){ Id = 2, Content = "Tweet 3", Author = this.User, Date = new DateTime(2013, 10, 18, 18, 0, 0) },
                new Tweet(){ Id = 3, Content = "Tweet 4", Author = this.User, Date = new DateTime(2013, 10, 18, 18, 20, 0) }
            };

            this.User.Tweets.Add(this.Tweets[0]);
            this.User.Tweets.Add(this.Tweets[1]);
            this.User.Tweets.Add(this.Tweets[2]);
            this.User.Tweets.Add(this.Tweets[3]);
        }

        private void ConnectHashTagsAndTweets()
        {
            this.HashTags[0].Tweets.Add(this.Tweets[0]);
            this.HashTags[0].Tweets.Add(this.Tweets[1]);
            this.HashTags[0].Tweets.Add(this.Tweets[2]);
            this.HashTags[1].Tweets.Add(this.Tweets[0]);
            this.HashTags[1].Tweets.Add(this.Tweets[3]);

            this.Tweets[0].HashTags.Add(this.HashTags[0]);
            this.Tweets[0].HashTags.Add(this.HashTags[1]);
            this.Tweets[1].HashTags.Add(this.HashTags[0]);
            this.Tweets[2].HashTags.Add(this.HashTags[0]);
            this.Tweets[3].HashTags.Add(this.HashTags[1]);
        }
    }
}

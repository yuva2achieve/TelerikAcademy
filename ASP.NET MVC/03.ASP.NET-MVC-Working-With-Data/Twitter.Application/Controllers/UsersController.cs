using ImageResizer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;
using Twitter.Models;

namespace Twitter.Application.Controllers
{
    public class UsersController : BaseController
    {
        private const string ImageSuffix = "_thumb";
        private const string ImageSettings = "width=500&crop=auto&format=jpg";
        private readonly ImageFormat[] ValidImageFormats = new[] { ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Gif, ImageFormat.Bmp };
        
        public UsersController(IUowData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            var users = this.Data.Users.All().ToList();
            return View(users); 
        }

        [HttpGet, ActionName("Profile")]
        [Authorize]
        public ActionResult GetUserProfile(string username)
        {
            var user = this.Data.Users.FirstOrDefault(u => u.UserName == username);

            foreach (var item in user.Tweets)
            {
                item.Content = base.ReplaceTagsInContent(item);
            }
           
            return View("Profile", user);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChangeAvatar()
        {
            return PartialView("_ChangeAvatar");
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangeAvatar(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    bool isValid = false;
                    try
                    {
                        using (var img = Image.FromStream(file.InputStream))
                        {
                            isValid = this.ValidImageFormats.Contains(img.RawFormat);
                        }

                        if (isValid)
                        {
                            var user = this.Data.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                            string fileExtension = Path.GetExtension(file.FileName);
                            string fileName = string.Format("{0}", user.Id);
                            string location = Server.MapPath("~/img/Avatars");
                            if (!Directory.Exists(location))
                            {
                                Directory.CreateDirectory(location);
                            }

                            file.InputStream.Position = 0;
                            string newFileName = Path.Combine(location, fileName + ImageSuffix);
                            ImageJob i = new ImageJob(file, newFileName, new ResizeSettings(ImageSettings), false, true);
                            i.Build();
                            user.ProfilePicture = "/img/Avatars/" + fileName + ImageSuffix + ".jpg";
                            this.Data.SaveChanges();

                            return RedirectToAction("Profile", new { username = user.UserName });
                        }
                    }
                    catch (Exception)
                    {
                        return PartialView("_ChangeAvatar");
                    }
                }
            }

            return PartialView("_ChangeAvatar");
        }

        [HttpGet, ActionName("Tweets")]
        [Authorize]
        public ActionResult Tweets(string username)
        {
            var userTweeets = this.Data.Users.Where(u => u.UserName == username).Select(u => u.Tweets).FirstOrDefault();

            foreach (var item in userTweeets)
            {
                item.Content = base.ReplaceTagsInContent(item);
            }

            return PartialView("_ListTweets", userTweeets);
        }

        [HttpGet, ActionName("Favorites")]
        [Authorize]
        public ActionResult Favorites(string username)
        {
            var userFavoriteTweeets = this.Data.Users.Where(u => u.UserName == username).Select(u => u.FavoriteTweets).FirstOrDefault();

            foreach (var item in userFavoriteTweeets)
            {
                item.Content = base.ReplaceTagsInContent(item);
            }

            return PartialView("_ListTweets", userFavoriteTweeets);
        }

        [HttpGet, ActionName("Following")]
        [Authorize]
        public ActionResult Following(string username)
        {
            var usersFollowing = this.Data.Users.Where(u => u.UserName == username).Select(u => u.Following).FirstOrDefault();
            
            return PartialView("_ListUsers", usersFollowing);
        }

        [HttpGet, ActionName("Followers")]
        [Authorize]
        public ActionResult Followers(string username)
        {
            var usersFollowers = this.Data.Users.Where(u => u.UserName == username).Select(u => u.Followers).FirstOrDefault();

            return PartialView("_ListUsers", usersFollowers);
        }

        [HttpPost, ActionName("Follow")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Follow(string username)
        {
            var currentUser = this.Data.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var user = this.Data.Users.FirstOrDefault(u => u.UserName == username);
            currentUser.Following.Add(user);
            user.Followers.Add(currentUser);
            this.Data.SaveChanges();
            return RedirectToAction("Profile", new { username = User.Identity.Name });
        }

        [HttpPost, ActionName("StopFollowing")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult StopFollowing(string username)
        {
            var currentUser = this.Data.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var user = this.Data.Users.FirstOrDefault(u => u.UserName == username);
            currentUser.Following.Remove(user);
            user.Followers.Remove(currentUser);
            this.Data.SaveChanges();
            return RedirectToAction("Profile", new { username = User.Identity.Name });
        }
	}
}
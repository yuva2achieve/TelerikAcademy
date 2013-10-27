using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Models;

namespace Twitter
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            string username = Request.Params["username"];

            TwitterEntities context = new TwitterEntities();

            var currentUser = User.Identity.Name;

            if (username == currentUser)
            {
                Response.Redirect("~/Account/Manage");
                return;
            }
            var user = context.AspNetUsers.Include("AspNetUsers").FirstOrDefault(u => u.UserName == username);

            var isFollowing = user.AspNetUsers.Where(x => x.UserName == currentUser);

            if (isFollowing.FirstOrDefault() == null && username != currentUser)
            {
                this.FollowButton.Visible = true;
            }

            int followersCount = user.AspNetUsers.Count;
            int followingsCount = user.AspNetUsers1.Count;
            string userPhoto = user.ProfilePicture;

            if (string.IsNullOrEmpty(userPhoto))
            {
                userPhoto = "default-profile-picture.jpg";
            }

            this.LabelUserName.Text = user.UserName;
            this.followersCount.Text = followersCount.ToString();
            this.followingsCount.Text = followingsCount.ToString();
            var srcPhoto = "http://" + Request.Url.Authority + "/Account/Data/" + userPhoto;
            //var srcFixed = srcPhoto.Replace('\\', '/');
            this.userPhoto.Src = srcPhoto;
        }

        protected void FollowButton_Click(object sender, EventArgs e)
        {
            string username = Request.Params["username"];

            string currentUserName = User.Identity.Name;

            TwitterEntities context = new TwitterEntities();

            AspNetUser currentUser = context.AspNetUsers.Include("AspNetUsers").FirstOrDefault(x => x.UserName == currentUserName);
            var followingUser = context.AspNetUsers.FirstOrDefault(x => x.UserName == username);

            currentUser.AspNetUsers1.Add(followingUser);
            context.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }
    }
}
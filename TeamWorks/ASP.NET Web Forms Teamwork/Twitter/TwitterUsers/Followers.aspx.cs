using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Models;

namespace Twitter
{
    public partial class Followers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TwitterEntities context = new TwitterEntities();

            string username = User.Identity.Name;

            var currentUser = context.AspNetUsers.FirstOrDefault(x => x.UserName == username);
            var followers = currentUser.AspNetUsers.ToList();

            this.UsersControlFollowers.DataSource = followers;
        }

       
    }
}
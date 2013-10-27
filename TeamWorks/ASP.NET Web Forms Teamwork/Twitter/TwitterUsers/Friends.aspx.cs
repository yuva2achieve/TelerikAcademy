using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Models;

namespace Twitter
{
    public partial class Friends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TwitterEntities context = new TwitterEntities();

            string username = User.Identity.Name;

            var currentUser = context.AspNetUsers.FirstOrDefault(x => x.UserName == username);
            var following = currentUser.AspNetUsers1.ToList();

            this.UsersControlFriends.DataSource = following;
        }

        protected void SeeFriend_Command(object sender, CommandEventArgs e)
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("~/UserProfile?username="+username);          
        }
    }
}
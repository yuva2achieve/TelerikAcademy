using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Models;

namespace Twitter
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TwitterEntities context = new TwitterEntities();

            string username = User.Identity.Name;

            var allUsers = context.AspNetUsers.Where(x => x.UserName != username).ToList();

            this.ListViewAllUsers.DataSource = allUsers;
            this.ListViewAllUsers.DataBind();
        }

        protected void SeeFriend_Command(object sender, CommandEventArgs e)
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("~/UserProfile.aspx?username=" + username);
        }
    }
}
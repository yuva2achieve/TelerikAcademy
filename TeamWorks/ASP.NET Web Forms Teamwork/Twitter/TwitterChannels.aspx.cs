using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Models;

namespace Twitter
{
    public partial class TwitterChannels : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ViewChannel_Command(object sender, CommandEventArgs e)
        {
            int channelId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("Messages/ChannelMessages.aspx?channelId=" + channelId);
        }

        protected void ViewUserProfile_Command(object sender, CommandEventArgs e)
        {

        }

        protected void AddMessage_Command(object sender, CommandEventArgs e)
        {
            int channelId = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("Messages/CreateMessage.aspx?channelId=" + channelId);
        }

        public IQueryable<Channel> GridViewChannels_GetData()
        {
            TwitterEntities context = new TwitterEntities();
            return context.Channels.Include("AspNetUser").OrderBy(ch => ch.ChannelId);
        }

        protected void GridViewChannels_DataBinding(object sender, EventArgs e)
        {

        }

        protected void SeeFriend_Command(object sender, CommandEventArgs e)
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("~/UserProfile.aspx?username=" + username);
        }
    }
}


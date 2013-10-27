using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Controls;
using Twitter.Models;

namespace Twitter.Channels
{
    public partial class CreateChannel : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCreateChannel_Click(object sender, EventArgs e)
        {
            
            try
            {
                TwitterEntities context = new TwitterEntities();
                Channel channel = new Channel();
                var currentUserName = this.User.Identity.Name;
                var author = context.AspNetUsers.FirstOrDefault(x => x.UserName == currentUserName);
                    
                Verificator.ValidateChannel(ChannelName.Text);
                    
                channel.AspNetUser = author;
                channel.Name = ChannelName.Text;
                context.Channels.Add(channel);
                context.SaveChanges();
                
                ErrorSuccessNotifier.AddSuccessMessage("Channel created successfully.");
                ErrorSuccessNotifier.ShowAfterRedirect = true;

                Response.Redirect("../Messages/ChannelMessages.aspx?channelId=" + channel.ChannelId, false);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
            
        }

       
    }
}
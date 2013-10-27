using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Controls;
using Twitter.Models;

namespace Twitter.Messages
{
    public partial class CreateMessage : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            TwitterEntities context = new TwitterEntities();
            var channels = context.Channels.ToList();
            this.DropDownListChannels.DataSource = channels;
            this.DropDownListChannels.DataTextField = "Name";
            this.DropDownListChannels.DataValueField = "ChannelId";
            this.DropDownListChannels.DataBind();
        }

        protected void ButtonCreateMessage_Click(object sender, EventArgs e)
        {
            try
            {
                int channelId = Convert.ToInt32(this.DropDownListChannels.SelectedValue);
                    
                TwitterEntities context = new TwitterEntities();
                Message msg = new Message();
                Channel channel = context.Channels.Find(channelId);
                    
                msg.Channel = channel;
                string msgText = MessageContent.Text;
                    
                Verificator.ValidateMessage(msgText);
                    
                msg.MessageContent = msgText;
                var currentUserName = this.User.Identity.Name;
                var author = context.AspNetUsers.FirstOrDefault(x => x.UserName == currentUserName);
                    
                msg.AspNetUser = author;
                msg.Date = DateTime.Now;
                context.Messages.Add(msg);
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Message created successfully.");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                Response.Redirect("ChannelMessages.aspx?channelId=" + channelId, false);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}
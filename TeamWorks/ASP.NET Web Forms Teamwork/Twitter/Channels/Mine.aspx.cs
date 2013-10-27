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
    public partial class Mine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SeeFriend_Command(object sender, CommandEventArgs e)
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("~/UserProfile.aspx?username=" + username);
        }

        protected void ViewChannel_Command(object sender, CommandEventArgs e)
        {
            int channelId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("Messages/ChannelMessages.aspx?channelId=" + channelId);
        }

        protected void ViewUserProfile_Command(object sender, CommandEventArgs e)
        {

        }

        protected void GridViewChannels_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            string currentUser = User.Identity.Name;
            return context.Channels.Include("AspNetUser").OrderBy(ch => ch.ChannelId).Where(x => x.AspNetUser.UserName == currentUser);
        }

        protected void GridViewChannels_DataBinding(object sender, EventArgs e)
        {

        }

        protected void LinkButtonDeleteChannel_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int channelId = Convert.ToInt32(e.CommandArgument);

                TwitterEntities context = new TwitterEntities();

                var channel = context.Channels.Include("Messages").FirstOrDefault(x => x.ChannelId == channelId);

                var messages = channel.Messages;

                context.Messages.RemoveRange(messages);
                context.Channels.Remove(channel);
                context.SaveChanges();
                ErrorSuccessNotifier.AddInfoMessage("Channel successfully removed");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                Response.Redirect(Request.RawUrl, false);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void LinkButtonUpdate_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int channelId = Convert.ToInt32(e.CommandArgument);

                TwitterEntities context = new TwitterEntities();

                var channel = context.Channels.FirstOrDefault(x => x.ChannelId == channelId);
                var button = sender as LinkButton;

                var tr = button.Parent.Parent;

                var textBox = tr.FindControl("TextBoxEditChannel") as TextBox;

                string newChannelName = textBox.Text;
                Verificator.ValidateChannel(newChannelName);
                channel.Name = newChannelName;
                context.SaveChanges();
                ErrorSuccessNotifier.AddInfoMessage("Channel name updated successfully.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewMyChannels_UpdateItem(int ChannelId)
        {
            TwitterEntities context = new TwitterEntities();
            Twitter.Models.Channel item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            item = context.Channels.Find(ChannelId);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", ChannelId));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                try
                {
                    Verificator.ValidateChannel(item.Name);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("Channel updated successfully");
                }
                catch (Exception ex)
                {
                     ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                }
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewMyChannels_DeleteItem(int ChannelId)
        {
            try
            {
                int channelId = ChannelId;

                TwitterEntities context = new TwitterEntities();

                var channel = context.Channels.Include("Messages").FirstOrDefault(x => x.ChannelId == channelId);

                string currentUsername = User.Identity.Name;
                if (channel.AspNetUser.UserName != currentUsername)
                {
                    throw new Exception("Different owner of the channel.");
                }

                var messages = channel.Messages;

                context.Messages.RemoveRange(messages);
                context.Channels.Remove(channel);
                context.SaveChanges();
                ErrorSuccessNotifier.AddInfoMessage("Channel successfully removed.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
            //Response.Redirect(Request.RawUrl);
        }
    }
}
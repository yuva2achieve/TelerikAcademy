using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Models;

namespace Twitter.Admin
{
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PanelMessageInfoHolder.Visible = false;



            //this.GridViewMessages.DataSource = messages;
            //this.GridViewMessages.DataBind();

        }

        protected void SeeFriend_Command(object sender, CommandEventArgs e)
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("~/UserProfile.aspx?username=" + username);
        }

        protected void ViewMessageInfo_Command(object sender, CommandEventArgs e)
        {
            int messageId = Convert.ToInt32(e.CommandArgument);
            TwitterEntities context = new TwitterEntities();
            var message = context.Messages.Find(messageId);

            this.PanelMessageInfoHolder.Visible = true;

            this.LabelMessageId.Text = Server.HtmlEncode(messageId.ToString());
            this.LabelMessageCreator.Text = Server.HtmlEncode(message.AspNetUser.UserName);
            this.LabelMessageContent.Text = Server.HtmlEncode(message.MessageContent);
            this.LabelMessageDate.Text = Server.HtmlEncode(message.Date.ToString());
        }

        protected void ViewUserProfile_Command(object sender, CommandEventArgs e)
        {

        }

        protected void HyperLinkAddMessage_Click(object sender, EventArgs e)
        {
            int channelId = Convert.ToInt32(Request.Params["channelId"]);

            TwitterEntities context = new TwitterEntities();

            string currentUserName = User.Identity.Name;

            string userId = context.AspNetUsers.FirstOrDefault(x => x.UserName == currentUserName).Id;

            Message message = new Message()
            {
                ChannelId = channelId,
                Date = DateTime.Now,
                MessageContent = this.MessageContent.Text,
                UserId = userId
            };

            context.Messages.Add(message);
            context.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }

        public IQueryable<Message> GridViewChannels_GetData()
        {
            TwitterEntities context = new TwitterEntities();
            return context.Messages.OrderBy(m => m.MessageId);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewMessages_UpdateItem(int MessageId)
        {
            TwitterEntities context = new TwitterEntities();
            Twitter.Models.Message item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            item = context.Messages.Find(MessageId);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", MessageId));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                context.SaveChanges();
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewMessages_DeleteItem(int MessageId)
        {
            int messageId = MessageId;

            TwitterEntities context = new TwitterEntities();

            var message = context.Messages.Find(messageId);
            context.Messages.Remove(message);
            context.SaveChanges();
        }
    }
}
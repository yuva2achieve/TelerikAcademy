using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Twitter.Controls;
using Twitter.Models;

namespace Twitter.Messages
{
    public partial class ChannelMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int channelId = Convert.ToInt32(Request.Params["channelId"]);

            TwitterEntities context = new TwitterEntities();
            var channel = context.Channels.FirstOrDefault(x => x.ChannelId == channelId);

            this.ChannelNameHolder.InnerText = "Welcome to channel: " + channel.Name;

            if (!IsPostBack)
            {
                this.PanelMessageInfoHolder.Visible = false;
                this.InfoHolder.Visible = false;
            }
        }

        protected void SeeFriend_Command(object sender, CommandEventArgs e)
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("~/UserProfile.aspx?username=" + username);
        }

        protected void LinkButtonViewMessageDetails_Command(object sender, CommandEventArgs e)
        {
            int messageId = Convert.ToInt32(e.CommandArgument);
            TwitterEntities context = new TwitterEntities();
            var message = context.Messages.Find(messageId);

            this.PanelMessageInfoHolder.Visible = true;
            this.InfoHolder.Visible = false;

            this.LabelMessageId.Text = Server.HtmlEncode(messageId.ToString());
            this.LabelMessageCreator.Text = Server.HtmlEncode(message.AspNetUser.UserName);
            this.LabelMessageContent.Text = Server.HtmlEncode(message.MessageContent);
            this.LabelMessageDate.Text = Server.HtmlEncode(message.Date.ToString());
            //ErrorSuccessNotifier.ShowAfterRedirect = true;
        }

        protected void HyperLinkAddMessage_Click(object sender, EventArgs e)
        {
            try
            {
                int channelId = Convert.ToInt32(Request.Params["channelId"]);

                TwitterEntities context = new TwitterEntities();

                string currentUserName = User.Identity.Name;

                LinkButton button = sender as LinkButton;

                var tr = button.Parent.Parent;

                var trControls = tr.Controls;

                string messageContent = null;

                foreach (Control tdControl in trControls)
                {
                    foreach (Control control in tdControl.Controls)
                    {
                        if (control.ID == "MessageContent")
                        {
                            messageContent = (control as TextBox).Text;
                        }
                    }
                }

                Verificator.ValidateMessage(messageContent);

                string userId = context.AspNetUsers.FirstOrDefault(x => x.UserName == currentUserName).Id;

                Message message = new Message()
                {
                    ChannelId = channelId,
                    Date = DateTime.Now,
                    MessageContent = messageContent,
                    UserId = userId
                };

                context.Messages.Add(message);
                context.SaveChanges();
                this.GridViewMessages.DataBind();
                this.InfoHolder.Visible = false;
                //ErrorSuccessNotifier.ShowAfterRedirect = false;
                //ErrorSuccessNotifier.AddSuccessMessage("Message created successfully.");
            }
            catch (Exception ex)
            {

                this.InfoHolder.InnerText = ex.Message;
                this.InfoHolder.Attributes.Add("class", "alert alert-error");
                this.InfoHolder.Visible = true;
                //ErrorSuccessNotifier.ShowAfterRedirect = false;
                //ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        public IQueryable<Message> GridViewChannels_GetData()
        {
            TwitterEntities context = new TwitterEntities();
            int channelId = Convert.ToInt32(Request.Params["channelId"]);

            var messages = context.Messages.Include("Channel").
                Where(x => x.ChannelId == channelId);

            return messages.OrderBy(m => m.MessageId);
        }


    }
}
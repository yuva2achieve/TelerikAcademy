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
    public partial class MyMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewMyMessages_UpdateItem(int MessageId)
        {
            TwitterEntities context = new TwitterEntities();
            Twitter.Models.Message item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);

            item = context.Messages.FirstOrDefault(x => x.MessageId == MessageId);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", MessageId));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                try
                {
                    Verificator.ValidateMessage(item.MessageContent);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("Message has been edited successfully");
                }
                catch (Exception ex)
                {
                    if (ex.Message != null)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                    }
                    else
                    {
                        ErrorSuccessNotifier.AddErrorMessage(ex);
                    }
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewMyMessages_DeleteItem(int MessageId)
        {
            try
            {
                TwitterEntities context = new TwitterEntities();

                var message = context.Messages.FirstOrDefault(x => x.MessageId == MessageId);
                context.Messages.Remove(message);
                context.SaveChanges();
                ErrorSuccessNotifier.AddInfoMessage("Message has been deleted successfully");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        public IQueryable<Message> GridViewChannels_GetData()
        {
            TwitterEntities context = new TwitterEntities();

            string currentUserName = User.Identity.Name;
            var messages = context.AspNetUsers.Include("Messages").
                FirstOrDefault(x => x.UserName == currentUserName).Messages.OrderBy(m => m.MessageId).AsQueryable();
            return messages;
        }     
    }
}
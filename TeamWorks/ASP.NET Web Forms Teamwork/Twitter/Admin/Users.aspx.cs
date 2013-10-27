using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Models;

namespace Twitter.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.messageDiv.Visible = false;
        }

        protected void SeeFriend_Command(object sender, CommandEventArgs e)
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("~/UserProfile.aspx?username=" + username);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewAllUsers_UpdateItem(string Id)
        {
            TwitterEntities context = new TwitterEntities();
            Twitter.Models.AspNetUser item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            item = context.AspNetUsers.Find(Id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("User has been successfully edited");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                }

                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewAllUsers_DeleteItem(string Id)
        {
            string userId = Id;

            TwitterEntities context = new TwitterEntities();

            var user = context.AspNetUsers.Find(userId);

            context.Messages.RemoveRange(user.Messages);
            var channels = user.Channels;
            foreach (var channel in channels)
            {
                context.Messages.RemoveRange(channel.Messages);
            }
            context.Channels.RemoveRange(channels);
            context.AspNetUserLogins.RemoveRange(user.AspNetUserLogins);
            context.AspNetUserManagements.Remove(user.AspNetUserManagement);
            context.AspNetUsers.Remove(user);
            context.SaveChanges();
        }

        public IQueryable<Twitter.Models.AspNetUser> ListViewUsers_GetData()
        {
            TwitterEntities context = new TwitterEntities();

            string username = User.Identity.Name;
            var allUsers = context.AspNetUsers.
                Where(x => x.UserName != username).AsQueryable();

            return allUsers;
        }
        public IQueryable<Twitter.Models.AspNetUser> ListViewRegularUsers_GetData()
        {
            TwitterEntities context = new TwitterEntities();

            string username = User.Identity.Name;
            HashSet<AspNetUser> users = new HashSet<AspNetUser>();

            var allUsers = context.AspNetUsers.
                Where(x => x.UserName != username);
            foreach (AspNetUser user in allUsers)
            {
                bool isAdmin = false;
                foreach (var role in user.AspNetRoles)
                {
                    if (role.Name == "Admin")
                    {
                        isAdmin = true;
                        break;
                    }
                }

                if (!isAdmin)
                {
                    users.Add(user);
                }
            }

            return users.AsQueryable();
        }

        public IQueryable<Twitter.Models.AspNetUser> ListViewAdmins_GetData()
        {
            TwitterEntities context = new TwitterEntities();

            string username = User.Identity.Name;
            HashSet<AspNetUser> users = new HashSet<AspNetUser>();

            var allUsers = context.AspNetUsers.
                Where(x => x.UserName != username);
            foreach (AspNetUser user in allUsers)
            {
                bool isAdmin = false;
                foreach (var role in user.AspNetRoles)
                {
                    if (role.Name == "Admin")
                    {
                        isAdmin = true;
                        break;
                    }
                }

                if (isAdmin)
                {
                    users.Add(user);
                }
            }

            return users.AsQueryable();
        }
        protected void MakeAdmin_Command(object sender, CommandEventArgs e)
        {
            TwitterEntities context = new TwitterEntities();
            string id = e.CommandArgument.ToString();
            var user = context.AspNetUsers.Find(id);
            var userRoles = user.AspNetRoles;

            this.messageDiv.Visible = true;

            var adminRole = context.AspNetRoles.FirstOrDefault(r => r.Name == "Admin");
            user.AspNetRoles.Add(adminRole);
            context.SaveChanges();
            this.ListViewAdmins.DataBind();
            this.ListViewRegularUsers.DataBind();
            this.messageText.InnerText = "Admin successfully promored!";
            this.messageDiv.Attributes["class"] = "alert alert-success";
        }

        protected void DemoteAdmin_Command(object sender, CommandEventArgs e)
        {
            TwitterEntities context = new TwitterEntities();
            string id = e.CommandArgument.ToString();
            var user = context.AspNetUsers.Find(id);

            this.messageDiv.Visible = true;

            var adminRole = context.AspNetRoles.FirstOrDefault(r => r.Name == "Admin");
            user.AspNetRoles.Remove(adminRole);
            context.SaveChanges();
            this.ListViewAdmins.DataBind();
            this.ListViewRegularUsers.DataBind();
            this.messageText.InnerText = "Admin successfully demoted!";
            this.messageDiv.Attributes["class"] = "alert alert-success";
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Twitter.Models;

namespace Twitter.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        }
        protected void Page_Load()
        {
            TwitterEntities context = new TwitterEntities();

            var currentUser = User.Identity.Name;
            var user = context.AspNetUsers.Include("AspNetUsers").FirstOrDefault(u => u.UserName == currentUser);

            int followersCount = user.AspNetUsers.Count;
            int followingsCount = user.AspNetUsers1.Count;
            string userPhoto = user.ProfilePicture;
            if (string.IsNullOrEmpty(userPhoto))
            {
                userPhoto = "default-profile-picture.jpg";
            }
            var srcPhoto = "http://" + Request.Url.Authority + "/Account/Data/" + userPhoto;
            this.userPhoto.Src = srcPhoto;
            if (!IsPostBack)
            {

                // Determine the sections to render
                ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
                if (manager.HasLocalLogin(User.Identity.GetUserId()))
                {
                    changePasswordHolder.Visible = true;
                }
                else
                {
                    setPassword.Visible = true;
                    changePasswordHolder.Visible = false;
                }
                CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1;

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                IPasswordManager manager = new IdentityManager(new IdentityStore()).Passwords;
                IdentityResult result = manager.ChangePassword(User.Identity.GetUserName(), CurrentPassword.Text, NewPassword.Text);
                if (result.Success)
                {
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
        }

        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create the local login info and link the local account to the user
                ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
                IdentityResult result = manager.AddLocalLogin(User.Identity.GetUserId(), User.Identity.GetUserName(), password.Text);
                if (result.Success)
                {
                    Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
        }

        public IEnumerable<IUserLogin> GetLogins()
        {
            ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
            var accounts = manager.GetLogins(User.Identity.GetUserId());
            CanRemoveExternalLogins = accounts.Count() > 1;
            return accounts;
        }

        public void RemoveLogin(string loginProvider, string providerKey)
        {
            ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
            var result = manager.RemoveLogin(User.Identity.GetUserId(), loginProvider, providerKey);
            var msg = result.Success
                ? "?m=RemoveLoginSuccess"
                : String.Empty;
            Response.Redirect("~/Account/Manage" + msg);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected void UploadProfilePictureButton_Click(object sender, EventArgs e)
        {
            var username = User.Identity.Name;
            if ((UploadProfilePictureForm.PostedFile != null)
                && (UploadProfilePictureForm.PostedFile.ContentLength > 0))
            {
                TwitterEntities context = new TwitterEntities();
                var user = context.AspNetUsers.FirstOrDefault(x => x.UserName == username);
                var userId = user.Id;
                string fn = userId + System.IO.Path.
                    GetExtension(UploadProfilePictureForm.PostedFile.FileName);
                string SaveLocation = Server.MapPath("Data") + "\\" + fn;

                try
                {
                    UploadProfilePictureForm.PostedFile.SaveAs(SaveLocation);
                    Response.Write("The file has been uploaded.");
                    user.ProfilePicture = fn;
                    context.SaveChanges();
                    Response.Write(fn);
                    Response.Redirect("Manage");
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }
    }
}
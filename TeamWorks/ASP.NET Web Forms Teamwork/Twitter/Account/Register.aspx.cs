using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Twitter.Models;

namespace Twitter.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            TwitterEntities context = new TwitterEntities();
            string userName = UserName.Text;
            var manager = new AuthenticationIdentityManager(new IdentityStore());
            User u = new User(userName) { UserName = userName };
            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);


            var role = context.AspNetRoles.FirstOrDefault(x => x.Name == "User");


            if (result.Success)
            {
                string userId = u.Id;

                AspNetUser currentUser = context.AspNetUsers.FirstOrDefault(x => x.Id == userId);
                currentUser.AspNetRoles.Add(role);
                context.SaveChanges();

                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        //private void CreateUser(TwitterEntities context, User user)
        //{
        //    var manager = new AuthenticationIdentityManager(new IdentityStore(context));
        //    var role = await manager.Roles.FindRoleByNameAsync("Registered user");
        //    if (role == null)
        //    {
        //        ErrorMessage.Text = "Role \"Registered user\" missing.";
        //        return;
        //    }
        //    string password = this.Password.Text;
        //    IdentityResult result = manager.Users.CreateLocalUser(user, password);
        //    if (result.Success)
        //    {
        //        IdentityResult addToRoleResult = await manager.Roles.AddUserToRoleAsync(user.Id, role.Id);
        //        if (addToRoleResult.Success)
        //        {
        //            manager.Authentication.SignIn(Context.GetOwinContext().Authentication, user.Id, isPersistent: false);
        //            OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        //        }
        //        else
        //        {
        //            ErrorMessage.Text = addToRoleResult.Errors.FirstOrDefault();
        //        }
        //    }
        //    else
        //    {
        //        ErrorMessage.Text = result.Errors.FirstOrDefault();
        //    }
        //}
    }
}
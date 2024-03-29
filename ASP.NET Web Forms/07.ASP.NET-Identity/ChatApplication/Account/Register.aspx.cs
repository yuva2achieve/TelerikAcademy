﻿using ChatApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ChatApplication.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string email = Email.Text;
            var manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
            ApplicationUser u = new ApplicationUser() 
            { 
                UserName = userName, 
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                DisplayName = firstName + " " + lastName
            };
            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
            if (result.Success) 
            {
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}